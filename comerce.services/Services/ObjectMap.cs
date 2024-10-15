using comerce.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comerce.Services.Services
{
    /*verificar que tan necesario es*/
    public class ObjectMap : IObjectMap
    {
        private readonly IObjectMap _objectMap;

        public ObjectMap(IObjectMap objectMap)
        {
            _objectMap = objectMap;
        }
        public T Map<T>(object source)
        {
            var convertSource = _objectMap.Map<T>(source);
            return convertSource;
        }
    }
}
