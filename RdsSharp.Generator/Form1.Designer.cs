
namespace RdsSharp.Generator
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
            this.label1 = new System.Windows.Forms.Label();
            this.opcodeBox = new System.Windows.Forms.ComboBox();
            this.versionBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.layoutList = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.inheritedBox = new System.Windows.Forms.ComboBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.byteLayoutView1 = new RdsSharp.Generator.ByteLayoutView();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(323, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Opcode";
            // 
            // opcodeBox
            // 
            this.opcodeBox.FormattingEnabled = true;
            this.opcodeBox.Items.AddRange(new object[] {
            "0000",
            "0001",
            "0010",
            "0011",
            "0100",
            "0101",
            "0110",
            "0111",
            "1000",
            "1001",
            "1010",
            "1011",
            "1100",
            "1101",
            "1110",
            "1111"});
            this.opcodeBox.Location = new System.Drawing.Point(326, 29);
            this.opcodeBox.Name = "opcodeBox";
            this.opcodeBox.Size = new System.Drawing.Size(104, 21);
            this.opcodeBox.TabIndex = 3;
            this.opcodeBox.SelectedIndexChanged += new System.EventHandler(this.opcodeBox_SelectedIndexChanged);
            // 
            // versionBox
            // 
            this.versionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.versionBox.FormattingEnabled = true;
            this.versionBox.Items.AddRange(new object[] {
            "A",
            "B",
            "A & B"});
            this.versionBox.Location = new System.Drawing.Point(436, 29);
            this.versionBox.Name = "versionBox";
            this.versionBox.Size = new System.Drawing.Size(62, 21);
            this.versionBox.TabIndex = 4;
            this.versionBox.SelectedIndexChanged += new System.EventHandler(this.versionBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(433, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Version";
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(197, 29);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(123, 20);
            this.nameBox.TabIndex = 6;
            this.nameBox.TextChanged += new System.EventHandler(this.nameBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(194, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Name";
            // 
            // layoutList
            // 
            this.layoutList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.layoutList.FormattingEnabled = true;
            this.layoutList.IntegralHeight = false;
            this.layoutList.Location = new System.Drawing.Point(12, 12);
            this.layoutList.Name = "layoutList";
            this.layoutList.Size = new System.Drawing.Size(179, 298);
            this.layoutList.TabIndex = 8;
            this.layoutList.SelectedIndexChanged += new System.EventHandler(this.layoutList_SelectedIndexChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(12, 316);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(179, 23);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "New";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(12, 345);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(179, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save...";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoad.Location = new System.Drawing.Point(12, 374);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(179, 23);
            this.btnLoad.TabIndex = 11;
            this.btnLoad.Text = "Load...";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(501, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Inherited";
            // 
            // inheritedBox
            // 
            this.inheritedBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inheritedBox.FormattingEnabled = true;
            this.inheritedBox.Location = new System.Drawing.Point(504, 29);
            this.inheritedBox.Name = "inheritedBox";
            this.inheritedBox.Size = new System.Drawing.Size(121, 21);
            this.inheritedBox.TabIndex = 13;
            this.inheritedBox.SelectedIndexChanged += new System.EventHandler(this.inheritedBox_SelectedIndexChanged);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGenerate.Location = new System.Drawing.Point(12, 403);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(179, 23);
            this.btnGenerate.TabIndex = 14;
            this.btnGenerate.Text = "Generate Code...";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // byteLayoutView1
            // 
            this.byteLayoutView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.byteLayoutView1.Location = new System.Drawing.Point(197, 55);
            this.byteLayoutView1.Name = "byteLayoutView1";
            this.byteLayoutView1.Size = new System.Drawing.Size(633, 371);
            this.byteLayoutView1.TabIndex = 0;
            this.byteLayoutView1.Text = "byteLayoutView1";
            this.byteLayoutView1.OnSegmentClicked += new RdsSharp.Generator.ByteLayoutView_OnSegmentClickedArgs(this.byteLayoutView1_OnSegmentClicked);
            this.byteLayoutView1.OnCellClicked += new RdsSharp.Generator.ByteLayoutView_OnCellClickedArgs(this.byteLayoutView1_OnCellClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 438);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.inheritedBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.layoutList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.versionBox);
            this.Controls.Add(this.opcodeBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.byteLayoutView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ByteLayoutView byteLayoutView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox opcodeBox;
        private System.Windows.Forms.ComboBox versionBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox layoutList;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox inheritedBox;
        private System.Windows.Forms.Button btnGenerate;
    }
}

