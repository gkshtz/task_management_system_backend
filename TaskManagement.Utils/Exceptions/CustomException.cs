using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Utils.Exceptions
{
    public class CustomException : Exception
    {
        public int Status { get; set; }
        public string Name { get; set; }
        public CustomException(string message, int status): base(message) 
        {
            Status = status;
        }
        public CustomException(int status)
        {
            Status = status;
        }
    }
}
