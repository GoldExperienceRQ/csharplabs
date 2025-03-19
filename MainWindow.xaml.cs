using Lab.ViewModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BirthdayViewModel birthdayViewModel;


        public MainWindow()
        {
            InitializeComponent();

            birthdayViewModel = new BirthdayViewModel();
            
            this.DataContext = birthdayViewModel;

        }

		private void CalculateBtn_Click(object sender, RoutedEventArgs e)
		{
            Console.WriteLine("Clicked");
			if (datePicker.SelectedDate != null && ValidateDateInput())
            {
                Console.WriteLine("InsideIF");
                BindingExpression bindingExp = datePicker.GetBindingExpression(DatePicker.SelectedDateProperty);
                Console.WriteLine(bindingExp);
                bindingExp.UpdateSource();
            }
            else
            {
                MessageBox.Show("Enter correct age");
            }
		}
        private bool ValidateDateInput()
        {
            if(datePicker.SelectedDate > DateTime.Now || DateTime.Today.Year - datePicker.SelectedDate.Value.Year > 135)
            {
                return false;
            }
            return true;
        }
	}
}
    
