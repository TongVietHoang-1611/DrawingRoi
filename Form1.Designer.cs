namespace DrawingRoi
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processROIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectROIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectRegionROIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.templateMatchingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matchingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.multiscaleTemplateMatchingToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.multiscaleTemplateMatchingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ulityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.fBMatchingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fLANNMatcherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotationToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.processToolStripMenuItem,
            this.ulityToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // processToolStripMenuItem
            // 
            this.processToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.processROIToolStripMenuItem,
            this.templateMatchingToolStripMenuItem,
            this.multiscaleTemplateMatchingToolStripMenuItem});
            this.processToolStripMenuItem.Name = "processToolStripMenuItem";
            this.processToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.processToolStripMenuItem.Text = "Process";
            // 
            // processROIToolStripMenuItem
            // 
            this.processROIToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectROIToolStripMenuItem,
            this.selectRegionROIToolStripMenuItem});
            this.processROIToolStripMenuItem.Name = "processROIToolStripMenuItem";
            this.processROIToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.processROIToolStripMenuItem.Text = "Process ROI";
            // 
            // selectROIToolStripMenuItem
            // 
            this.selectROIToolStripMenuItem.Name = "selectROIToolStripMenuItem";
            this.selectROIToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.selectROIToolStripMenuItem.Text = "Select ROI";
            this.selectROIToolStripMenuItem.Click += new System.EventHandler(this.selectROIToolStripMenuItem_Click);
            // 
            // selectRegionROIToolStripMenuItem
            // 
            this.selectRegionROIToolStripMenuItem.Name = "selectRegionROIToolStripMenuItem";
            this.selectRegionROIToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.selectRegionROIToolStripMenuItem.Text = "Select region ROI";
            this.selectRegionROIToolStripMenuItem.Click += new System.EventHandler(this.selectRegionROIToolStripMenuItem_Click);
            // 
            // templateMatchingToolStripMenuItem
            // 
            this.templateMatchingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.matchingToolStripMenuItem,
            this.multiscaleTemplateMatchingToolStripMenuItem1});
            this.templateMatchingToolStripMenuItem.Name = "templateMatchingToolStripMenuItem";
            this.templateMatchingToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.templateMatchingToolStripMenuItem.Text = "Template Matching";
            this.templateMatchingToolStripMenuItem.Click += new System.EventHandler(this.templateMatchingToolStripMenuItem_Click);
            // 
            // matchingToolStripMenuItem
            // 
            this.matchingToolStripMenuItem.Name = "matchingToolStripMenuItem";
            this.matchingToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.matchingToolStripMenuItem.Text = "Matching";
            this.matchingToolStripMenuItem.Click += new System.EventHandler(this.matchingToolStripMenuItem_Click);
            // 
            // multiscaleTemplateMatchingToolStripMenuItem1
            // 
            this.multiscaleTemplateMatchingToolStripMenuItem1.Name = "multiscaleTemplateMatchingToolStripMenuItem1";
            this.multiscaleTemplateMatchingToolStripMenuItem1.Size = new System.Drawing.Size(238, 22);
            this.multiscaleTemplateMatchingToolStripMenuItem1.Text = "Multi-scale Template Matching";
            this.multiscaleTemplateMatchingToolStripMenuItem1.Click += new System.EventHandler(this.multiscaleTemplateMatchingToolStripMenuItem1_Click);
            // 
            // multiscaleTemplateMatchingToolStripMenuItem
            // 
            this.multiscaleTemplateMatchingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fBMatchingToolStripMenuItem,
            this.fLANNMatcherToolStripMenuItem});
            this.multiscaleTemplateMatchingToolStripMenuItem.Name = "multiscaleTemplateMatchingToolStripMenuItem";
            this.multiscaleTemplateMatchingToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.multiscaleTemplateMatchingToolStripMenuItem.Text = "Feature Matching";
            this.multiscaleTemplateMatchingToolStripMenuItem.Click += new System.EventHandler(this.multiscaleTemplateMatchingToolStripMenuItem_Click);
            // 
            // ulityToolStripMenuItem
            // 
            this.ulityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.transformationToolStripMenuItem});
            this.ulityToolStripMenuItem.Name = "ulityToolStripMenuItem";
            this.ulityToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.ulityToolStripMenuItem.Text = "Utility";
            // 
            // transformationToolStripMenuItem
            // 
            this.transformationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resizeToolStripMenuItem,
            this.rotationToolStripMenuItem,
            this.rotationToolStripMenuItem1});
            this.transformationToolStripMenuItem.Name = "transformationToolStripMenuItem";
            this.transformationToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.transformationToolStripMenuItem.Text = "Transformation";
            // 
            // resizeToolStripMenuItem
            // 
            this.resizeToolStripMenuItem.Name = "resizeToolStripMenuItem";
            this.resizeToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.resizeToolStripMenuItem.Text = "Resize";
            this.resizeToolStripMenuItem.Click += new System.EventHandler(this.resizeToolStripMenuItem_Click);
            // 
            // rotationToolStripMenuItem
            // 
            this.rotationToolStripMenuItem.Name = "rotationToolStripMenuItem";
            this.rotationToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.rotationToolStripMenuItem.Text = "RotationFlip";
            this.rotationToolStripMenuItem.Click += new System.EventHandler(this.rotationToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 426);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.treeView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(130, 420);
            this.panel1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(130, 420);
            this.treeView1.TabIndex = 0;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(139, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(658, 420);
            this.panel2.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.pictureBox1.Size = new System.Drawing.Size(658, 420);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // fBMatchingToolStripMenuItem
            // 
            this.fBMatchingToolStripMenuItem.Name = "fBMatchingToolStripMenuItem";
            this.fBMatchingToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.fBMatchingToolStripMenuItem.Text = "BF Matcher";
            this.fBMatchingToolStripMenuItem.Click += new System.EventHandler(this.fBMatchingToolStripMenuItem_Click);
            // 
            // fLANNMatcherToolStripMenuItem
            // 
            this.fLANNMatcherToolStripMenuItem.Name = "fLANNMatcherToolStripMenuItem";
            this.fLANNMatcherToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.fLANNMatcherToolStripMenuItem.Text = "FLANN Matcher";
            this.fLANNMatcherToolStripMenuItem.Click += new System.EventHandler(this.fLANNMatcherToolStripMenuItem_Click);
            // 
            // rotationToolStripMenuItem1
            // 
            this.rotationToolStripMenuItem1.Name = "rotationToolStripMenuItem1";
            this.rotationToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.rotationToolStripMenuItem1.Text = "Rotation";
            this.rotationToolStripMenuItem1.Click += new System.EventHandler(this.rotationToolStripMenuItem1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem processToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem processROIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectROIToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectRegionROIToolStripMenuItem;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem templateMatchingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem matchingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ulityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem multiscaleTemplateMatchingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem multiscaleTemplateMatchingToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fBMatchingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fLANNMatcherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotationToolStripMenuItem1;
    }
}

