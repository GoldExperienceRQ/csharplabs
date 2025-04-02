using Lab.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Model
{
	public class Person
	{
		public string Name { get; set; }
		public string SecondName { get; set; }
		public string Email { get; set; }
		public DateTime DateOfBirth { get; set; }

		private readonly bool _isAdult;
		private readonly string _sunSign;
		private readonly string _chineseSign;
		private readonly bool _isBirthday;

		public bool IsAdult => _isAdult;
		public string SunSign => _sunSign;
		public string ChineseSign => _chineseSign;
		public bool IsBirthday => _isBirthday;

		public Person(string name, string secondName, string email, DateTime dateOfBirth)
		{
			Name = name;
			SecondName = secondName;
			Email = email;
			DateOfBirth = dateOfBirth;

			_isAdult = CalculateIsAdult();
			_sunSign = CalculateSunSign();
			_chineseSign = CalculateChineseSign();
			_isBirthday = CalculateIsBirthday();
		}
		public Person(string name, string secondName, DateTime dateOfBirth)
		{
			Name = name;
			SecondName = secondName;
			Email = "";
			DateOfBirth = dateOfBirth;
		}
		public Person(string name, string secondName, string email)
		{
			Name = name;
			SecondName = secondName;
			Email = email;
			DateOfBirth = DateTime.Now;
		}
		private bool CalculateIsAdult()
		{
			if (DateOfBirth == default) return false;
			var today = DateTime.Today;
			int age = today.Year - DateOfBirth.Year;
			if (DateOfBirth > today.AddYears(-age)) age--;
			return age >= 18;
		}

		private string CalculateSunSign()
		{
			if (DateOfBirth == default) return "Unknown: Date of birth is not given";

			return ZodiacHelper.GetWesternZodiac(DateOfBirth);
		}

		private string CalculateChineseSign()
		{
			if (DateOfBirth == default) return "Unknown: Date of birth is not given";

			return ZodiacHelper.GetChineseZodiac(DateOfBirth);
		}

		private bool CalculateIsBirthday()
		{
			if (DateOfBirth == default) return false;
			var today = DateTime.Today;
			return today.Month == DateOfBirth.Month && today.Day == DateOfBirth.Day;
		}
	}
}
