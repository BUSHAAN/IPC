using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IPC.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string Username{ get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

      
        public string Category { get; set; }
    }
}
