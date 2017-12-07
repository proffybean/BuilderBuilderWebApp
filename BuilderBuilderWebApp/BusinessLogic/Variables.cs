using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuilderBuilderWebApp.BusinessLogic
{
    public class Variables
    {
        public string className { get; set; }

        public List<Member> members = new List<Member>();

        public Variables()
        {
            className = "";
        }
    }
}