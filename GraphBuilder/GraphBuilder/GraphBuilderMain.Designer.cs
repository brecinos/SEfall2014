namespace GraphBuilder
{
    partial class MainFrm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbNullParent = new System.Windows.Forms.CheckBox();
            this.btnUpdateVertex = new System.Windows.Forms.Button();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbFloor = new System.Windows.Forms.ComboBox();
            this.cbDirection = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbParent = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtVertexName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnUpdateEdge = new System.Windows.Forms.Button();
            this.lblImgPath2 = new System.Windows.Forms.Label();
            this.lblImgPath1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btnLocateImg2 = new System.Windows.Forms.Button();
            this.btnLocateImg1 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.edgeImg2 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.edgeImg1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbEdgeVertex2 = new System.Windows.Forms.ComboBox();
            this.cbEdgeVertex1 = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnDeleteVertex = new System.Windows.Forms.Button();
            this.btnNewVertex = new System.Windows.Forms.Button();
            this.lbVerticies = new System.Windows.Forms.ListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnDeleteEdge = new System.Windows.Forms.Button();
            this.btnNewEdge = new System.Windows.Forms.Button();
            this.lbEdges = new System.Windows.Forms.ListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lbVertexEdges = new System.Windows.Forms.ListBox();
            this.openPic1 = new System.Windows.Forms.OpenFileDialog();
            this.openPic2 = new System.Windows.Forms.OpenFileDialog();
            this.openXml = new System.Windows.Forms.OpenFileDialog();
            this.btnLoadXml = new System.Windows.Forms.Button();
            this.btnSaveXml = new System.Windows.Forms.Button();
            this.pnlMap = new System.Windows.Forms.Panel();
            this.cbMapFloor = new System.Windows.Forms.ComboBox();
            this.btnShowMap = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.saveXml = new System.Windows.Forms.SaveFileDialog();
            this.btnAhhh = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edgeImg2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edgeImg1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbNullParent);
            this.groupBox1.Controls.Add(this.btnUpdateVertex);
            this.groupBox1.Controls.Add(this.cbType);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtLength);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbFloor);
            this.groupBox1.Controls.Add(this.cbDirection);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbParent);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtVertexName);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(184, 494);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vertex";
            // 
            // cbNullParent
            // 
            this.cbNullParent.AutoSize = true;
            this.cbNullParent.Location = new System.Drawing.Point(85, 86);
            this.cbNullParent.Name = "cbNullParent";
            this.cbNullParent.Size = new System.Drawing.Size(78, 17);
            this.cbNullParent.TabIndex = 20;
            this.cbNullParent.Text = "Null Parent";
            this.cbNullParent.UseVisualStyleBackColor = true;
            // 
            // btnUpdateVertex
            // 
            this.btnUpdateVertex.Location = new System.Drawing.Point(58, 449);
            this.btnUpdateVertex.Name = "btnUpdateVertex";
            this.btnUpdateVertex.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateVertex.TabIndex = 19;
            this.btnUpdateVertex.Text = "Update";
            this.btnUpdateVertex.UseVisualStyleBackColor = true;
            this.btnUpdateVertex.Click += new System.EventHandler(this.btnUpdateVertex_Click);
            // 
            // cbType
            // 
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "room",
            "hall",
            "toilet_m",
            "toilet_f",
            "janitor",
            "exit",
            "door"});
            this.cbType.Location = new System.Drawing.Point(65, 229);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(100, 21);
            this.cbType.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 229);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Type";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 152);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Length";
            // 
            // txtLength
            // 
            this.txtLength.Location = new System.Drawing.Point(65, 149);
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(100, 20);
            this.txtLength.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 190);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Floor";
            // 
            // cbFloor
            // 
            this.cbFloor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFloor.FormattingEnabled = true;
            this.cbFloor.Items.AddRange(new object[] {
            "0.0",
            "0.25",
            "0.5",
            "0.75",
            "1.0",
            "1.25",
            "1.5",
            "1.75",
            "2.0",
            "2.25",
            "2.5",
            "2.75",
            "3.0",
            "3.25",
            "3.5",
            "3.75",
            "4.0"});
            this.cbFloor.Location = new System.Drawing.Point(65, 187);
            this.cbFloor.Name = "cbFloor";
            this.cbFloor.Size = new System.Drawing.Size(100, 21);
            this.cbFloor.TabIndex = 8;
            // 
            // cbDirection
            // 
            this.cbDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDirection.FormattingEnabled = true;
            this.cbDirection.Items.AddRange(new object[] {
            "n",
            "nw",
            "w",
            "sw",
            "s",
            "se",
            "e",
            "ne"});
            this.cbDirection.Location = new System.Drawing.Point(65, 111);
            this.cbDirection.Name = "cbDirection";
            this.cbDirection.Size = new System.Drawing.Size(100, 21);
            this.cbDirection.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Direction";
            // 
            // cbParent
            // 
            this.cbParent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbParent.DropDownWidth = 300;
            this.cbParent.FormattingEnabled = true;
            this.cbParent.Location = new System.Drawing.Point(65, 59);
            this.cbParent.Name = "cbParent";
            this.cbParent.Size = new System.Drawing.Size(100, 21);
            this.cbParent.TabIndex = 4;
            this.cbParent.SelectedIndexChanged += new System.EventHandler(this.cbParent_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Parent";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Name";
            // 
            // txtVertexName
            // 
            this.txtVertexName.Location = new System.Drawing.Point(65, 28);
            this.txtVertexName.Name = "txtVertexName";
            this.txtVertexName.Size = new System.Drawing.Size(100, 20);
            this.txtVertexName.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnUpdateEdge);
            this.groupBox2.Controls.Add(this.lblImgPath2);
            this.groupBox2.Controls.Add(this.lblImgPath1);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.btnLocateImg2);
            this.groupBox2.Controls.Add(this.btnLocateImg1);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.edgeImg2);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.edgeImg1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cbEdgeVertex2);
            this.groupBox2.Controls.Add(this.cbEdgeVertex1);
            this.groupBox2.Location = new System.Drawing.Point(218, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 494);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Edge";
            // 
            // btnUpdateEdge
            // 
            this.btnUpdateEdge.Location = new System.Drawing.Point(59, 449);
            this.btnUpdateEdge.Name = "btnUpdateEdge";
            this.btnUpdateEdge.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateEdge.TabIndex = 18;
            this.btnUpdateEdge.Text = "Update";
            this.btnUpdateEdge.UseVisualStyleBackColor = true;
            this.btnUpdateEdge.Click += new System.EventHandler(this.btnUpdateEdge_Click);
            // 
            // lblImgPath2
            // 
            this.lblImgPath2.AutoSize = true;
            this.lblImgPath2.Location = new System.Drawing.Point(68, 371);
            this.lblImgPath2.Name = "lblImgPath2";
            this.lblImgPath2.Size = new System.Drawing.Size(0, 13);
            this.lblImgPath2.TabIndex = 17;
            // 
            // lblImgPath1
            // 
            this.lblImgPath1.AutoSize = true;
            this.lblImgPath1.Location = new System.Drawing.Point(69, 337);
            this.lblImgPath1.Name = "lblImgPath1";
            this.lblImgPath1.Size = new System.Drawing.Size(0, 13);
            this.lblImgPath1.TabIndex = 16;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 371);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(42, 13);
            this.label14.TabIndex = 15;
            this.label14.Text = "Image2";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 337);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(42, 13);
            this.label15.TabIndex = 14;
            this.label15.Text = "Image1";
            // 
            // btnLocateImg2
            // 
            this.btnLocateImg2.Location = new System.Drawing.Point(74, 301);
            this.btnLocateImg2.Name = "btnLocateImg2";
            this.btnLocateImg2.Size = new System.Drawing.Size(120, 23);
            this.btnLocateImg2.TabIndex = 13;
            this.btnLocateImg2.Text = "Locate...";
            this.btnLocateImg2.UseVisualStyleBackColor = true;
            this.btnLocateImg2.Click += new System.EventHandler(this.btnLocateImg2_Click);
            // 
            // btnLocateImg1
            // 
            this.btnLocateImg1.Location = new System.Drawing.Point(73, 272);
            this.btnLocateImg1.Name = "btnLocateImg1";
            this.btnLocateImg1.Size = new System.Drawing.Size(120, 23);
            this.btnLocateImg1.TabIndex = 12;
            this.btnLocateImg1.Text = "Locate...";
            this.btnLocateImg1.UseVisualStyleBackColor = true;
            this.btnLocateImg1.Click += new System.EventHandler(this.btnLocateImg1_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 306);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Image2";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 272);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 13);
            this.label13.TabIndex = 9;
            this.label13.Text = "Image1";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 199);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "Image2";
            // 
            // edgeImg2
            // 
            this.edgeImg2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.edgeImg2.Location = new System.Drawing.Point(72, 181);
            this.edgeImg2.Name = "edgeImg2";
            this.edgeImg2.Size = new System.Drawing.Size(121, 58);
            this.edgeImg2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.edgeImg2.TabIndex = 6;
            this.edgeImg2.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 129);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Image1";
            // 
            // edgeImg1
            // 
            this.edgeImg1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.edgeImg1.Location = new System.Drawing.Point(73, 111);
            this.edgeImg1.Name = "edgeImg1";
            this.edgeImg1.Size = new System.Drawing.Size(121, 58);
            this.edgeImg1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.edgeImg1.TabIndex = 4;
            this.edgeImg1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Vertex2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Vertex1";
            // 
            // cbEdgeVertex2
            // 
            this.cbEdgeVertex2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEdgeVertex2.DropDownWidth = 300;
            this.cbEdgeVertex2.FormattingEnabled = true;
            this.cbEdgeVertex2.Location = new System.Drawing.Point(73, 69);
            this.cbEdgeVertex2.Name = "cbEdgeVertex2";
            this.cbEdgeVertex2.Size = new System.Drawing.Size(121, 21);
            this.cbEdgeVertex2.TabIndex = 1;
            // 
            // cbEdgeVertex1
            // 
            this.cbEdgeVertex1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEdgeVertex1.DropDownWidth = 300;
            this.cbEdgeVertex1.FormattingEnabled = true;
            this.cbEdgeVertex1.Location = new System.Drawing.Point(73, 31);
            this.cbEdgeVertex1.Name = "cbEdgeVertex1";
            this.cbEdgeVertex1.Size = new System.Drawing.Size(121, 21);
            this.cbEdgeVertex1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnDeleteVertex);
            this.groupBox3.Controls.Add(this.btnNewVertex);
            this.groupBox3.Controls.Add(this.lbVerticies);
            this.groupBox3.Location = new System.Drawing.Point(424, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(157, 494);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Verticies";
            // 
            // btnDeleteVertex
            // 
            this.btnDeleteVertex.Location = new System.Drawing.Point(21, 400);
            this.btnDeleteVertex.Name = "btnDeleteVertex";
            this.btnDeleteVertex.Size = new System.Drawing.Size(120, 23);
            this.btnDeleteVertex.TabIndex = 2;
            this.btnDeleteVertex.Text = "Delete Selected";
            this.btnDeleteVertex.UseVisualStyleBackColor = true;
            this.btnDeleteVertex.Click += new System.EventHandler(this.btnDeleteVertex_Click);
            // 
            // btnNewVertex
            // 
            this.btnNewVertex.Location = new System.Drawing.Point(21, 371);
            this.btnNewVertex.Name = "btnNewVertex";
            this.btnNewVertex.Size = new System.Drawing.Size(120, 23);
            this.btnNewVertex.TabIndex = 1;
            this.btnNewVertex.Text = "New";
            this.btnNewVertex.UseVisualStyleBackColor = true;
            this.btnNewVertex.Click += new System.EventHandler(this.btnNewVertex_Click);
            // 
            // lbVerticies
            // 
            this.lbVerticies.FormattingEnabled = true;
            this.lbVerticies.Location = new System.Drawing.Point(21, 17);
            this.lbVerticies.Name = "lbVerticies";
            this.lbVerticies.Size = new System.Drawing.Size(120, 329);
            this.lbVerticies.TabIndex = 0;
            this.lbVerticies.SelectedIndexChanged += new System.EventHandler(this.lbVerticies_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnDeleteEdge);
            this.groupBox4.Controls.Add(this.btnNewEdge);
            this.groupBox4.Controls.Add(this.lbEdges);
            this.groupBox4.Location = new System.Drawing.Point(606, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(136, 494);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Edges";
            // 
            // btnDeleteEdge
            // 
            this.btnDeleteEdge.Location = new System.Drawing.Point(13, 400);
            this.btnDeleteEdge.Name = "btnDeleteEdge";
            this.btnDeleteEdge.Size = new System.Drawing.Size(107, 23);
            this.btnDeleteEdge.TabIndex = 5;
            this.btnDeleteEdge.Text = "Delete Selected";
            this.btnDeleteEdge.UseVisualStyleBackColor = true;
            this.btnDeleteEdge.Click += new System.EventHandler(this.btnDeleteEdge_Click);
            // 
            // btnNewEdge
            // 
            this.btnNewEdge.Location = new System.Drawing.Point(13, 371);
            this.btnNewEdge.Name = "btnNewEdge";
            this.btnNewEdge.Size = new System.Drawing.Size(107, 23);
            this.btnNewEdge.TabIndex = 4;
            this.btnNewEdge.Text = "New";
            this.btnNewEdge.UseVisualStyleBackColor = true;
            this.btnNewEdge.Click += new System.EventHandler(this.btnNewEdge_Click);
            // 
            // lbEdges
            // 
            this.lbEdges.FormattingEnabled = true;
            this.lbEdges.Location = new System.Drawing.Point(6, 19);
            this.lbEdges.Name = "lbEdges";
            this.lbEdges.Size = new System.Drawing.Size(120, 329);
            this.lbEdges.TabIndex = 3;
            this.lbEdges.SelectedIndexChanged += new System.EventHandler(this.lbEdges_SelectedIndexChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lbVertexEdges);
            this.groupBox5.Location = new System.Drawing.Point(760, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(136, 494);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Vertex Edges";
            // 
            // lbVertexEdges
            // 
            this.lbVertexEdges.FormattingEnabled = true;
            this.lbVertexEdges.Location = new System.Drawing.Point(6, 19);
            this.lbVertexEdges.Name = "lbVertexEdges";
            this.lbVertexEdges.Size = new System.Drawing.Size(120, 329);
            this.lbVertexEdges.TabIndex = 3;
            // 
            // btnLoadXml
            // 
            this.btnLoadXml.Location = new System.Drawing.Point(31, 513);
            this.btnLoadXml.Name = "btnLoadXml";
            this.btnLoadXml.Size = new System.Drawing.Size(75, 23);
            this.btnLoadXml.TabIndex = 8;
            this.btnLoadXml.Text = "Load XML";
            this.btnLoadXml.UseVisualStyleBackColor = true;
            this.btnLoadXml.Click += new System.EventHandler(this.btnLoadXml_Click);
            // 
            // btnSaveXml
            // 
            this.btnSaveXml.Location = new System.Drawing.Point(113, 513);
            this.btnSaveXml.Name = "btnSaveXml";
            this.btnSaveXml.Size = new System.Drawing.Size(75, 23);
            this.btnSaveXml.TabIndex = 9;
            this.btnSaveXml.Text = "Save XML";
            this.btnSaveXml.UseVisualStyleBackColor = true;
            this.btnSaveXml.Click += new System.EventHandler(this.btnSaveXml_Click);
            // 
            // pnlMap
            // 
            this.pnlMap.BackColor = System.Drawing.Color.White;
            this.pnlMap.Location = new System.Drawing.Point(913, 31);
            this.pnlMap.Name = "pnlMap";
            this.pnlMap.Size = new System.Drawing.Size(527, 453);
            this.pnlMap.TabIndex = 10;
            this.pnlMap.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.pnlMap.Resize += new System.EventHandler(this.panel1_Resize);
            // 
            // cbMapFloor
            // 
            this.cbMapFloor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMapFloor.FormattingEnabled = true;
            this.cbMapFloor.Items.AddRange(new object[] {
            "0.0",
            "0.25",
            "0.5",
            "0.75",
            "1.0",
            "1.25",
            "1.5",
            "1.75",
            "2.0",
            "2.25",
            "2.5",
            "2.75",
            "3.0",
            "3.25",
            "3.5",
            "3.75",
            "4.0"});
            this.cbMapFloor.Location = new System.Drawing.Point(951, 4);
            this.cbMapFloor.Name = "cbMapFloor";
            this.cbMapFloor.Size = new System.Drawing.Size(100, 21);
            this.cbMapFloor.TabIndex = 11;
            this.cbMapFloor.SelectedIndexChanged += new System.EventHandler(this.cbMapFloor_SelectedIndexChanged);
            // 
            // btnShowMap
            // 
            this.btnShowMap.Location = new System.Drawing.Point(1183, 4);
            this.btnShowMap.Name = "btnShowMap";
            this.btnShowMap.Size = new System.Drawing.Size(75, 23);
            this.btnShowMap.TabIndex = 12;
            this.btnShowMap.Text = "Show Map";
            this.btnShowMap.UseVisualStyleBackColor = true;
            this.btnShowMap.Click += new System.EventHandler(this.btnShowMap_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(915, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Floor";
            // 
            // saveXml
            // 
            this.saveXml.DefaultExt = "xml";
            // 
            // btnAhhh
            // 
            this.btnAhhh.Location = new System.Drawing.Point(1350, 513);
            this.btnAhhh.Name = "btnAhhh";
            this.btnAhhh.Size = new System.Drawing.Size(75, 23);
            this.btnAhhh.TabIndex = 20;
            this.btnAhhh.Text = "Help";
            this.btnAhhh.UseVisualStyleBackColor = true;
            this.btnAhhh.Click += new System.EventHandler(this.btnAhhh_Click);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1448, 565);
            this.Controls.Add(this.btnAhhh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnShowMap);
            this.Controls.Add(this.cbMapFloor);
            this.Controls.Add(this.pnlMap);
            this.Controls.Add(this.btnSaveXml);
            this.Controls.Add(this.btnLoadXml);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainFrm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.GraphBuilderMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edgeImg2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edgeImg1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnUpdateVertex;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtLength;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbFloor;
        private System.Windows.Forms.ComboBox cbDirection;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbParent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtVertexName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnUpdateEdge;
        private System.Windows.Forms.Label lblImgPath2;
        private System.Windows.Forms.Label lblImgPath1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnLocateImg2;
        private System.Windows.Forms.Button btnLocateImg1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox edgeImg2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox edgeImg1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbEdgeVertex2;
        private System.Windows.Forms.ComboBox cbEdgeVertex1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnDeleteVertex;
        private System.Windows.Forms.Button btnNewVertex;
        private System.Windows.Forms.ListBox lbVerticies;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox lbEdges;
        private System.Windows.Forms.Button btnDeleteEdge;
        private System.Windows.Forms.Button btnNewEdge;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ListBox lbVertexEdges;
        private System.Windows.Forms.CheckBox cbNullParent;
        private System.Windows.Forms.OpenFileDialog openPic1;
        private System.Windows.Forms.OpenFileDialog openPic2;
        private System.Windows.Forms.OpenFileDialog openXml;
        private System.Windows.Forms.Button btnLoadXml;
        private System.Windows.Forms.Button btnSaveXml;
        private System.Windows.Forms.Panel pnlMap;
        private System.Windows.Forms.ComboBox cbMapFloor;
        private System.Windows.Forms.Button btnShowMap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SaveFileDialog saveXml;
        private System.Windows.Forms.Button btnAhhh;
    }
}

