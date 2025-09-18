/*
 * Created by SharpDevelop.
 * User: mirzakhmets
 * Date: 9/18/2025
 * Time: 2:51 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CSVdb;
using CSVdb.CSV;

namespace MedicalEq
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void ButtonPatientsFileClick(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK) {
				labelPatientsFile.Text = openFileDialog.FileName;
			}
		}
		void ButtonScoresFileClick(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK) {
				labelScoresFile.Text = openFileDialog.FileName;
			}
		}
		void ButtonResultFileClick(object sender, EventArgs e)
		{
			if (saveFileDialog.ShowDialog() != DialogResult.OK) {
				return;
			}
			
			labelResultFile.Text = saveFileDialog.FileName;
			
			CSVFile result = new CSVFile();
			
			result.names.Add("Name");
			result.namesIndex.Add("Name", 0);
			
			result.names.Add("Group");
			result.namesIndex.Add("Group", 1);
			
			result.names.Add("Comment");
			result.namesIndex.Add("Comment", 2);
			
			CSVFile patients = new CSVFile(new ParsingStream(new FileStream(labelPatientsFile.Text, FileMode.Open)), "Patients");
			CSVFile scoring = new CSVFile(new ParsingStream(new FileStream(labelScoresFile.Text, FileMode.Open)), "Scoring");
			
			foreach (CSVLine line in scoring.lines) {
				new Score(scoring, line);
			}
			
			foreach (CSVLine patient in patients.lines) {
				Patient.AddPatient(Grade.GetValue(patients, patient, "Name")).AddScore(Grade.GetValue(patients, patient, "Score"), Grade.GetNumericValue(patients, patient, "Value"));
			}
			
			foreach (string _patient in Patient.Patients.Keys) {
				Patient patient = Patient.Patients[_patient];
				
				Dictionary<string, int> scoresCounts = new Dictionary<string, int>();
				Dictionary<string, ArrayList> nonBaseScores = new Dictionary<string, ArrayList>();
				
				foreach (Grade grade in Grade.Grades.Values) {
					foreach (Score score in grade.Scores) {
						if (patient.ScoreExists(score.Name)) {
							float value = patient.GetScore(score.Name);
							
							if (score.Accepts(value)) {
								if (!scoresCounts.ContainsKey(grade.Name)) {
									scoresCounts.Add(grade.Name, 0);
									
									nonBaseScores.Add(grade.Name, new ArrayList());
								}

								if (score.IsBase) {
									scoresCounts[grade.Name] = scoresCounts[grade.Name] + 1;
								} else {
									nonBaseScores[grade.Name].Add(score);
								}
							}
						}
					}
				}
				
				foreach (string grade in scoresCounts.Keys) {
					Grade acceptedGrade = Grade.Grades[grade];
					
					if (scoresCounts[grade] == acceptedGrade.BaseScoresCount) {
						CSVLine resultLine = new CSVLine();
						
						resultLine.values.Add(patient.Name);
						resultLine.values.Add(acceptedGrade.Name);
						resultLine.values.Add(acceptedGrade.GetComment());
						
						result.lines.Add(resultLine);
						
						ArrayList list = nonBaseScores[acceptedGrade.Name];
					
						foreach (Score score in list) {
							CSVLine resultLine2 = new CSVLine();
							
							resultLine2.values.Add(patient.Name);
							resultLine2.values.Add(acceptedGrade.Name);
							resultLine2.values.Add(score.Comment);
							
							result.lines.Add(resultLine2);						
						}
					}					
				}
			}
			
			result.Save(labelResultFile.Text);
		}
	}
}
