using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Utils.Enums;

namespace TaskManagement.Utils.Exceptions
{
    public class FailedAuthenticationException: CustomException
    {
        public FailedAuthenticationException() : base(500)
        {
            Name  = ErrorNames.AUTHENTICATION_FAILED_ERROR.ToString();
        }
        public FailedAuthenticationException(string message): base(message, 500)
        {
            Name = ErrorNames.AUTHENTICATION_FAILED_ERROR.ToString();
        }
    }
}
