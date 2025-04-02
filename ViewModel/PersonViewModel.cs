using Lab.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Lab.Model;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Lab.Utility;

namespace Lab.ViewModel
{
	public class PersonViewModel: INotifyPropertyChanged 
	{
		public string Name
		{
			get => _name;
			set
			{
				if (_name != value)
				{
					_name = value;
					OnPropertyChanged();
				}
			}
		}
		public string SecondName
		{
			get => _secondName;
			set
			{
				if (_secondName != value)
				{
					_secondName = value;
					OnPropertyChanged();
				}
			}
		}
		public string Email
		{
			get => _email;
			set
			{
				if (_email != value)
				{
					_email = value;
					OnPropertyChanged();
				}
			}
		}
		public DateTime DateOfBirth
		{
			get => _dateOfBirth;
			set
			{
				if (_dateOfBirth != value)
				{
					_dateOfBirth = value;
					OnPropertyChanged();
				}
			}
		} 

		private string _name;
		private string _secondName;
		private string _email;
		private DateTime _dateOfBirth = DateTime.Today;



		private RelayCommand _proceedCommand;
		public ICommand ProceedCommand => _proceedCommand;

		public PersonViewModel()
		{
			_proceedCommand = new RelayCommand(_ => ShowPersonInfo(), _ => CanProceed());
		}


		public Person Person { get; set; }

		public event PropertyChangedEventHandler? PropertyChanged;

		private void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
			_proceedCommand.RaiseCanExecuteChanged();
		}

		private bool CanProceed()
		{
			return !string.IsNullOrWhiteSpace(Name) &&
			!string.IsNullOrWhiteSpace(SecondName) &&
			!string.IsNullOrWhiteSpace(Email) &&
			DateOfBirth != default;
		}

		private void ShowPersonInfo()
		{
			int age = DateTime.Today.Year - DateOfBirth.Year;
			if (DateOfBirth > DateTime.Today.AddYears(-age)) age--;

			if (DateOfBirth > DateTime.Today || age > 135)
			{
				MessageBox.Show("Невірна дата народження. Людина ще не народилась або їй більше ніж 135 років.");
				return;
			}

			// Перевірка на день народження
			if (DateOfBirth.Day == DateTime.Today.Day &&
				DateOfBirth.Month == DateTime.Today.Month)
			{
				MessageBox.Show("З Днем Народження! 🎉");
			}

			// Створити об’єкт Person і показати всі 8 полів
			var person = new Person(Name, SecondName, Email, DateOfBirth);

			string info = $"Name: {person.Name}\n" +
						  $"Second Name: {person.SecondName}\n" +
						  $"Email: {person.Email}\n" +
						  $"Date of Birth: {person.DateOfBirth.ToShortDateString()}\n" +
						  $"IsAdult: {person.IsAdult}\n" +
						  $"SunSign: {person.SunSign}\n" +
						  $"ChineseSign: {person.ChineseSign}\n" +
						  $"IsBirthday: {person.IsBirthday}";

			MessageBox.Show(info, "Person Info");
		}
	}
}

