using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saitynu_API.Data.Dtos.Auth
{
    public record LoginDto(string UserName, string Password);
}
