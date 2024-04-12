namespace mid_Coonect.Tools
{
    partial class CoachBox
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelCoachName = new System.Windows.Forms.Label();
            this.labelGender = new System.Windows.Forms.Label();
            this.lbclassinfo = new System.Windows.Forms.Label();
            this.labelCourse = new System.Windows.Forms.Label();
            this.btnInfo = new System.Windows.Forms.Button();
            this.btnCourse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(127, 153);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // labelCoachName
            // 
            this.labelCoachName.AutoSize = true;
            this.labelCoachName.Font = new System.Drawing.Font("細明體-ExtB", 22.20561F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelCoachName.Location = new System.Drawing.Point(132, 52);
            this.labelCoachName.Name = "labelCoachName";
            this.labelCoachName.Size = new System.Drawing.Size(109, 30);
            this.labelCoachName.TabIndex = 1;
            this.labelCoachName.Text = "label1";
            // 
            // labelGender
            // 
            this.labelGender.AutoSize = true;
            this.labelGender.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelGender.Location = new System.Drawing.Point(134, 83);
            this.labelGender.Name = "labelGender";
            this.labelGender.Size = new System.Drawing.Size(54, 20);
            this.labelGender.TabIndex = 2;
            this.labelGender.Text = "label1";
            // 
            // lbclassinfo
            // 
            this.lbclassinfo.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbclassinfo.Location = new System.Drawing.Point(201, 130);
            this.lbclassinfo.Name = "lbclassinfo";
            this.lbclassinfo.Size = new System.Drawing.Size(326, 42);
            this.lbclassinfo.TabIndex = 2;
            this.lbclassinfo.Text = "label2";
            // 
            // labelCourse
            // 
            this.labelCourse.AutoSize = true;
            this.labelCourse.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelCourse.Location = new System.Drawing.Point(201, 108);
            this.labelCourse.Name = "labelCourse";
            this.labelCourse.Size = new System.Drawing.Size(56, 21);
            this.labelCourse.TabIndex = 3;
            this.labelCourse.Text = "label3";
            // 
            // btnInfo
            // 
            this.btnInfo.BackColor = System.Drawing.Color.Yellow;
            this.btnInfo.Font = new System.Drawing.Font("微軟正黑體", 12.11215F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnInfo.Location = new System.Drawing.Point(300, 54);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(88, 30);
            this.btnInfo.TabIndex = 4;
            this.btnInfo.Text = "詳細資訊";
            this.btnInfo.UseVisualStyleBackColor = false;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // btnCourse
            // 
            this.btnCourse.BackColor = System.Drawing.Color.Lime;
            this.btnCourse.Font = new System.Drawing.Font("微軟正黑體", 12.11215F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCourse.Location = new System.Drawing.Point(405, 54);
            this.btnCourse.Name = "btnCourse";
            this.btnCourse.Size = new System.Drawing.Size(88, 30);
            this.btnCourse.TabIndex = 5;
            this.btnCourse.Text = "查看開課";
            this.btnCourse.UseVisualStyleBackColor = false;
            this.btnCourse.Click += new System.EventHandler(this.btnCourse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(136, 108);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "開課課程:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(136, 130);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "簡介:";
            // 
            // CoachBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCourse);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.labelCourse);
            this.Controls.Add(this.lbclassinfo);
            this.Controls.Add(this.labelGender);
            this.Controls.Add(this.labelCoachName);
            this.Controls.Add(this.pictureBox1);
            this.Name = "CoachBox";
            this.Size = new System.Drawing.Size(493, 153);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelCoachName;
        private System.Windows.Forms.Label labelGender;
        private System.Windows.Forms.Label lbclassinfo;
        private System.Windows.Forms.Label labelCourse;
        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.Button btnCourse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
