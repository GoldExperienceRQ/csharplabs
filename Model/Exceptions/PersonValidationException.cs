using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Model.Exceptions
{
	class PersonValidationException: Exception	
	{
		public PersonValidationException(): base("Given input data is not correct.") { }
		public PersonValidationException(string message) : base(message) { }
	}
}
