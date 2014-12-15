using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Umbraco.Forms.Migration
{
    public interface IFieldPreValueSource
    {
        Guid Id { get; set; }
        string Name { get; set; }

        Dictionary<string, string> Settings { get; set; }
        Umbraco.Forms.Core.FieldPreValueSourceType Type { get; set; }
    }
}
