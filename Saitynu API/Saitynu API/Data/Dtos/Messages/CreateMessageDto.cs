using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Saitynu_API.Data.Dtos.Messages
{
    public record CreateMessageDto([Required] string Title, [Required] string Text, DateTime StartDate, DateTime EndDate);
}
