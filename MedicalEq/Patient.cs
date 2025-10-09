/*
 * Created by SharpDevelop.
 * User: mirzakhmets
 * Date: 9/18/2025
 * Time: 4:52 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using CSVdb;

namespace MedicalEq
{
	/// <summary>
	/// Description of Patient.
	/// </summary>
	public class Patient
	{
		public static Dictionary<string, Patient> Patients = new Dictionary<string, Patient>();
		
		public string Name;
		public ArrayList Scores = new ArrayList();
		public ArrayList ScoreValues = new ArrayList();
		public Dictionary<string, int> ScoreIndexes = new Dictionary<string, int>();
		
		public Patient(string Name)
		{
			this.Name = Name;
		}
		
		public static Patient AddPatient(string Name) {
			if (!Patients.ContainsKey(Name)) {
				Patients.Add(Name, new Patient(Name));
			}
			
			return Patients[Name];
		}
		
		public void AddScore(string ScoreName, float ScoreValue) {
			int index = this.ScoreIndexes.Count;
			
			this.Scores.Add(ScoreName);
			
			this.ScoreValues.Add(ScoreValue);
			
			this.ScoreIndexes.Add(ScoreName, index);
		}
		
		public bool ScoreExists(string ScoreName) {
			return this.ScoreIndexes.ContainsKey(ScoreName);
		}
		
		public float GetScore(string ScoreName) {
			return (float) this.ScoreValues[(int) this.ScoreIndexes[ScoreName]];
		}
		
		public string MakeRequest() {
			string result = "Пациент '" + ParsingStream.ConvertToDefault(this.Name) + "'";
			
			int k = 0;
			
			foreach (string score in this.Scores) {
				int index = this.ScoreIndexes[score];
				
				if (k > 0) {
					result += ", " + ParsingStream.ConvertToDefault(score)/*.ToLower()*/ + " " + this.ScoreValues[index];
				} else {
					result += " имеет показатели: " + ParsingStream.ConvertToDefault(score)/*.ToLower()*/ + " " + this.ScoreValues[index];
				}
				
				++k;
			}
			
			if (k == 0) {
				result += " не имеет показателей";
			}
			
			return result + ".";
		}
	}
}
