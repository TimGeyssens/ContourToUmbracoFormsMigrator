using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Umbraco.Forms.Migration {
    public enum WorkflowExecutionStatus {
        Failed,
        NotConfigured,
        Cancelled,
        Completed
    }
}
