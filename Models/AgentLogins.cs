using System;
using System.Collections.Generic;

namespace Support.Models
{
    public partial class AgentLogins
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public bool? Valid { get; set; }
        public DateTime? LoginDate { get; set; }
    }
}
