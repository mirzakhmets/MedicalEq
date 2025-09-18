/*
 * Created by SharpDevelop.
 * User: mirzakhmets
 * Date: 9/18/2025
 * Time: 2:51 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace MedicalEq
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button buttonPatientsFile;
		private System.Windows.Forms.Label labelPatientsFile;
		private System.Windows.Forms.Button buttonScoresFile;
		private System.Windows.Forms.Label labelScoresFile;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.Button buttonResultFile;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.Label labelResultFile;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.buttonPatientsFile = new System.Windows.Forms.Button();
			this.labelPatientsFile = new System.Windows.Forms.Label();
			this.buttonScoresFile = new System.Windows.Forms.Button();
			this.labelScoresFile = new System.Windows.Forms.Label();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.buttonResultFile = new System.Windows.Forms.Button();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.labelResultFile = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// buttonPatientsFile
			// 
			this.buttonPatientsFile.Location = new System.Drawing.Point(21, 30);
			this.buttonPatientsFile.Name = "buttonPatientsFile";
			this.buttonPatientsFile.Size = new System.Drawing.Size(105, 33);
			this.buttonPatientsFile.TabIndex = 0;
			this.buttonPatientsFile.Text = "Пациенты...";
			this.buttonPatientsFile.UseVisualStyleBackColor = true;
			this.buttonPatientsFile.Click += new System.EventHandler(this.ButtonPatientsFileClick);
			// 
			// labelPatientsFile
			// 
			this.labelPatientsFile.Location = new System.Drawing.Point(145, 30);
			this.labelPatientsFile.Name = "labelPatientsFile";
			this.labelPatientsFile.Size = new System.Drawing.Size(366, 25);
			this.labelPatientsFile.TabIndex = 1;
			// 
			// buttonScoresFile
			// 
			this.buttonScoresFile.Location = new System.Drawing.Point(21, 83);
			this.buttonScoresFile.Name = "buttonScoresFile";
			this.buttonScoresFile.Size = new System.Drawing.Size(105, 30);
			this.buttonScoresFile.TabIndex = 2;
			this.buttonScoresFile.Text = "Скоринг...";
			this.buttonScoresFile.UseVisualStyleBackColor = true;
			this.buttonScoresFile.Click += new System.EventHandler(this.ButtonScoresFileClick);
			// 
			// labelScoresFile
			// 
			this.labelScoresFile.Location = new System.Drawing.Point(145, 86);
			this.labelScoresFile.Name = "labelScoresFile";
			this.labelScoresFile.Size = new System.Drawing.Size(366, 27);
			this.labelScoresFile.TabIndex = 3;
			// 
			// openFileDialog
			// 
			this.openFileDialog.Filter = "Файлы CSV (*.csv) | *.csv";
			// 
			// buttonResultFile
			// 
			this.buttonResultFile.Location = new System.Drawing.Point(21, 139);
			this.buttonResultFile.Name = "buttonResultFile";
			this.buttonResultFile.Size = new System.Drawing.Size(105, 35);
			this.buttonResultFile.TabIndex = 4;
			this.buttonResultFile.Text = "Сохранить";
			this.buttonResultFile.UseVisualStyleBackColor = true;
			this.buttonResultFile.Click += new System.EventHandler(this.ButtonResultFileClick);
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.Filter = "Файлы CSV (*.csv) | *.csv";
			// 
			// labelResultFile
			// 
			this.labelResultFile.Location = new System.Drawing.Point(145, 139);
			this.labelResultFile.Name = "labelResultFile";
			this.labelResultFile.Size = new System.Drawing.Size(366, 35);
			this.labelResultFile.TabIndex = 5;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(536, 218);
			this.Controls.Add(this.labelResultFile);
			this.Controls.Add(this.buttonResultFile);
			this.Controls.Add(this.labelScoresFile);
			this.Controls.Add(this.buttonScoresFile);
			this.Controls.Add(this.labelPatientsFile);
			this.Controls.Add(this.buttonPatientsFile);
			this.Name = "MainForm";
			this.Text = "Мед-ассистент";
			this.ResumeLayout(false);

		}
	}
}
