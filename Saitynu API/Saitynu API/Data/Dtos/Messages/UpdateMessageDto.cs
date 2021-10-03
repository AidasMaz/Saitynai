using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Saitynu_API.Data.Dtos.Messages
{
    public record UpdateMessageDto([Required] string Title, [Required] string Text, [Required] DateTime StartDate, [Required] DateTime EndDate);
}
