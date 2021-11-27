using Saitynu_API.Auth.Model;
using Saitynu_API.Data.Dtos.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Saitynu_API.Data.Entities
{
    public class Player : IUserOwnedResource
    {
        public int Id { get; set; }
        public string Nick { get; set; }
        public string Type { get; set; }
        public DateTime CreationDate { get; set; }

        [Required]
        public string UserId { get; set; }
        public RestUser User { get; set; }
    }
}
