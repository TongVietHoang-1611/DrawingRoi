using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using System.Collections;

namespace DrawingRoi
{
    public partial class Form1 : Form
    {
        Dictionary<string, Image<Bgr, byte>> imgList;
        Rectangle rect;
        Point StartROI, EndROI;
        bool Selecting, MouseDown;
        
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

        public Form1()
        {
            InitializeComponent();
            Selecting = false;
            rect = Rectangle.Empty;
            imgList = new Dictionary<string, Image<Bgr, byte>>();
        }


    }
}
