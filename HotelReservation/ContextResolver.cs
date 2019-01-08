using DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation
{
    public class ContextResolver
    {
        public static HotelContext GetContext(string connectionString)
        {
            return new HotelContext(connectionString);
        }
    }
}
