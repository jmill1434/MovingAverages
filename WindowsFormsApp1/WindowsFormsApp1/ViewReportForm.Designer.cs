namespace WindowsFormsApp1
{
    partial class ViewReportForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button_s = new System.Windows.Forms.Button();
            this.button_d = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 23);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(824, 237);
            this.textBox1.TabIndex = 0;
            // 
            // button_s
            // 
            this.button_s.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_s.Location = new System.Drawing.Point(64, 294);
            this.button_s.Name = "button_s";
            this.button_s.Size = new System.Drawing.Size(119, 42);
            this.button_s.TabIndex = 1;
            this.button_s.Text = "Serialize";
            this.button_s.UseVisualStyleBackColor = true;
            this.button_s.Click += new System.EventHandler(this.button_s_Click);
            // 
            // button_d
            // 
            this.button_d.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_d.Location = new System.Drawing.Point(593, 294);
            this.button_d.Name = "button_d";
            this.button_d.Size = new System.Drawing.Size(119, 42);
            this.button_d.TabIndex = 2;
            this.button_d.Text = "Deserialize";
            this.button_d.UseVisualStyleBackColor = true;
            this.button_d.Click += new System.EventHandler(this.button_d_Click);
            // 
            // ViewReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 389);
            this.Controls.Add(this.button_d);
            this.Controls.Add(this.button_s);
            this.Controls.Add(this.textBox1);
            this.Name = "ViewReportForm";
            this.Text = "ViewReportForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button_s;
        private System.Windows.Forms.Button button_d;
    }
}