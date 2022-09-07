using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagementSystem
{
    class HotelRepositary
    {
        public static void CreateNewHotel(ref List<Hotel> hotels)
        {
            Console.WriteLine("enter how many hotels");
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Hotel hotel = new Hotel();
                Console.WriteLine("enter hotel Id");
                hotel.HotelId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("enter hotel Name");
                hotel.HotelName = Console.ReadLine();
                Console.WriteLine("enter NoOfHotels ");
                hotel.NoOfHotels=Convert.ToInt32 (Console.ReadLine());
                Console.WriteLine("enter Location Name");
                hotel.LocationName = Console.ReadLine();
               
                hotels.Add(hotel);

            }
        }

        public static void DeleteHotel(ref List<Hotel> hotels)
        {
            Console.WriteLine("enter hotel name to delete");
            string n = (Console.ReadLine());
            var find = hotels.Find(x => x.HotelName == n);
            if (find != null)
            {
                Console.WriteLine("enter the number to delete 1 particular HotelName 2 Total Data");
                int num = Convert.ToInt32(Console.ReadLine());
                int i = 0;
                foreach (var item in hotels)
                {
                    if (num == 1)
                    {
                        hotels.RemoveAt(i);
                        Console.WriteLine("data is deleted");
                    }
                    if (num == 2)
                    {
                        hotels.Clear();
                        Console.WriteLine("total data deleted");
                    }
                }
            }
            else
            {
                throw new ExceptiontHandler("HotelName is not found");
            }
        }
       
    }
}
