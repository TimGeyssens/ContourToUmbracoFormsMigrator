using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Umbraco.Forms.Migration.Enums;


namespace Umbraco.Forms.Migration
{
    public interface IWorkflow
    {
        Guid Id { get; set; }
        string Name { get; set; }
        Core.WorkflowType Type { get; set; }
        
        FormState ExecutesOn { get; set; }
        
        Dictionary<string, string> Settings { get; set; }
        int SortOrder { get; set; }

    }
}
