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
		private System.Windows.Forms.TabControl tabControlMain;
		private System.Windows.Forms.TabPage tabPageManualEnter;
		private System.Windows.Forms.TabPage tabPageIAIAssistant;
		private System.Windows.Forms.Label labelConversation;
		private System.Windows.Forms.RichTextBox richTextBoxConversation;
		private System.Windows.Forms.Label labelUserMessage;
		private System.Windows.Forms.RichTextBox richTextBoxUserMessage;
		private System.Windows.Forms.Button buttonSendUserMessage;
		private System.Windows.Forms.RichTextBox richTextBoxGenerated;
		private System.Windows.Forms.Button buttonGenerate;
		
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
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.tabControlMain = new System.Windows.Forms.TabControl();
			this.tabPageIAIAssistant = new System.Windows.Forms.TabPage();
			this.buttonSendUserMessage = new System.Windows.Forms.Button();
			this.richTextBoxUserMessage = new System.Windows.Forms.RichTextBox();
			this.labelUserMessage = new System.Windows.Forms.Label();
			this.richTextBoxConversation = new System.Windows.Forms.RichTextBox();
			this.labelConversation = new System.Windows.Forms.Label();
			this.tabPageManualEnter = new System.Windows.Forms.TabPage();
			this.buttonGenerate = new System.Windows.Forms.Button();
			this.richTextBoxGenerated = new System.Windows.Forms.RichTextBox();
			this.labelResultFile = new System.Windows.Forms.Label();
			this.labelScoresFile = new System.Windows.Forms.Label();
			this.labelPatientsFile = new System.Windows.Forms.Label();
			this.buttonResultFile = new System.Windows.Forms.Button();
			this.buttonScoresFile = new System.Windows.Forms.Button();
			this.buttonPatientsFile = new System.Windows.Forms.Button();
			this.tabControlMain.SuspendLayout();
			this.tabPageIAIAssistant.SuspendLayout();
			this.tabPageManualEnter.SuspendLayout();
			this.SuspendLayout();
			// 
			// openFileDialog
			// 
			this.openFileDialog.Filter = "Файлы CSV (*.csv) | *.csv";
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.Filter = "Файлы CSV (*.csv) | *.csv";
			// 
			// tabControlMain
			// 
			this.tabControlMain.Controls.Add(this.tabPageIAIAssistant);
			this.tabControlMain.Controls.Add(this.tabPageManualEnter);
			this.tabControlMain.Location = new System.Drawing.Point(12, 12);
			this.tabControlMain.Name = "tabControlMain";
			this.tabControlMain.SelectedIndex = 0;
			this.tabControlMain.Size = new System.Drawing.Size(640, 394);
			this.tabControlMain.TabIndex = 0;
			// 
			// tabPageIAIAssistant
			// 
			this.tabPageIAIAssistant.Controls.Add(this.buttonSendUserMessage);
			this.tabPageIAIAssistant.Controls.Add(this.richTextBoxUserMessage);
			this.tabPageIAIAssistant.Controls.Add(this.labelUserMessage);
			this.tabPageIAIAssistant.Controls.Add(this.richTextBoxConversation);
			this.tabPageIAIAssistant.Controls.Add(this.labelConversation);
			this.tabPageIAIAssistant.Location = new System.Drawing.Point(4, 25);
			this.tabPageIAIAssistant.Name = "tabPageIAIAssistant";
			this.tabPageIAIAssistant.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageIAIAssistant.Size = new System.Drawing.Size(632, 365);
			this.tabPageIAIAssistant.TabIndex = 1;
			this.tabPageIAIAssistant.Text = "ИИ Помощник";
			this.tabPageIAIAssistant.UseVisualStyleBackColor = true;
			// 
			// buttonSendUserMessage
			// 
			this.buttonSendUserMessage.Location = new System.Drawing.Point(480, 315);
			this.buttonSendUserMessage.Name = "buttonSendUserMessage";
			this.buttonSendUserMessage.Size = new System.Drawing.Size(131, 35);
			this.buttonSendUserMessage.TabIndex = 4;
			this.buttonSendUserMessage.Text = "Отправить";
			this.buttonSendUserMessage.UseVisualStyleBackColor = true;
			this.buttonSendUserMessage.Click += new System.EventHandler(this.ButtonSendUserMessageClick);
			// 
			// richTextBoxUserMessage
			// 
			this.richTextBoxUserMessage.Location = new System.Drawing.Point(17, 261);
			this.richTextBoxUserMessage.Name = "richTextBoxUserMessage";
			this.richTextBoxUserMessage.Size = new System.Drawing.Size(594, 48);
			this.richTextBoxUserMessage.TabIndex = 3;
			this.richTextBoxUserMessage.Text = "";
			// 
			// labelUserMessage
			// 
			this.labelUserMessage.Location = new System.Drawing.Point(17, 235);
			this.labelUserMessage.Name = "labelUserMessage";
			this.labelUserMessage.Size = new System.Drawing.Size(131, 23);
			this.labelUserMessage.TabIndex = 2;
			this.labelUserMessage.Text = "Ваше сообщение:";
			// 
			// richTextBoxConversation
			// 
			this.richTextBoxConversation.Location = new System.Drawing.Point(17, 42);
			this.richTextBoxConversation.Name = "richTextBoxConversation";
			this.richTextBoxConversation.Size = new System.Drawing.Size(594, 177);
			this.richTextBoxConversation.TabIndex = 1;
			this.richTextBoxConversation.Text = "";
			// 
			// labelConversation
			// 
			this.labelConversation.Location = new System.Drawing.Point(17, 14);
			this.labelConversation.Name = "labelConversation";
			this.labelConversation.Size = new System.Drawing.Size(324, 25);
			this.labelConversation.TabIndex = 0;
			this.labelConversation.Text = "Разговор:";
			// 
			// tabPageManualEnter
			// 
			this.tabPageManualEnter.Controls.Add(this.buttonGenerate);
			this.tabPageManualEnter.Controls.Add(this.richTextBoxGenerated);
			this.tabPageManualEnter.Controls.Add(this.labelResultFile);
			this.tabPageManualEnter.Controls.Add(this.labelScoresFile);
			this.tabPageManualEnter.Controls.Add(this.labelPatientsFile);
			this.tabPageManualEnter.Controls.Add(this.buttonResultFile);
			this.tabPageManualEnter.Controls.Add(this.buttonScoresFile);
			this.tabPageManualEnter.Controls.Add(this.buttonPatientsFile);
			this.tabPageManualEnter.Location = new System.Drawing.Point(4, 25);
			this.tabPageManualEnter.Name = "tabPageManualEnter";
			this.tabPageManualEnter.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageManualEnter.Size = new System.Drawing.Size(632, 365);
			this.tabPageManualEnter.TabIndex = 0;
			this.tabPageManualEnter.Text = "Ручной ввод";
			this.tabPageManualEnter.UseVisualStyleBackColor = true;
			// 
			// buttonGenerate
			// 
			this.buttonGenerate.Location = new System.Drawing.Point(470, 313);
			this.buttonGenerate.Name = "buttonGenerate";
			this.buttonGenerate.Size = new System.Drawing.Size(141, 35);
			this.buttonGenerate.TabIndex = 10;
			this.buttonGenerate.Text = "Сгенерировать";
			this.buttonGenerate.UseVisualStyleBackColor = true;
			this.buttonGenerate.Click += new System.EventHandler(this.ButtonGenerateClick);
			// 
			// richTextBoxGenerated
			// 
			this.richTextBoxGenerated.Location = new System.Drawing.Point(15, 158);
			this.richTextBoxGenerated.Name = "richTextBoxGenerated";
			this.richTextBoxGenerated.Size = new System.Drawing.Size(596, 149);
			this.richTextBoxGenerated.TabIndex = 9;
			this.richTextBoxGenerated.Text = "";
			// 
			// labelResultFile
			// 
			this.labelResultFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelResultFile.Location = new System.Drawing.Point(141, 108);
			this.labelResultFile.Name = "labelResultFile";
			this.labelResultFile.Size = new System.Drawing.Size(470, 35);
			this.labelResultFile.TabIndex = 8;
			// 
			// labelScoresFile
			// 
			this.labelScoresFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelScoresFile.Location = new System.Drawing.Point(141, 65);
			this.labelScoresFile.Name = "labelScoresFile";
			this.labelScoresFile.Size = new System.Drawing.Size(470, 27);
			this.labelScoresFile.TabIndex = 7;
			// 
			// labelPatientsFile
			// 
			this.labelPatientsFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelPatientsFile.Location = new System.Drawing.Point(141, 15);
			this.labelPatientsFile.Name = "labelPatientsFile";
			this.labelPatientsFile.Size = new System.Drawing.Size(470, 25);
			this.labelPatientsFile.TabIndex = 6;
			// 
			// buttonResultFile
			// 
			this.buttonResultFile.Location = new System.Drawing.Point(15, 108);
			this.buttonResultFile.Name = "buttonResultFile";
			this.buttonResultFile.Size = new System.Drawing.Size(105, 35);
			this.buttonResultFile.TabIndex = 5;
			this.buttonResultFile.Text = "Сохранить";
			this.buttonResultFile.UseVisualStyleBackColor = true;
			this.buttonResultFile.Click += new System.EventHandler(this.ButtonResultFileClick);
			// 
			// buttonScoresFile
			// 
			this.buttonScoresFile.Location = new System.Drawing.Point(15, 65);
			this.buttonScoresFile.Name = "buttonScoresFile";
			this.buttonScoresFile.Size = new System.Drawing.Size(105, 30);
			this.buttonScoresFile.TabIndex = 3;
			this.buttonScoresFile.Text = "Скоринг...";
			this.buttonScoresFile.UseVisualStyleBackColor = true;
			this.buttonScoresFile.Click += new System.EventHandler(this.ButtonScoresFileClick);
			// 
			// buttonPatientsFile
			// 
			this.buttonPatientsFile.Location = new System.Drawing.Point(15, 15);
			this.buttonPatientsFile.Name = "buttonPatientsFile";
			this.buttonPatientsFile.Size = new System.Drawing.Size(105, 33);
			this.buttonPatientsFile.TabIndex = 1;
			this.buttonPatientsFile.Text = "Пациенты...";
			this.buttonPatientsFile.UseVisualStyleBackColor = true;
			this.buttonPatientsFile.Click += new System.EventHandler(this.ButtonPatientsFileClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(669, 418);
			this.Controls.Add(this.tabControlMain);
			this.Name = "MainForm";
			this.Text = "Мед-ассистент";
			this.Shown += new System.EventHandler(this.MainFormShown);
			this.tabControlMain.ResumeLayout(false);
			this.tabPageIAIAssistant.ResumeLayout(false);
			this.tabPageManualEnter.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}
