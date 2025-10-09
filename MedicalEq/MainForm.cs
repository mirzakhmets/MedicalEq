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

using System.Net;
using System.Text;
using System.Text.RegularExpressions;

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
			
			Grade.Grades.Clear();
			Patient.Patients.Clear();
			
			labelResultFile.Text = saveFileDialog.FileName;
			
			CSVFile result = new CSVFile();
			
			result.names.Add(ParsingStream.ConvertTo1251("Имя"));
			result.namesIndex.Add(ParsingStream.ConvertTo1251("Имя"), 0);
			
			result.names.Add(ParsingStream.ConvertTo1251("Группа"));
			result.namesIndex.Add(ParsingStream.ConvertTo1251("Группа"), 1);
			
			result.names.Add(ParsingStream.ConvertTo1251("Комментарий"));
			result.namesIndex.Add(ParsingStream.ConvertTo1251("Комментарий"), 2);
			
			CSVFile patients = new CSVFile(new ParsingStream(new FileStream(labelPatientsFile.Text, FileMode.Open)), ParsingStream.ConvertTo1251("Пациенты"));
			CSVFile scoring = new CSVFile(new ParsingStream(new FileStream(labelScoresFile.Text, FileMode.Open)), ParsingStream.ConvertTo1251("Скоринг"));
			
			foreach (CSVLine line in scoring.lines) {
				new Score(scoring, line);
			}
			
			foreach (CSVLine patient in patients.lines) {
				if (Patient.Patients.ContainsKey((string) patient.values[patients.namesIndex[ParsingStream.ConvertTo1251("ФИО")]])) {
					continue;
				}
				
				/*
				Patient patient2 = Patient.AddPatient((string) patient.values[patients.namesIndex[ParsingStream.ConvertTo1251("ФИО")]]);
				
				for (int index = 0; index < patient.values.Count; ++index) {
					string patientScoreName = null;
					
					if (index < patients.names.Count) {
						patientScoreName = (string) patients.names[index];
					}
					
					if (patientScoreName != null) {
						patientScoreName = patientScoreName.Trim();
						
						string v = (string) patient.values[index];
						
						if (v != null) {
							float result2 = 0;

							if (float.TryParse(v, out result2)) {
								try {
									patient2.AddScore(patientScoreName, result2);
								} catch (Exception ex) {
									MessageBox.Show(patientScoreName + " ; " + result2);
								}
							} else {
								//patient2.AddScore(patientScoreName, v);
							}
						}
					}
				}
				*/
				
				/*
				foreach (object _patientScoreName in patients.names) {
					string patientScoreName = (string) _patientScoreName;
					
					//patientScoreName = ParsingStream.ConvertTo1251(patientScoreName.Trim());
					
					if (patientScoreName.Length > 0 && index < patient.values.Count) {
						string v = (string) patient.values[index]; //Grade.GetValue(patients, patient, patientScoreName);
						
						float result2 = 0;
						
						if (v != null && float.TryParse(v, out result2)) {
							patient2.AddScore(patientScoreName, result2);
						}
					}
					
					++index;
				}*/
				
				Patient.AddPatient(Grade.GetValue(patients, patient, ParsingStream.ConvertTo1251("Имя"))).AddScore(Grade.GetValue(patients, patient, ParsingStream.ConvertTo1251("Показатель")), Grade.GetNumericValue(patients, patient, ParsingStream.ConvertTo1251("Значение")));
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
		
		public string MakeRequest(string text)
	    {
	        string url = "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent";
	        string apiKey = "AIzaSyBHGsDdBCy5_ZNYqD847FLd-nLSltfnhjo"; // Replace with your actual API key
	        
	        string jsonPayload = @"{
	            ""contents"": [
	                {
	                    ""parts"": [
	                        {
	                            ""text"": ""${text}""
	                        }
	                    ]
	                }
	            ]
	        }".Replace("${text}", text.Replace("\"", "\\\"").Replace("\n", "\\n"));
	
	        try
	        {
	            // Create the web request
	            WebRequest request = WebRequest.Create(url);
	            request.Method = "POST";
	            request.ContentType = "application/json";
	            request.Headers.Add("X-goog-api-key", apiKey);
	
	            // Convert JSON payload to bytes
	            byte[] byteArray = Encoding.UTF8.GetBytes(jsonPayload);
	            request.ContentLength = byteArray.Length;
	
	            // Write the payload to the request stream
	            using (Stream dataStream = request.GetRequestStream())
	            {
	                dataStream.Write(byteArray, 0, byteArray.Length);
	            }
	
	            // Get the response
	            using (WebResponse response = request.GetResponse())
	            using (Stream responseStream = response.GetResponseStream())
	            using (StreamReader reader = new StreamReader(responseStream))
	            {
	                string responseText = reader.ReadToEnd();
	                
	                string pattern = @"""text""\s*:\s*""([^""]*)""";
	                
	                Regex regex = new Regex(pattern, RegexOptions.Multiline | RegexOptions.IgnorePatternWhitespace);

			        // Find matches
			        Match match = regex.Match(responseText.Replace("\\\"", "'"));
			        
			        if (match.Success)
			        {
			            // Group 1 contains the captured text value
			            responseText = match.Groups[1].Value.Replace("\\n", "\n").Trim();
			        }
	                
			        return responseText;
	                //MessageBox.Show(responseText);
	            }
	        }
	        catch (WebException ex)
	        {
	            using (Stream responseStream = ex.Response.GetResponseStream())
	            using (StreamReader reader = new StreamReader(responseStream))
	            {
	                string errorText = reader.ReadToEnd();
	                return "Ошибка: " + ex.Message + "\nОтвет: " + errorText;
	                //MessageBox.Show("Error: " + ex.Message);
	                //MessageBox.Show("Response: " + errorText);
	            }
	        }
	    }
		
		void MainFormShown(object sender, EventArgs e)
		{
			
		}
		void ButtonSendUserMessageClick(object sender, EventArgs e)
		{
			richTextBoxConversation.Text += 
				"?: " + richTextBoxUserMessage.Text + "\n!:"
					+ this.MakeRequest(richTextBoxUserMessage.Text) + "\n\n";
		}
		void ButtonGenerateClick(object sender, EventArgs e)
		{
			Grade.Grades.Clear();
			Patient.Patients.Clear();
			
			CSVFile patients = new CSVFile(new ParsingStream(new FileStream(labelPatientsFile.Text, FileMode.Open)), ParsingStream.ConvertTo1251("Пациенты"));
			CSVFile scoring = new CSVFile(new ParsingStream(new FileStream(labelScoresFile.Text, FileMode.Open)), ParsingStream.ConvertTo1251("Скоринг"));
			
			foreach (CSVLine line in scoring.lines) {
				new Score(scoring, line);
			}
			
			foreach (CSVLine patient in patients.lines) {
				if (Patient.Patients.ContainsKey((string) patient.values[patients.namesIndex[ParsingStream.ConvertTo1251("ФИО")]])) {
					continue;
				}
				
				Patient patient2 = Patient.AddPatient((string) patient.values[patients.namesIndex[ParsingStream.ConvertTo1251("ФИО")]]);
				
				for (int index = 0; index < patient.values.Count; ++index) {
					string patientScoreName = null;
					
					if (index < patients.names.Count) {
						patientScoreName = (string) patients.names[index];
					}
					
					if (patientScoreName != null) {
						patientScoreName = patientScoreName.Trim();
						
						string v = (string) patient.values[index];
						
						if (v != null) {
							float result2 = 0;

							if (float.TryParse(v, out result2)) {
								try {
									patient2.AddScore(patientScoreName, result2);
								} catch (Exception ex) {
									MessageBox.Show(patientScoreName + " ; " + result2);
								}
							} else {
								//patient2.AddScore(patientScoreName, v);
							}
						}
					}
				}
				
				/*
				foreach (object _patientScoreName in patients.names) {
					string patientScoreName = (string) _patientScoreName;
					
					//patientScoreName = ParsingStream.ConvertTo1251(patientScoreName.Trim());
					
					if (patientScoreName.Length > 0 && index < patient.values.Count) {
						string v = (string) patient.values[index]; //Grade.GetValue(patients, patient, patientScoreName);
						
						float result2 = 0;
						
						if (v != null && float.TryParse(v, out result2)) {
							patient2.AddScore(patientScoreName, result2);
						}
					}
					
					++index;
				}*/
				
				//Patient.AddPatient(Grade.GetValue(patients, patient, ParsingStream.ConvertTo1251("Имя"))).AddScore(Grade.GetValue(patients, patient, ParsingStream.ConvertTo1251("Показатель")), Grade.GetNumericValue(patients, patient, ParsingStream.ConvertTo1251("Значение")));
			}
			
			/*
			foreach (CSVLine patient in patients.lines) {
				Patient.AddPatient(Grade.GetValue(patients, patient, ParsingStream.ConvertTo1251("Имя"))).AddScore(Grade.GetValue(patients, patient, ParsingStream.ConvertTo1251("Показатель")), Grade.GetNumericValue(patients, patient, ParsingStream.ConvertTo1251("Значение")));
			}*/
			
			foreach (Grade grade in Grade.Grades.Values) {
				richTextBoxGenerated.Text += grade.MakeRequest() + "\n";
			}
			
			foreach (Patient patient in Patient.Patients.Values) {
				richTextBoxGenerated.Text += patient.MakeRequest() + "\n";
			}
			
			foreach (Patient patient in Patient.Patients.Values) {
				richTextBoxGenerated.Text += "К какой группе относится пациент '" + ParsingStream.ConvertToDefault(patient.Name) + "'?\n";
			}
			
			richTextBoxGenerated.Text += "\n";
		}
		void RichTextBoxGeneratedTextChanged(object sender, EventArgs e)
		{
	
		}
	}
}
