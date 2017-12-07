using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuilderBuilderWebApp.BusinessLogic
{
    public class Printer
    {
        private Variables v;
        private StringBuilder stringBuilder = new StringBuilder();

        public Printer(Variables v)
        {
            this.v = v;
        }

        public void PrintBuilderClassHeader()
        {
            stringBuilder.Append($"public class {v.className}Builder").AppendLine();
            stringBuilder.Append("{").AppendLine();
        }

        public void PrintMembersDeclarations()
        {
            foreach (Member item in v.members)
            {
                stringBuilder.Append($"\tprivate {item.type} {item.Variable.Privatize()};").AppendLine();
            }
            stringBuilder.AppendLine();
        }

        public void PrintWithDefaulValues()
        {
            stringBuilder.Append($"\tpublic {v.className}Builder WithDefaultValues()").AppendLine();
            stringBuilder.Append("\t{").AppendLine();

            foreach (Member m in v.members)
            {
                stringBuilder.Append($"\t\tthis.{m.Variable.Privatize()} = ,").AppendLine();
            }

            stringBuilder.AppendLine();
            stringBuilder.Append($"\t\treturn this;").AppendLine();
            stringBuilder.Append("\t}").AppendLine();
            stringBuilder.AppendLine();
        }

        public void PrintWithMethods()
        {
            foreach (Member item in v.members)
            {
                stringBuilder.Append($"\tpublic {v.className}Builder With{item.Variable}({item.type} {item.Variable})").AppendLine();
                stringBuilder.Append("\t{").AppendLine();
                stringBuilder.Append($"\t\tthis.{item.Variable.Privatize()} = {item.Variable};").AppendLine();
                stringBuilder.Append($"\t\treturn this;").AppendLine();
                stringBuilder.Append("\t}").AppendLine();
                stringBuilder.AppendLine();
            }
        }

        public void PrintBuildMethod()
        {
            stringBuilder.Append($"\tpublic {v.className} Build()").AppendLine();
            stringBuilder.Append("\t{").AppendLine();
            stringBuilder.Append($"\t\treturn new {v.className}").AppendLine();
            stringBuilder.Append("\t\t{").AppendLine();

            foreach (Member m in v.members)
            {
                stringBuilder.Append($"\t\t\t{m.Variable} = {m.Variable.Privatize()},").AppendLine();
            }

            stringBuilder.Append("\t\t};").AppendLine();
            stringBuilder.Append("\t}").AppendLine();
        }

        public void PrintLastLine()
        {
            stringBuilder.Append("}").AppendLine();
        }

        internal string PrintBuilderClass()
        {
            PrintBuilderClassHeader();
            PrintMembersDeclarations();
            PrintWithDefaulValues();
            PrintWithMethods();
            PrintBuildMethod();
            PrintLastLine();
            return stringBuilder.ToString();
        }
    }
}