using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.BLL.BOs
{
    public class UserBo
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public int age { get; set; }
        public string password { get; set; }
    }
}
