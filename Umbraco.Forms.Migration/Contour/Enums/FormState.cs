using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Umbraco.Forms.Migration.Enums {
    public enum FormState {
        Opened,
        Resumed,
        PartiallySubmitted,
        Submitted,
        Approved,
        Deleted
    }
}
