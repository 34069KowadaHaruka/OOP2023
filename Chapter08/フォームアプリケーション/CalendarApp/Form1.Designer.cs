﻿
namespace CalendarApp {
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
            if (disposing && (components != null)) {
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
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btDayCalc = new System.Windows.Forms.Button();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.btForwardDay = new System.Windows.Forms.Button();
            this.btNextDay = new System.Windows.Forms.Button();
            this.btNextMonth = new System.Windows.Forms.Button();
            this.btForwardMonth = new System.Windows.Forms.Button();
            this.btForwardYear = new System.Windows.Forms.Button();
            this.btNextYear = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbTimeNow = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "日付：";
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpDate.Location = new System.Drawing.Point(94, 12);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 31);
            this.dtpDate.TabIndex = 1;
            // 
            // btDayCalc
            // 
            this.btDayCalc.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btDayCalc.Location = new System.Drawing.Point(94, 49);
            this.btDayCalc.Name = "btDayCalc";
            this.btDayCalc.Size = new System.Drawing.Size(126, 43);
            this.btDayCalc.TabIndex = 2;
            this.btDayCalc.Text = "日数計算";
            this.btDayCalc.UseVisualStyleBackColor = true;
            this.btDayCalc.Click += new System.EventHandler(this.btDayCalc_Click);
            // 
            // tbMessage
            // 
            this.tbMessage.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbMessage.Location = new System.Drawing.Point(312, 12);
            this.tbMessage.Multiline = true;
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(420, 243);
            this.tbMessage.TabIndex = 3;
            // 
            // btForwardDay
            // 
            this.btForwardDay.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btForwardDay.Location = new System.Drawing.Point(94, 212);
            this.btForwardDay.Name = "btForwardDay";
            this.btForwardDay.Size = new System.Drawing.Size(95, 43);
            this.btForwardDay.TabIndex = 2;
            this.btForwardDay.Text = "ー日";
            this.btForwardDay.UseVisualStyleBackColor = true;
            this.btForwardDay.Click += new System.EventHandler(this.btDayCalc_Click);
            // 
            // btNextDay
            // 
            this.btNextDay.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btNextDay.Location = new System.Drawing.Point(199, 212);
            this.btNextDay.Name = "btNextDay";
            this.btNextDay.Size = new System.Drawing.Size(95, 43);
            this.btNextDay.TabIndex = 2;
            this.btNextDay.Text = "＋日";
            this.btNextDay.UseVisualStyleBackColor = true;
            this.btNextDay.Click += new System.EventHandler(this.btDayCalc_Click);
            // 
            // btNextMonth
            // 
            this.btNextMonth.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btNextMonth.Location = new System.Drawing.Point(199, 163);
            this.btNextMonth.Name = "btNextMonth";
            this.btNextMonth.Size = new System.Drawing.Size(95, 43);
            this.btNextMonth.TabIndex = 2;
            this.btNextMonth.Text = "＋月";
            this.btNextMonth.UseVisualStyleBackColor = true;
            this.btNextMonth.Click += new System.EventHandler(this.btDayCalc_Click);
            // 
            // btForwardMonth
            // 
            this.btForwardMonth.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btForwardMonth.Location = new System.Drawing.Point(94, 163);
            this.btForwardMonth.Name = "btForwardMonth";
            this.btForwardMonth.Size = new System.Drawing.Size(95, 43);
            this.btForwardMonth.TabIndex = 2;
            this.btForwardMonth.Text = "ー月";
            this.btForwardMonth.UseVisualStyleBackColor = true;
            this.btForwardMonth.Click += new System.EventHandler(this.btDayCalc_Click);
            // 
            // btForwardYear
            // 
            this.btForwardYear.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btForwardYear.Location = new System.Drawing.Point(94, 114);
            this.btForwardYear.Name = "btForwardYear";
            this.btForwardYear.Size = new System.Drawing.Size(95, 43);
            this.btForwardYear.TabIndex = 2;
            this.btForwardYear.Text = "ー年";
            this.btForwardYear.UseVisualStyleBackColor = true;
            this.btForwardYear.Click += new System.EventHandler(this.btDayCalc_Click);
            // 
            // btNextYear
            // 
            this.btNextYear.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btNextYear.Location = new System.Drawing.Point(199, 114);
            this.btNextYear.Name = "btNextYear";
            this.btNextYear.Size = new System.Drawing.Size(95, 43);
            this.btNextYear.TabIndex = 2;
            this.btNextYear.Text = "＋年";
            this.btNextYear.UseVisualStyleBackColor = true;
            this.btNextYear.Click += new System.EventHandler(this.btDayCalc_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(12, 345);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "現在時刻：";
            // 
            // tbTimeNow
            // 
            this.tbTimeNow.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbTimeNow.Location = new System.Drawing.Point(152, 345);
            this.tbTimeNow.Multiline = true;
            this.tbTimeNow.Name = "tbTimeNow";
            this.tbTimeNow.Size = new System.Drawing.Size(266, 36);
            this.tbTimeNow.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 383);
            this.Controls.Add(this.tbTimeNow);
            this.Controls.Add(this.tbMessage);
            this.Controls.Add(this.btNextYear);
            this.Controls.Add(this.btNextMonth);
            this.Controls.Add(this.btNextDay);
            this.Controls.Add(this.btForwardYear);
            this.Controls.Add(this.btForwardMonth);
            this.Controls.Add(this.btForwardDay);
            this.Controls.Add(this.btDayCalc);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "カレンダーアプリ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button btDayCalc;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.Button btForwardDay;
        private System.Windows.Forms.Button btNextDay;
        private System.Windows.Forms.Button btNextMonth;
        private System.Windows.Forms.Button btForwardMonth;
        private System.Windows.Forms.Button btForwardYear;
        private System.Windows.Forms.Button btNextYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbTimeNow;
    }
}

