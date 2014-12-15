using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using umbraco.DataLayer;
using Umbraco.Forms.Migration.Interfaces;

namespace Umbraco.Forms.Migration.Providers
{
    public class V6SqlHelperCreator : ISqlHelperCreator
    {
        public umbraco.DataLayer.ISqlHelper Create(string connString)
        {
            return DataLayerHelper.CreateSqlHelper(connString, false);
        }
    }
}
