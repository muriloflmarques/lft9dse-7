using System;

namespace Scm.Infra.CrossCutting
{
    public class EnumValueAsText: Attribute
    {
        public EnumValueAsText(string value)
        {
            Value = value;
        }

        public string Value { get; }
    }
}