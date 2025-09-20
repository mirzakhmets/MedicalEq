/*
 * Created by SharpDevelop.
 * User: mirzakhmets
 * Date: 9/18/2025
 * Time: 3:44 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using CSVdb;
using CSVdb.CSV;

namespace MedicalEq
{
	/// <summary>
	/// Description of Grade.
	/// </summary>
	public class Grade
	{
		public static Dictionary<string, Grade> Grades = new Dictionary<string, Grade>();
		
		public static Grade GetGrade(string name) {
			if (Grades.ContainsKey(name)) return Grades[name];
			
			Grade grade = new Grade(name);
			
			Grades.Add(name, grade);
			
			return grade;
		}
		
		public string Name = null;
		public ArrayList Scores = new ArrayList();
		public int BaseScoresCount = 0;
		
		public static string GetValue(CSVFile file, CSVLine line, string name) {
			if (file.namesIndex.ContainsKey(name)) {
				return (string) line.values[file.namesIndex[name]];
			}
			
			return null;
		}
		
		public static float GetNumericValue(CSVFile file, CSVLine line, string name) {
			if (file.namesIndex.ContainsKey(name)) {
				float result;
				
				if (float.TryParse((string) line.values[file.namesIndex[name]], out result)) {
					return result;
				}
				
				return -1;
			}
			
			return -1;
		}
		
		public Grade(string Name) {
			this.Name = Name;
		}
		
		public Grade(CSVFile file, CSVLine line)
		{
			this.Name = GetValue(file, line, ParsingStream.ConvertTo1251("Группа"));
			
			Grades.Add(this.Name, this);
		}
		
		public string GetComment() {
			foreach (Score score in this.Scores) {
				if (score.Comment != null && score.Comment.Length > 0 && score.IsBase) {
					return score.Comment;
				}
			}
			
			return null;
		}
		
		#region Equals and GetHashCode implementation
		public override int GetHashCode()
		{
			int hashCode = 0;
				unchecked {
					if (Name != null)
						hashCode += 1000000009 * Name.GetHashCode();
				}
			return hashCode;
		}

		public override bool Equals(object obj)
		{
			Grade other = obj as Grade;
			if (other == null)
				return false;
			return this.Name == other.Name;
		}

		public static bool operator ==(Grade lhs, Grade rhs) {
			if (ReferenceEquals(lhs, rhs))
				return true;
			if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
				return false;
			return lhs.Equals(rhs);
		}

		public static bool operator !=(Grade lhs, Grade rhs) {
			return !(lhs == rhs);
		}

		#endregion
		
		public string MakeRequest() {
			string result = "";
			
			int k = 0;
			
			foreach (Score score in this.Scores) {
				if (score.IsBase) {
					if (k > 0) {
						result += "и ";
					} else {
						result += "Для группы '" + ParsingStream.ConvertToDefault(this.Name) + "': ";
					}
					
					result += "если " + score.MakeRequest();
					
					++k;
				}
			}
			
			if (k > 0) {
				result += ".";
			}
			
			k = 0;
			
			foreach (Score score in this.Scores) {
				if (!score.IsBase) {
					if (k > 0) {
						result += ", ";
					} else {
						result += "При этом: ";
					}
					
					result += "если " + score.MakeRequest();
					
					++k;
				}
			}
			
			if (k > 0) {
				result += ".";
			}
			
			return (result);
		}
	}
}
