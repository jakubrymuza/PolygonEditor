namespace GK_proj1
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ModeLabel = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.FixedRadiusTextBox = new System.Windows.Forms.TextBox();
            this.FixedRadiusButton = new System.Windows.Forms.Button();
            this.FixedLengthTextBox = new System.Windows.Forms.TextBox();
            this.FixedLengthButton = new System.Windows.Forms.Button();
            this.GenereatePredefinedSceneButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.AutoTangnetCheckBox = new System.Windows.Forms.CheckBox();
            this.TangentButton = new System.Windows.Forms.Button();
            this.DeleteRelationButton = new System.Windows.Forms.Button();
            this.PerpendicularEdgesButton = new System.Windows.Forms.Button();
            this.FixedPointButton = new System.Windows.Forms.Button();
            this.EqualSizeEdgesButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DragPolygonButton = new System.Windows.Forms.Button();
            this.DeletePointButton = new System.Windows.Forms.Button();
            this.DivideEdgeButton = new System.Windows.Forms.Button();
            this.NewCircleButton = new System.Windows.Forms.Button();
            this.NewPolygonButton = new System.Windows.Forms.Button();
            this.MyPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MyPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ModeLabel);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Controls.Add(this.GenereatePredefinedSceneButton);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.MyPictureBox);
            this.splitContainer1.Size = new System.Drawing.Size(856, 456);
            this.splitContainer1.SplitterDistance = 144;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            // 
            // ModeLabel
            // 
            this.ModeLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ModeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ModeLabel.Location = new System.Drawing.Point(13, 513);
            this.ModeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ModeLabel.Name = "ModeLabel";
            this.ModeLabel.Size = new System.Drawing.Size(133, 26);
            this.ModeLabel.TabIndex = 7;
            this.ModeLabel.Text = "Mode";
            this.ModeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.FixedRadiusTextBox);
            this.groupBox3.Controls.Add(this.FixedRadiusButton);
            this.groupBox3.Controls.Add(this.FixedLengthTextBox);
            this.groupBox3.Controls.Add(this.FixedLengthButton);
            this.groupBox3.Location = new System.Drawing.Point(13, 337);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(133, 123);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            // 
            // FixedRadiusTextBox
            // 
            this.FixedRadiusTextBox.Location = new System.Drawing.Point(8, 89);
            this.FixedRadiusTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.FixedRadiusTextBox.Name = "FixedRadiusTextBox";
            this.FixedRadiusTextBox.Size = new System.Drawing.Size(123, 20);
            this.FixedRadiusTextBox.TabIndex = 8;
            // 
            // FixedRadiusButton
            // 
            this.FixedRadiusButton.Location = new System.Drawing.Point(8, 63);
            this.FixedRadiusButton.Margin = new System.Windows.Forms.Padding(2);
            this.FixedRadiusButton.Name = "FixedRadiusButton";
            this.FixedRadiusButton.Size = new System.Drawing.Size(121, 22);
            this.FixedRadiusButton.TabIndex = 7;
            this.FixedRadiusButton.Text = "Fixed Radius";
            this.FixedRadiusButton.UseVisualStyleBackColor = true;
            this.FixedRadiusButton.Click += new System.EventHandler(this.FixedRadiusButton_Click);
            // 
            // FixedLengthTextBox
            // 
            this.FixedLengthTextBox.Location = new System.Drawing.Point(8, 42);
            this.FixedLengthTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.FixedLengthTextBox.Name = "FixedLengthTextBox";
            this.FixedLengthTextBox.Size = new System.Drawing.Size(123, 20);
            this.FixedLengthTextBox.TabIndex = 6;
            // 
            // FixedLengthButton
            // 
            this.FixedLengthButton.Location = new System.Drawing.Point(8, 16);
            this.FixedLengthButton.Margin = new System.Windows.Forms.Padding(2);
            this.FixedLengthButton.Name = "FixedLengthButton";
            this.FixedLengthButton.Size = new System.Drawing.Size(121, 22);
            this.FixedLengthButton.TabIndex = 0;
            this.FixedLengthButton.Text = "Fixed Length";
            this.FixedLengthButton.UseVisualStyleBackColor = true;
            this.FixedLengthButton.Click += new System.EventHandler(this.FixedLengthButton_Click);
            // 
            // GenereatePredefinedSceneButton
            // 
            this.GenereatePredefinedSceneButton.Location = new System.Drawing.Point(13, 471);
            this.GenereatePredefinedSceneButton.Margin = new System.Windows.Forms.Padding(2);
            this.GenereatePredefinedSceneButton.Name = "GenereatePredefinedSceneButton";
            this.GenereatePredefinedSceneButton.Size = new System.Drawing.Size(133, 22);
            this.GenereatePredefinedSceneButton.TabIndex = 5;
            this.GenereatePredefinedSceneButton.Text = "Generate Predefined Scene";
            this.GenereatePredefinedSceneButton.UseVisualStyleBackColor = true;
            this.GenereatePredefinedSceneButton.Click += new System.EventHandler(this.GenereatePredefinedSceneButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.AutoTangnetCheckBox);
            this.groupBox2.Controls.Add(this.TangentButton);
            this.groupBox2.Controls.Add(this.DeleteRelationButton);
            this.groupBox2.Controls.Add(this.PerpendicularEdgesButton);
            this.groupBox2.Controls.Add(this.FixedPointButton);
            this.groupBox2.Controls.Add(this.EqualSizeEdgesButton);
            this.groupBox2.Location = new System.Drawing.Point(13, 168);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(133, 181);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // AutoTangnetCheckBox
            // 
            this.AutoTangnetCheckBox.Checked = true;
            this.AutoTangnetCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoTangnetCheckBox.Location = new System.Drawing.Point(5, 147);
            this.AutoTangnetCheckBox.Name = "AutoTangnetCheckBox";
            this.AutoTangnetCheckBox.Size = new System.Drawing.Size(125, 22);
            this.AutoTangnetCheckBox.TabIndex = 1;
            this.AutoTangnetCheckBox.Text = "Auto Tangent";
            this.AutoTangnetCheckBox.UseVisualStyleBackColor = true;
            this.AutoTangnetCheckBox.CheckedChanged += new System.EventHandler(this.AutoTangnetCheckBox_CheckedChanged);
            // 
            // TangentButton
            // 
            this.TangentButton.Location = new System.Drawing.Point(5, 94);
            this.TangentButton.Margin = new System.Windows.Forms.Padding(2);
            this.TangentButton.Name = "TangentButton";
            this.TangentButton.Size = new System.Drawing.Size(125, 22);
            this.TangentButton.TabIndex = 5;
            this.TangentButton.Text = "Tangent";
            this.TangentButton.UseVisualStyleBackColor = true;
            this.TangentButton.Click += new System.EventHandler(this.TangentButton_Click);
            // 
            // DeleteRelationButton
            // 
            this.DeleteRelationButton.Location = new System.Drawing.Point(5, 120);
            this.DeleteRelationButton.Margin = new System.Windows.Forms.Padding(2);
            this.DeleteRelationButton.Name = "DeleteRelationButton";
            this.DeleteRelationButton.Size = new System.Drawing.Size(125, 22);
            this.DeleteRelationButton.TabIndex = 4;
            this.DeleteRelationButton.Text = "Delete Relation";
            this.DeleteRelationButton.UseVisualStyleBackColor = true;
            this.DeleteRelationButton.Click += new System.EventHandler(this.DeleteRelationButton_Click);
            // 
            // PerpendicularEdgesButton
            // 
            this.PerpendicularEdgesButton.Location = new System.Drawing.Point(5, 68);
            this.PerpendicularEdgesButton.Margin = new System.Windows.Forms.Padding(2);
            this.PerpendicularEdgesButton.Name = "PerpendicularEdgesButton";
            this.PerpendicularEdgesButton.Size = new System.Drawing.Size(125, 22);
            this.PerpendicularEdgesButton.TabIndex = 3;
            this.PerpendicularEdgesButton.Text = "Perpendicular Edges";
            this.PerpendicularEdgesButton.UseVisualStyleBackColor = true;
            this.PerpendicularEdgesButton.Click += new System.EventHandler(this.PerpendicularEdgesButton_Click);
            // 
            // FixedPointButton
            // 
            this.FixedPointButton.Location = new System.Drawing.Point(5, 42);
            this.FixedPointButton.Margin = new System.Windows.Forms.Padding(2);
            this.FixedPointButton.Name = "FixedPointButton";
            this.FixedPointButton.Size = new System.Drawing.Size(125, 22);
            this.FixedPointButton.TabIndex = 2;
            this.FixedPointButton.Text = "Fixed Point";
            this.FixedPointButton.UseVisualStyleBackColor = true;
            this.FixedPointButton.Click += new System.EventHandler(this.FixedPointButton_Click);
            // 
            // EqualSizeEdgesButton
            // 
            this.EqualSizeEdgesButton.Location = new System.Drawing.Point(5, 16);
            this.EqualSizeEdgesButton.Margin = new System.Windows.Forms.Padding(2);
            this.EqualSizeEdgesButton.Name = "EqualSizeEdgesButton";
            this.EqualSizeEdgesButton.Size = new System.Drawing.Size(125, 22);
            this.EqualSizeEdgesButton.TabIndex = 1;
            this.EqualSizeEdgesButton.Text = "Equal Size Edges";
            this.EqualSizeEdgesButton.UseVisualStyleBackColor = true;
            this.EqualSizeEdgesButton.Click += new System.EventHandler(this.EqualLengthEdgesButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DragPolygonButton);
            this.groupBox1.Controls.Add(this.DeletePointButton);
            this.groupBox1.Controls.Add(this.DivideEdgeButton);
            this.groupBox1.Controls.Add(this.NewCircleButton);
            this.groupBox1.Controls.Add(this.NewPolygonButton);
            this.groupBox1.Location = new System.Drawing.Point(13, 8);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(133, 156);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // DragPolygonButton
            // 
            this.DragPolygonButton.Location = new System.Drawing.Point(5, 127);
            this.DragPolygonButton.Margin = new System.Windows.Forms.Padding(2);
            this.DragPolygonButton.Name = "DragPolygonButton";
            this.DragPolygonButton.Size = new System.Drawing.Size(125, 22);
            this.DragPolygonButton.TabIndex = 4;
            this.DragPolygonButton.Text = "Drag Polygon";
            this.DragPolygonButton.UseVisualStyleBackColor = true;
            this.DragPolygonButton.Click += new System.EventHandler(this.DragPolygonButton_Click);
            // 
            // DeletePointButton
            // 
            this.DeletePointButton.Location = new System.Drawing.Point(5, 101);
            this.DeletePointButton.Margin = new System.Windows.Forms.Padding(2);
            this.DeletePointButton.Name = "DeletePointButton";
            this.DeletePointButton.Size = new System.Drawing.Size(125, 22);
            this.DeletePointButton.TabIndex = 3;
            this.DeletePointButton.Text = "Delete Point";
            this.DeletePointButton.UseVisualStyleBackColor = true;
            this.DeletePointButton.Click += new System.EventHandler(this.DeletePointButton_Click);
            // 
            // DivideEdgeButton
            // 
            this.DivideEdgeButton.Location = new System.Drawing.Point(5, 75);
            this.DivideEdgeButton.Margin = new System.Windows.Forms.Padding(2);
            this.DivideEdgeButton.Name = "DivideEdgeButton";
            this.DivideEdgeButton.Size = new System.Drawing.Size(125, 22);
            this.DivideEdgeButton.TabIndex = 2;
            this.DivideEdgeButton.Text = "Divide Edge";
            this.DivideEdgeButton.UseVisualStyleBackColor = true;
            this.DivideEdgeButton.Click += new System.EventHandler(this.DivideEdgeButton_Click);
            // 
            // NewCircleButton
            // 
            this.NewCircleButton.Location = new System.Drawing.Point(5, 49);
            this.NewCircleButton.Margin = new System.Windows.Forms.Padding(2);
            this.NewCircleButton.Name = "NewCircleButton";
            this.NewCircleButton.Size = new System.Drawing.Size(125, 22);
            this.NewCircleButton.TabIndex = 1;
            this.NewCircleButton.Text = "Create New Circle";
            this.NewCircleButton.UseVisualStyleBackColor = true;
            this.NewCircleButton.Click += new System.EventHandler(this.CreateNewCircle_Click);
            // 
            // NewPolygonButton
            // 
            this.NewPolygonButton.Location = new System.Drawing.Point(5, 23);
            this.NewPolygonButton.Margin = new System.Windows.Forms.Padding(2);
            this.NewPolygonButton.Name = "NewPolygonButton";
            this.NewPolygonButton.Size = new System.Drawing.Size(125, 22);
            this.NewPolygonButton.TabIndex = 0;
            this.NewPolygonButton.Text = "Create New Polygon";
            this.NewPolygonButton.UseVisualStyleBackColor = true;
            this.NewPolygonButton.Click += new System.EventHandler(this.NewPolygonButton_Click);
            // 
            // MyPictureBox
            // 
            this.MyPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MyPictureBox.Location = new System.Drawing.Point(0, 0);
            this.MyPictureBox.Name = "MyPictureBox";
            this.MyPictureBox.Size = new System.Drawing.Size(709, 456);
            this.MyPictureBox.TabIndex = 0;
            this.MyPictureBox.TabStop = false;
            this.MyPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.MyPictureBox_Paint);
            this.MyPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MyPictureBox_MouseDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 456);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GK proj1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MyPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button NewCircleButton;
        private System.Windows.Forms.Button NewPolygonButton;
        private System.Windows.Forms.PictureBox MyPictureBox;
        private System.Windows.Forms.Button DeletePointButton;
        private System.Windows.Forms.Button DivideEdgeButton;
        private System.Windows.Forms.Button DragPolygonButton;
        private System.Windows.Forms.Button GenereatePredefinedSceneButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button DeleteRelationButton;
        private System.Windows.Forms.Button PerpendicularEdgesButton;
        private System.Windows.Forms.Button FixedPointButton;
        private System.Windows.Forms.Button EqualSizeEdgesButton;
        private System.Windows.Forms.Button FixedLengthButton;
        private System.Windows.Forms.Button TangentButton;
        private System.Windows.Forms.TextBox FixedLengthTextBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox FixedRadiusTextBox;
        private System.Windows.Forms.Button FixedRadiusButton;
        private System.Windows.Forms.Label ModeLabel;
        private System.Windows.Forms.CheckBox AutoTangnetCheckBox;
    }
}

