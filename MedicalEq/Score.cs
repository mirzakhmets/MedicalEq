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
			this.Name = Grade.GetValue(file, line, ParsingStream.ConvertTo1251("Показатель"));
			
			this.MinValue = Grade.GetNumericValue(file, line, ParsingStream.ConvertTo1251("Минимальное значение"));
			
			this.MaxValue = Grade.GetNumericValue(file, line, ParsingStream.ConvertTo1251("Максимальное значение"));
			
			this.Group = Grade.GetGrade(Grade.GetValue(file, line, ParsingStream.ConvertTo1251("Группа")));
			
			this.Comment = Grade.GetValue(file, line, ParsingStream.ConvertTo1251("Комментарий"));
			
			this.IsBase = Grade.GetValue(file, line, ParsingStream.ConvertTo1251("Основное")) != null && Grade.GetValue(file, line, ParsingStream.ConvertTo1251("Основное")).ToUpper().Equals(ParsingStream.ConvertTo1251("ДА"));
			
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
