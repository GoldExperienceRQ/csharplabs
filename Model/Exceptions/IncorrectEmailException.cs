using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Model.Exceptions
{
	class IncorrectEmailException: PersonValidationException
	{
		public IncorrectEmailException(): base("Incorrect email. Email structure must be: youremail@provider.domain") { }
	}
}
