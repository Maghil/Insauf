namespace Insauf
{
    partial class textbx
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lit = new System.Windows.Forms.Panel();
            this.mtx = new System.Windows.Forms.MaskedTextBox();
            this.ttl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lit
            // 
            this.lit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.lit.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lit.Location = new System.Drawing.Point(6, 57);
            this.lit.Name = "lit";
            this.lit.Size = new System.Drawing.Size(257, 2);
            this.lit.TabIndex = 0;
            // 
            // mtx
            // 
            this.mtx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mtx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mtx.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.mtx.Location = new System.Drawing.Point(8, 33);
            this.mtx.Name = "mtx";
            this.mtx.Size = new System.Drawing.Size(255, 22);
            this.mtx.TabIndex = 1;
            this.mtx.Text = "Subtitle";
            this.mtx.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mtx_MaskInputRejected);
            this.mtx.Enter += new System.EventHandler(this.Mtx_Enter);
            this.mtx.Leave += new System.EventHandler(this.Mtx_Leave);
            // 
            // ttl
            // 
            this.ttl.AutoSize = true;
            this.ttl.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ttl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ttl.Location = new System.Drawing.Point(3, 3);
            this.ttl.Name = "ttl";
            this.ttl.Size = new System.Drawing.Size(48, 25);
            this.ttl.TabIndex = 2;
            this.ttl.Text = "Title";
            // 
            // textbx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ttl);
            this.Controls.Add(this.mtx);
            this.Controls.Add(this.lit);
            this.Name = "textbx";
            this.Size = new System.Drawing.Size(271, 67);
            this.Load += new System.EventHandler(this.Textbx_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel lit;
        private System.Windows.Forms.MaskedTextBox mtx;
        private System.Windows.Forms.Label ttl;
    }
}
