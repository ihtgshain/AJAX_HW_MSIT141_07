﻿using System;
using System.Collections.Generic;

#nullable disable

namespace AJAX_HW_MSIT141_07.Models
{
    public partial class Member
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int? Age { get; set; }
        public string FileName { get; set; }
        public byte[] FileData { get; set; }
    }
}
