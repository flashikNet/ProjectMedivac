using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Responses
{
    public class GetInvitesResp
    {
        [Required]
        public required uint Id { get; set; }
        [Required]
        public required uint InviterId { get; set; }
        [Required]
        public required uint TeamId { get; set; }
        [Required]
        public required string Content { get; set; }
    }
}
