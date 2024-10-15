using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comerce.Core.Interfaces
{
    /*revisar que tan necesario es que exista*/
    public interface IObjectMap
    {
        T Map<T>(object source);
    }
}
