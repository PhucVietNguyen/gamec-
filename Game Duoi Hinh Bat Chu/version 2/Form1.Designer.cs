namespace version_2
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
            this.ptrHinhAnh = new System.Windows.Forms.PictureBox();
            this.lblDiem = new System.Windows.Forms.Label();
            this.btnTroGiup = new System.Windows.Forms.Button();
            this.tm = new System.Windows.Forms.Timer(this.components);
            this.lblThoiGian = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ptrHinhAnh)).BeginInit();
            this.SuspendLayout();
            // 
            // ptrHinhAnh
            // 
            this.ptrHinhAnh.Location = new System.Drawing.Point(26, 34);
            this.ptrHinhAnh.Name = "ptrHinhAnh";
            this.ptrHinhAnh.Size = new System.Drawing.Size(490, 336);
            this.ptrHinhAnh.TabIndex = 0;
            this.ptrHinhAnh.TabStop = false;
            // 
            // lblDiem
            // 
            this.lblDiem.AutoSize = true;
            this.lblDiem.Location = new System.Drawing.Point(692, 34);
            this.lblDiem.Name = "lblDiem";
            this.lblDiem.Size = new System.Drawing.Size(50, 13);
            this.lblDiem.TabIndex = 1;
            this.lblDiem.Text = "Điểm Số:";
            // 
            // btnTroGiup
            // 
            this.btnTroGiup.Location = new System.Drawing.Point(695, 84);
            this.btnTroGiup.Name = "btnTroGiup";
            this.btnTroGiup.Size = new System.Drawing.Size(75, 23);
            this.btnTroGiup.TabIndex = 2;
            this.btnTroGiup.Text = "Trợ Giúp";
            this.btnTroGiup.UseVisualStyleBackColor = true;
            this.btnTroGiup.Click += new System.EventHandler(this.btnTroGiup_Click);
            // 
            // tm
            // 
            this.tm.Interval = 1000;
            this.tm.Tick += new System.EventHandler(this.tm_Tick);
            // 
            // lblThoiGian
            // 
            this.lblThoiGian.AutoSize = true;
            this.lblThoiGian.Location = new System.Drawing.Point(692, 145);
            this.lblThoiGian.Name = "lblThoiGian";
            this.lblThoiGian.Size = new System.Drawing.Size(95, 13);
            this.lblThoiGian.TabIndex = 3;
            this.lblThoiGian.Text = "Thời Gian Còn Lại:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 473);
            this.Controls.Add(this.lblThoiGian);
            this.Controls.Add(this.btnTroGiup);
            this.Controls.Add(this.lblDiem);
            this.Controls.Add(this.ptrHinhAnh);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptrHinhAnh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ptrHinhAnh;
        private System.Windows.Forms.Label lblDiem;
        private System.Windows.Forms.Button btnTroGiup;
        private System.Windows.Forms.Timer tm;
        private System.Windows.Forms.Label lblThoiGian;
    }
}

