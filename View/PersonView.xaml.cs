using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Lab.ViewModel;
namespace Lab.View
{
	

	public partial class PersonView : Window
	{
		private PersonViewModel _viewModel;
		public PersonView()
		{
			InitializeComponent();
			_viewModel = new PersonViewModel();
			DataContext = _viewModel;
			
		}
	}
}
