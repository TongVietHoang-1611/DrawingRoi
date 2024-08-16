using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;
using Emgu.CV.Features2D;
using Emgu.CV.Flann;
using System.Diagnostics;

namespace DrawingRoi
{
    public partial class Form1 : Form
    {
        Dictionary<string, Image<Bgr, byte>> imgList;
        Rectangle rect;
        Point StartROI, EndROI;
        bool Selecting, MouseDown;

        public Form1()
        {
            InitializeComponent();
            Selecting = false;
            rect = Rectangle.Empty;
            imgList = new Dictionary<string, Image<Bgr, byte>>();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                imgList.Clear();
                OpenFileDialog dialog = new OpenFileDialog();
                if(dialog.ShowDialog() == DialogResult.OK)
                {
                    var img = new Image<Bgr, byte >(dialog.FileName);
                    AddImage(img, "Input");
                    pictureBox1.Image=img.AsBitmap();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }

        private void selectROIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Selecting = true;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if(Selecting)
            {
                MouseDown = true;
                StartROI = e.Location;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if(Selecting)
            {
                int width = Math.Max(StartROI.X, e.X) - Math.Min(StartROI.X, e.X);
                int height = Math.Max(StartROI.Y, e.Y) - Math.Min(StartROI.Y, e.Y);
                rect = new Rectangle(Math.Min(StartROI.X, e.X),
                    Math.Min(StartROI.Y, e.Y),
                    width,
                    height);
                Refresh();
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if(MouseDown)
            {
                using (Pen pen = new Pen(Color.Red, 3))
                {
                    e.Graphics.DrawRectangle(pen, rect);    
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if(Selecting)
            {
                Selecting = false;
                MouseDown = false;
            }
        }

        private void selectRegionROIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (pictureBox1.Image == null)
                    return;
                if (rect == Rectangle.Empty)
                    return;

                var img = new Bitmap(pictureBox1.Image).ToImage<Bgr, byte>();
                img.ROI= rect;
                var imgROI = img.Copy();
                img.ROI = Rectangle.Empty;

                pictureBox1.Image=imgROI.ToBitmap();
                AddImage(imgROI, "ROI Image");
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                pictureBox1.Image = imgList[e.Node.Text].AsBitmap();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void processToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void matchingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (pictureBox1.Image == null || rect == null)
                {
                    return;
                }

                var imgScene = imgList["Input"].Clone();
                var template = new Bitmap(pictureBox1.Image).ToImage<Bgr, byte>();

                Mat imgout = new Mat();

                Stopwatch stopwatch = Stopwatch.StartNew();
                CvInvoke.MatchTemplate(imgScene, template, imgout, TemplateMatchingType.Sqdiff);


                double minVal = 0.0;
                double maxVal = 0.0;
                Point minloc = new Point();
                Point maxloc = new Point();

                CvInvoke.MinMaxLoc(imgout, ref minVal, ref maxVal, ref minloc, ref maxloc);
                Rectangle r = new Rectangle(minloc, template.Size);

                CvInvoke.Rectangle(imgScene, r, new MCvScalar(255, 0, 0), 3);
                pictureBox1.Image = imgScene.AsBitmap();
                stopwatch.Stop();

                Console.WriteLine($"Time for match template: {stopwatch.Elapsed.TotalMilliseconds} ms");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void resizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if(!imgList.ContainsKey("ROI Image"))
                {
                    MessageBox.Show("Please select a template");
                    return;
                }

                var img = new Bitmap (pictureBox1.Image).ToImage<Bgr, byte>();

                img = img.Resize(1.25, Inter.Cubic);
                pictureBox1.Image = img.AsBitmap();
                AddImage(img, "Template resize");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void rotationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!imgList.ContainsKey("ROI Image"))
                {
                    MessageBox.Show("Please select a template");
                    return;
                }

                var img = new Bitmap(pictureBox1.Image);
                img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                pictureBox1.Image = img;
                AddImage(img.ToImage<Bgr, byte>(), "Template rotated");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void templateMatchingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void multiscaleTemplateMatchingToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private static VectorOfPoint ProccessImage(Image<Gray, byte> template, Image<Gray, byte> sceneImage)
        {
            try
            {
                VectorOfPoint finalPoints = new VectorOfPoint();
                Mat homography = null;

                VectorOfKeyPoint templateKeyPoints = new VectorOfKeyPoint();
                VectorOfKeyPoint sceneKeyPoints = new VectorOfKeyPoint();
                Mat templateDescriptor = new Mat();
                Mat sceneDescriptor = new Mat();

                Mat mask;
                int k = 2;
                double uniquenessthreshold = 0.8;
                VectorOfVectorOfDMatch matches = new VectorOfVectorOfDMatch();

                Brisk featureDectector = new Brisk();
                featureDectector.DetectAndCompute(template, null, templateKeyPoints, templateDescriptor, false);
                featureDectector.DetectAndCompute(sceneImage, null, sceneKeyPoints, sceneDescriptor, false);

                BFMatcher matcher = new BFMatcher(DistanceType.Hamming);
                matcher.Add(templateDescriptor);
                matcher.KnnMatch(sceneDescriptor, matches, k);

                mask = new Mat(matches.Size, 1, DepthType.Cv8U, 1);
                mask.SetTo(new MCvScalar(255));

                Features2DToolbox.VoteForUniqueness(matches, uniquenessthreshold, mask);

                int count = Features2DToolbox.VoteForSizeAndOrientation(templateKeyPoints, sceneKeyPoints, matches, mask, 1.5, 20);

                if (count >= 4)
                {
                    homography = Features2DToolbox.GetHomographyMatrixFromMatchedFeatures(templateKeyPoints, sceneKeyPoints, matches, mask, 5);
                }

                if (homography != null)
                {
                    Rectangle rect = new Rectangle(Point.Empty, template.Size);
                    PointF[] pts = new PointF[]
                    {
                new PointF(rect.Left, rect.Bottom),
                new PointF(rect.Right, rect.Bottom),
                new PointF(rect.Right, rect.Top),
                new PointF(rect.Left, rect.Top)
                    };

                    pts = CvInvoke.PerspectiveTransform(pts, homography);
                    Point[] points = Array.ConvertAll<PointF, Point>(pts, Point.Round);
                    finalPoints = new VectorOfPoint(points);
                }

                return finalPoints;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);    
            }
        }

        private static VectorOfPoint ProccessImageFLANN(Image<Gray, byte> template, Image<Gray, byte> sceneImage)
        {
            try
            {
                VectorOfPoint finalPoints = new VectorOfPoint();
                Mat homography = null;

                VectorOfKeyPoint templateKeyPoints = new VectorOfKeyPoint();
                VectorOfKeyPoint sceneKeyPoints = new VectorOfKeyPoint();
                Mat templateDescriptor = new Mat();
                Mat sceneDescriptor = new Mat();

                Mat mask;
                int k = 2;
                double uniquenessthreshold = 0.8;
                VectorOfVectorOfDMatch matches = new VectorOfVectorOfDMatch();

                KAZE featureDectector = new KAZE();
                featureDectector.DetectAndCompute(template, null, templateKeyPoints, templateDescriptor, false);
                featureDectector.DetectAndCompute(sceneImage, null, sceneKeyPoints, sceneDescriptor, false);

                KdTreeIndexParams id = new KdTreeIndexParams();
                SearchParams sp = new SearchParams();
                FlannBasedMatcher matcher = new FlannBasedMatcher(id, sp);




                matcher.Add(templateDescriptor);
                matcher.KnnMatch(sceneDescriptor, matches, k);

                mask = new Mat(matches.Size, 1, DepthType.Cv8U, 1);
                mask.SetTo(new MCvScalar(255));

                Features2DToolbox.VoteForUniqueness(matches, uniquenessthreshold, mask);

                int count = Features2DToolbox.VoteForSizeAndOrientation(templateKeyPoints, sceneKeyPoints, matches, mask, 1.5, 20);

                if (count >= 4)
                {
                    homography = Features2DToolbox.GetHomographyMatrixFromMatchedFeatures(templateKeyPoints, sceneKeyPoints, matches, mask, 5);
                }

                if (homography != null)
                {
                    Rectangle rect = new Rectangle(Point.Empty, template.Size);
                    PointF[] pts = new PointF[]
                    {
                new PointF(rect.Left, rect.Bottom),
                new PointF(rect.Right, rect.Bottom),
                new PointF(rect.Right, rect.Top),
                new PointF(rect.Left, rect.Top)
                    };

                    pts = CvInvoke.PerspectiveTransform(pts, homography);
                    Point[] points = Array.ConvertAll<PointF, Point>(pts, Point.Round);
                    finalPoints = new VectorOfPoint(points);
                }

                return finalPoints;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        private void fBMatchingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (pictureBox1.Image == null || rect == null)

                {
                    return;
                }

                var imgScene = imgList["Input"].Clone();
                var template = new Bitmap(pictureBox1.Image).ToImage<Gray, byte>();

                Stopwatch stopwatch = Stopwatch.StartNew();
                var vp = ProccessImage(template, imgScene.Convert<Gray, byte>());

                if (vp != null)
                {
                    CvInvoke.Polylines(imgScene, vp, true, new MCvScalar(0, 0, 255), 5);
                }

                pictureBox1.Image = imgScene.AsBitmap();
                stopwatch.Stop();
                Console.WriteLine($"Time for BF feature matching: {stopwatch.Elapsed.TotalMilliseconds} ms");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void fLANNMatcherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (pictureBox1.Image == null || rect == null)

                {
                    return;
                }

                var imgScene = imgList["Input"].Clone();
                var template = new Bitmap(pictureBox1.Image).ToImage<Gray, byte>();
                Stopwatch stopwatch = Stopwatch.StartNew();
                var vp = ProccessImage(template, imgScene.Convert<Gray, byte>());

                if (vp != null)
                {
                    CvInvoke.Polylines(imgScene, vp, true, new MCvScalar(0, 0, 255), 5);
                    stopwatch.Stop();
                    Console.WriteLine($"Time for FLANN feature matching: {stopwatch.Elapsed.TotalMilliseconds} ms");
                }

                pictureBox1.Image = imgScene.AsBitmap();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void rotationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!imgList.ContainsKey("ROI Image"))
                {
                    MessageBox.Show("Please select a template");
                    return;
                }

                        var img = new Bitmap(pictureBox1.Image).ToImage<Bgr, byte>();

                img = img.Rotate(45, new Bgr(0, 0, 0), false);
                pictureBox1.Image = img.AsBitmap();
                AddImage(img, "Template roatated");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void multiscaleTemplateMatchingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (pictureBox1.Image == null || rect == null)
                { return; }
                var imgScene = imgList["Input"].Clone();
                var template = new Bitmap(pictureBox1.Image).ToImage<Bgr, byte>();
                Rectangle r = Rectangle.Empty;
                double GlobalminVal = float.MaxValue;

                for (float scale = 0.5f; scale <= 1.5; scale += 0.25f )
                {
                    var temp = template.Resize(scale, Inter.Cubic);
                    Mat imgout = new Mat();
                    CvInvoke.MatchTemplate(imgScene, temp, imgout, TemplateMatchingType.Sqdiff);

                    double minval = 0;
                    double maxval = 0;
                    Point minloc = new Point();
                    Point maxloc = new Point();

                    CvInvoke.MinMaxLoc(imgout, ref minval, ref maxval, ref minloc, ref maxloc);

                    double prob = minval/(imgout.ToImage<Gray, byte>().GetSum().Intensity);

                    if (prob < GlobalminVal)
                    {
                        GlobalminVal = prob;
                        r = new Rectangle(minloc, temp.Size);
                    }    
                }

                if (r != null)
                {
                    CvInvoke.Rectangle(imgScene, r, new MCvScalar(255, 0, 0), 3);
                    pictureBox1.Image= imgScene.AsBitmap(); 
                }    
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        private void AddImage(Image<Bgr, byte> img, string keyname)
        {
            if (!treeView1.Nodes.ContainsKey(keyname))
            {
                TreeNode node = new TreeNode(keyname);
                node.Name = keyname;
                treeView1.Nodes.Add(node);
                treeView1.SelectedNode = node;
            }
            if(!imgList.ContainsKey(keyname))
            {
                imgList.Add(keyname, img);
            }
            else
            {
                imgList[keyname] = img; 
            }
        }




    }
}
