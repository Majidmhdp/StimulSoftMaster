﻿namespace StimulTest
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
			this.analysisOfAccountBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// analysisOfAccountBtn
			// 
			this.analysisOfAccountBtn.Location = new System.Drawing.Point(76, 12);
			this.analysisOfAccountBtn.Name = "analysisOfAccountBtn";
			this.analysisOfAccountBtn.Size = new System.Drawing.Size(189, 49);
			this.analysisOfAccountBtn.TabIndex = 0;
			this.analysisOfAccountBtn.Text = "Load Analysis Of Account Report";
			this.analysisOfAccountBtn.UseVisualStyleBackColor = true;
			this.analysisOfAccountBtn.Click += new System.EventHandler(this.analysisOfAccountBtn_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(322, 182);
			this.Controls.Add(this.analysisOfAccountBtn);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button analysisOfAccountBtn;
	}
}

