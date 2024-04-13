using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Requests
{
    public class SignUpReq
    {
        [Required]
        public required string Name { get; set; }
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
        [Required]
        public required string BattleNetAccount { get; set; }
        [Required]
        public required string Password { get; set; }
        public required Races Race { get; set; }
        public required uint MMR { get; set; }
    }
}
