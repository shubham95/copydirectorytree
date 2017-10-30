namespace copydirectorytree
{
    partial class GenrateDirectoryTree
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
            this.sourceDirectory = new System.Windows.Forms.TextBox();
            this.destDirectory = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sourceDirectory
            // 
            this.sourceDirectory.Location = new System.Drawing.Point(61, 71);
            this.sourceDirectory.Name = "sourceDirectory";
            this.sourceDirectory.Size = new System.Drawing.Size(526, 22);
            this.sourceDirectory.TabIndex = 0;
            // 
            // destDirectory
            // 
            this.destDirectory.Location = new System.Drawing.Point(61, 153);
            this.destDirectory.Name = "destDirectory";
            this.destDirectory.Size = new System.Drawing.Size(526, 22);
            this.destDirectory.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(629, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(237, 33);
            this.button1.TabIndex = 2;
            this.button1.Text = "Select Source Directory";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(629, 148);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(237, 32);
            this.button2.TabIndex = 3;
            this.button2.Text = "Select Destination Directory";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(315, 227);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(258, 60);
            this.button3.TabIndex = 4;
            this.button3.Text = "Generate";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // GenrateDirectoryTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 326);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.destDirectory);
            this.Controls.Add(this.sourceDirectory);
            this.Name = "GenrateDirectoryTree";
            this.Text = "GenrateDirectoryTree";
            this.Load += new System.EventHandler(this.GenrateDirectoryTree_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox sourceDirectory;
        private System.Windows.Forms.TextBox destDirectory;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}