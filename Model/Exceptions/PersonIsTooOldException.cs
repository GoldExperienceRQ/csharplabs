using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Model.Exceptions
{
	internal class PersonIsTooOldException: PersonValidationException
	{
		public PersonIsTooOldException(): base("You are old as fuck. You must be in the coffin already.") { }
	}
}
