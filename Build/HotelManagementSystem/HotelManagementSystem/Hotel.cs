using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace HotelManagementSystem
{
    [Serializable]
   public class Hotel:IComparable<Hotel>
    {
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public int NoOfHotels { get; set; }
        public string LocationName { get; set; }
        

        public static void DisplayHotel(ref List<Hotel> hotels)
        { 
 
            Console.WriteLine("Hotel details are");
            foreach (var sd in hotels)
            {
                Console.WriteLine("HotelId:{0}\nHotelName:{1}\nNoOfHotels:{2}\nLocationName:{3}",sd.HotelId,sd.HotelName,sd.NoOfHotels,sd.LocationName);
            }
        }

        public int CompareTo([AllowNull] Hotel other)
        {
            return this.HotelName.CompareTo(other.HotelName);
        }
    }
}
