using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Domain.Exceptions
{
    public class UserNotFoundException<T> : Exception
    {
        public UserNotFoundException(T identifier) : base($"User with identifier '{identifier}' not found.") { }
    }
}
