using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Services.DTO
{
    public class AuthenticationDto
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
    }
}
