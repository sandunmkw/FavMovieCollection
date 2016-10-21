using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public static class ApplicationExt
    {
        public static T GetValue<T>(this IDataReader reader, string MapName)
        {
            int ordinal = reader.GetOrdinal(MapName);
            var obj = reader.GetValue(ordinal);
            if (obj != DBNull.Value)
            {
                return obj != null ? (T)obj : default(T);
            }
            else
            {
                return default(T);
            }
        }
    }
}
