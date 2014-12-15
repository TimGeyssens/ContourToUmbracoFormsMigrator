using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Umbraco.Forms.Migration
{
    public enum FieldConditionRuleOperator
    {
        Is,
        IsNot,
        GreaterThen,
        LessThen,
        Contains,
        StartsWith,
        EndsWith
    }
}
