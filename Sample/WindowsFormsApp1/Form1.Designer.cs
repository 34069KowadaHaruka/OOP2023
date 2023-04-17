
namespace WindowsFormsApp1 {
    partial class Form1 {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.btButton = new System.Windows.Forms.Button();
            this.tbNum1 = new System.Windows.Forms.TextBox();
            this.tbNum2 = new System.Windows.Forms.TextBox();
            this.tbAns = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nubX = new System.Windows.Forms.NumericUpDown();
            this.nubY = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbResult = new System.Windows.Forms.TextBox();
            this.btPow = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nubX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nubY)).BeginInit();
            this.SuspendLayout();
            // 
            // btButton
            // 
            this.btButton.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btButton.Location = new System.Drawing.Point(433, 104);
            this.btButton.Name = "btButton";
            this.btButton.Size = new System.Drawing.Size(123, 58);
            this.btButton.TabIndex = 0;
            this.btButton.Text = "計算";
            this.btButton.UseVisualStyleBackColor = true;
            this.btButton.Click += new System.EventHandler(this.btButton_Click);
            // 
            // tbNum1
            // 
            this.tbNum1.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbNum1.Location = new System.Drawing.Point(23, 41);
            this.tbNum1.Name = "tbNum1";
            this.tbNum1.Size = new System.Drawing.Size(123, 34);
            this.tbNum1.TabIndex = 1;
            // 
            // tbNum2
            // 
            this.tbNum2.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbNum2.Location = new System.Drawing.Point(180, 41);
            this.tbNum2.Name = "tbNum2";
            this.tbNum2.Size = new System.Drawing.Size(123, 34);
            this.tbNum2.TabIndex = 1;
            // 
            // tbAns
            // 
            this.tbAns.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbAns.Location = new System.Drawing.Point(404, 41);
            this.tbAns.Name = "tbAns";
            this.tbAns.Size = new System.Drawing.Size(152, 34);
            this.tbAns.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(152, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "+";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(348, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "=";
            // 
            // nubX
            // 
            this.nubX.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.nubX.Location = new System.Drawing.Point(23, 220);
            this.nubX.Name = "nubX";
            this.nubX.Size = new System.Drawing.Size(120, 42);
            this.nubX.TabIndex = 3;
            // 
            // nubY
            // 
            this.nubY.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.nubY.Location = new System.Drawing.Point(183, 220);
            this.nubY.Name = "nubY";
            this.nubY.Size = new System.Drawing.Size(120, 42);
            this.nubY.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(149, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "の";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(321, 239);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "乗は";
            // 
            // tbResult
            // 
            this.tbResult.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbResult.Location = new System.Drawing.Point(404, 226);
            this.tbResult.Name = "tbResult";
            this.tbResult.Size = new System.Drawing.Size(152, 34);
            this.tbResult.TabIndex = 7;
            // 
            // btPow
            // 
            this.btPow.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btPow.Location = new System.Drawing.Point(433, 299);
            this.btPow.Name = "btPow";
            this.btPow.Size = new System.Drawing.Size(123, 58);
            this.btPow.TabIndex = 8;
            this.btPow.Text = "計算";
            this.btPow.UseVisualStyleBackColor = true;
            this.btPow.Click += new System.EventHandler(this.btPow_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(565, 239);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 21);
            this.label5.TabIndex = 9;
            this.label5.Text = "です。";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 369);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btPow);
            this.Controls.Add(this.tbResult);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nubY);
            this.Controls.Add(this.nubX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbAns);
            this.Controls.Add(this.tbNum2);
            this.Controls.Add(this.tbNum1);
            this.Controls.Add(this.btButton);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.nubX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nubY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btButton;
        private System.Windows.Forms.TextBox tbNum1;
        private System.Windows.Forms.TextBox tbNum2;
        private System.Windows.Forms.TextBox tbAns;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nubX;
        private System.Windows.Forms.NumericUpDown nubY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbResult;
        private System.Windows.Forms.Button btPow;
        private System.Windows.Forms.Label label5;
    }
}

