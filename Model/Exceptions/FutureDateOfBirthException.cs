using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Model.Exceptions
{
	class FutureDateOfBirthException : PersonValidationException
	{
		public FutureDateOfBirthException()
		: base("You are still in the womb of your mother. Or maybe she hasn't even thought of you yet.") { }
	}
}
