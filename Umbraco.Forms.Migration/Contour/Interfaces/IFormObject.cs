using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Umbraco.Forms.Migration
{
    public interface IFormObject
    {
        Guid Id
        {
            get;
            set;
        }
    }
}
