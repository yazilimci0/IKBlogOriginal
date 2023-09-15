using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFLayer.Class
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public String? SurName { get; set; }
        public string? Name { get; set; }
        public string? UserAdi { get; set; }
        public string? Password { get; set; }
        public int RoleId { get; set; }
    }
}

//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace EFLayer.Class
//{
//    public class User
//    {
//        [Key]
//        public int UserId { get; set; }
//        public string UserAdi{ get; set; }
//        public string Password { get; set; }
//    }
//}
