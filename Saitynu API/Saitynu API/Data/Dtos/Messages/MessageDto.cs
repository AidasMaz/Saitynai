using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saitynu_API.Data.Dtos.Messages
{
    public record MessageDto(int Id, string Title, string Text, DateTime StartDate, DateTime EndDate);
}