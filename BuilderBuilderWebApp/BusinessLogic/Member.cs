using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuilderBuilderWebApp.BusinessLogic
{
    public class Member
    {
        public Member(string type, string variable)
        {
            this.type = type;
            this.Variable = variable;
        }

        public string type { get; set; }
        public string Variable { get; set; }
    }
}