
namespace RssReader {
    partial class AddContentName {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.annotation = new System.Windows.Forms.Label();
            this.tbrRegisteredName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // annotation
            // 
            this.annotation.AutoSize = true;
            this.annotation.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.annotation.Location = new System.Drawing.Point(7, 9);
            this.annotation.Name = "annotation";
            this.annotation.Size = new System.Drawing.Size(164, 27);
            this.annotation.TabIndex = 0;
            this.annotation.Text = "URLの表示名";
            // 
            // tbrRegisteredName
            // 
            this.tbrRegisteredName.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbrRegisteredName.Location = new System.Drawing.Point(12, 47);
            this.tbrRegisteredName.Name = "tbrRegisteredName";
            this.tbrRegisteredName.Size = new System.Drawing.Size(265, 28);
            this.tbrRegisteredName.TabIndex = 1;
            // 
            // AddContentName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 93);
            this.Controls.Add(this.tbrRegisteredName);
            this.Controls.Add(this.annotation);
            this.Name = "AddContentName";
            this.Text = "AddContentName";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label annotation;
        public System.Windows.Forms.TextBox tbrRegisteredName;
    }
}