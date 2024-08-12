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
