namespace CS419
{
    partial class GdiDrawingForm
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
            this.picOut = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picOut)).BeginInit();
            this.SuspendLayout();
            // 
            // picOut
            // 
            this.picOut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picOut.Location = new System.Drawing.Point(12, 12);
            this.picOut.Name = "picOut";
            this.picOut.Size = new System.Drawing.Size(560, 538);
            this.picOut.TabIndex = 0;
            this.picOut.TabStop = false;
            // 
            // GdiDrawingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 562);
            this.Controls.Add(this.picOut);
            this.MinimizeBox = false;
            this.Name = "GdiDrawingForm";
            this.Text = "GDIDrawing";
            this.Load += new System.EventHandler(this.GdiDrawingForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GdiDrawingForm_KeyDown);
            this.Resize += new System.EventHandler(this.GdiDrawingForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picOut)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picOut;
    }
}