/*
 * Created by SharpDevelop.
 * User: mirzakhmets
 * Date: 9/18/2025
 * Time: 3:41 PM
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
	/// Description of Score.
	/// </summary>
	public class Score
	{
		public string Name;
		public float MinValue;
		public float MaxValue;
		public Grade Group;
		public string Comment;
		public bool IsBase;
		
		public Score(CSVFile file, CSVLine line)
		{
			this.Name = Grade.GetValue(file, line, "Score");
			
			this.MinValue = Grade.GetNumericValue(file, line, "Minimal value");
			
			this.MaxValue = Grade.GetNumericValue(file, line, "Maximal value");
			
			this.Group = Grade.GetGrade(Grade.GetValue(file, line, "Group"));
			
			this.Comment = Grade.GetValue(file, line, "Comment");
			
			this.IsBase = Grade.GetValue(file, line, "Base") != null && Grade.GetValue(file, line, "Base").Equals("Yes");
			
			this.Group.Scores.Add(this);
			
			if (this.IsBase) {
				++this.Group.BaseScoresCount;
			}
		}
		
		public bool Accepts(float value) {
			return (value >= this.MinValue || this.MinValue == -1) && (value <= this.MaxValue || this.MaxValue == -1);
		}
	}
}
