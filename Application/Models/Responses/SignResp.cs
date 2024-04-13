﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Responses
{
    public class SignResp
    {
        public uint Id { get; set; }
        [Required]
        public required string Token { get; set; }
    }
}
