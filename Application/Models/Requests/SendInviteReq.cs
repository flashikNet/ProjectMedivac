using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Requests
{
    public class SendInviteReq
    {
        public string Content { get; set; } = string.Empty;
        [Required]
        public uint InviterId { get; set; }
        [Required]
        public uint InvitedId { get; set; }
    }
}
