
namespace RdsSharp.Generator
{
    partial class SegmentEditorForm
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
            this.fieldLength = new System.Windows.Forms.NumericUpDown();
            this.fieldOffset = new System.Windows.Forms.NumericUpDown();
            this.fieldType = new System.Windows.Forms.ComboBox();
            this.fieldName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fieldLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldOffset)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // fieldLength
            // 
            this.fieldLength.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fieldLength.Location = new System.Drawing.Point(85, 59);
            this.fieldLength.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.fieldLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.fieldLength.Name = "fieldLength";
            this.fieldLength.Size = new System.Drawing.Size(327, 20);
            this.fieldLength.TabIndex = 1;
            this.fieldLength.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.fieldLength.ValueChanged += new System.EventHandler(this.fieldLength_ValueChanged);
            // 
            // fieldOffset
            // 
            this.fieldOffset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fieldOffset.Location = new System.Drawing.Point(85, 33);
            this.fieldOffset.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.fieldOffset.Name = "fieldOffset";
            this.fieldOffset.Size = new System.Drawing.Size(327, 20);
            this.fieldOffset.TabIndex = 2;
            this.fieldOffset.ValueChanged += new System.EventHandler(this.fieldOffset_ValueChanged);
            // 
            // fieldType
            // 
            this.fieldType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fieldType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fieldType.FormattingEnabled = true;
            this.fieldType.Items.AddRange(new object[] {
            "Int",
            "Char",
            "Bool"});
            this.fieldType.Location = new System.Drawing.Point(85, 85);
            this.fieldType.Name = "fieldType";
            this.fieldType.Size = new System.Drawing.Size(327, 21);
            this.fieldType.TabIndex = 3;
            this.fieldType.SelectedIndexChanged += new System.EventHandler(this.fieldType_SelectedIndexChanged);
            // 
            // fieldName
            // 
            this.fieldName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fieldName.Location = new System.Drawing.Point(85, 7);
            this.fieldName.Name = "fieldName";
            this.fieldName.Size = new System.Drawing.Size(327, 20);
            this.fieldName.TabIndex = 4;
            this.fieldName.TextChanged += new System.EventHandler(this.fieldName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Bit Offset";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Bit Length";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Type";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(337, 143);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(256, 143);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // SegmentEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 178);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fieldName);
            this.Controls.Add(this.fieldType);
            this.Controls.Add(this.fieldOffset);
            this.Controls.Add(this.fieldLength);
            this.Controls.Add(this.label1);
            this.Name = "SegmentEditorForm";
            this.Text = "SegmentEditorForm";
            this.Load += new System.EventHandler(this.SegmentEditorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fieldLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldOffset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown fieldLength;
        private System.Windows.Forms.NumericUpDown fieldOffset;
        private System.Windows.Forms.ComboBox fieldType;
        private System.Windows.Forms.TextBox fieldName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
    }
}