
namespace HandlingEvents
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SyncButton = new System.Windows.Forms.Button();
            this.AsyncButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SyncButton
            // 
            this.SyncButton.Location = new System.Drawing.Point(39, 34);
            this.SyncButton.Name = "SyncButton";
            this.SyncButton.Size = new System.Drawing.Size(191, 85);
            this.SyncButton.TabIndex = 0;
            this.SyncButton.Text = "Click Sync";
            this.SyncButton.UseVisualStyleBackColor = true;
            this.SyncButton.Click += new System.EventHandler(this.SyncButton_Click);
            // 
            // button2
            // 
            this.AsyncButton.Location = new System.Drawing.Point(39, 134);
            this.AsyncButton.Name = "AsyncButton";
            this.AsyncButton.Size = new System.Drawing.Size(191, 85);
            this.AsyncButton.TabIndex = 1;
            this.AsyncButton.Text = "Click Async";
            this.AsyncButton.UseVisualStyleBackColor = true;
            this.AsyncButton.Click += new System.EventHandler(this.AsyncButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 246);
            this.Controls.Add(this.AsyncButton);
            this.Controls.Add(this.SyncButton);
            this.MinimumSize = new System.Drawing.Size(285, 285);
            this.Name = "Form1";
            this.Text = "Events";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SyncButton;
        private System.Windows.Forms.Button AsyncButton;
    }
}

