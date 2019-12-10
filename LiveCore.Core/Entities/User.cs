using System;
using System.Collections.Generic;
using System.Text;

namespace LiveCore.Core.Entities
{
    public class User:Entity
    {
        public string UUID { get; set; }
        public string UserName { get; set; }
        public string Pwd { get; set; }
    }
}
