using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Lab.Utility;
namespace Lab.ViewModel
{
	internal class BirthdayViewModel: INotifyPropertyChanged
	{
		private DateTime _birthDay;
		public DateTime BirthDay {

			get { return _birthDay; }
			set
			{
				if (_birthDay != value) 
				{
					_birthDay = value;
					
					Age = CalculateAge();

					AgeOutput = FormAgeOutputMessage();
					OnPropertyChanged(nameof(AgeOutput));

					WesternZodiacOutput = $"Your western zodiac sign is {ZodiacHelper.GetWesternZodiac(_birthDay)}";
					OnPropertyChanged(nameof(WesternZodiacOutput));

					ChineseZodiacOutput = $"Your chinese zodiac sign is {ZodiacHelper.GetChineseZodiac(_birthDay)}";
					OnPropertyChanged(nameof(ChineseZodiacOutput));
				}
			}
		}
		
		public int Age { get; set; }
		public string AgeOutput	{ get; set; }
		public string WesternZodiacOutput { get; set; }
		public string ChineseZodiacOutput { get; set; }

		public event PropertyChangedEventHandler? PropertyChanged;

		private int CalculateAge()
		{
			int yearDifference = DateTime.Today.Year - _birthDay.Year;
			if (DateTime.Today.Month > BirthDay.Month)
			{
				return yearDifference;
			}
			else if (DateTime.Today.Month == BirthDay.Month)
			{
				return DateTime.Today.Day >= BirthDay.Day ? yearDifference : yearDifference - 1;
			}
			else
			{
				return yearDifference - 1;
			}
		}

		private string FormAgeOutputMessage()
		{
			if (DateTime.Today.Day == BirthDay.Day)
			{
				return $"Your age is {Age}. \nHappy birthday, by the way";
			}
			else {
				return $"Your age is {Age}";
			}
		}

		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
