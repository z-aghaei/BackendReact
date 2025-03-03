using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class ResponseLoginDto
    {
        public string? RefreshToken { get; set; }
        public string? Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
