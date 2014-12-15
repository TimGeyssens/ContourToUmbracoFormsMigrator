using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using umbraco.DataLayer;

namespace Umbraco.Forms.Migration.Interfaces
{
    internal interface ISqlHelperCreator
    {
        ISqlHelper Create(string connString);
    }
}
