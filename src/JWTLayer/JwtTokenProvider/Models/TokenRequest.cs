using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtTokenProvider.Models;
public class TokenRequest
{
    public string Username { get; set; }
    public string RoleName { get; set; }
}
