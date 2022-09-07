using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;


namespace HotelManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Hotel> hotels = new List<Hotel>();
            bool condition = true;
            while (condition)
            {
                Console.WriteLine("HotelManagementSystem");
                Console.WriteLine("1 create hotel details");
                Console.WriteLine("2 delete hotel details");
                Console.WriteLine("3 sort hotel details");
                Console.WriteLine("4 save toexcel hotel details");
                Console.WriteLine("5 serialize hotel details");
                Console.WriteLine("6 deserialize hotel details");
                Console.WriteLine("7 display hotel details");

                int number = Convert.ToInt32(Console.ReadLine());
                try
                {
                    switch (number)
                    {
                        case 1:
                            HotelRepositary.CreateNewHotel(ref hotels);
                            break;
                        case 2:
                            HotelRepositary.DeleteHotel(ref hotels);
                            break;

                        case 3:
                            hotels.Sort();
                            foreach (var sd in hotels)
                            {
                                Console.WriteLine("HotelName:{ 0}", sd.HotelName);
                            }

                            break;
                        case 4:
                            HotelFile.SaveToExcel(ref hotels);
                            break;
                           
                           case 5:
                            string filePath = "data-save";

                            HotelFile.SerializeHotel(ref hotels, filePath);

                            break;
                        case 6:
                            List<Hotel> s = null;
                            string filePaths = "data-save";
                            s = HotelFile.DeserializeHotel(filePaths) as List<Hotel>;
                            foreach (var sd in hotels)
                            {
                                Console.WriteLine("HotelId:{0}\nHotelName:{1}\nNoOfHotels:{2}\nLocationName",sd.HotelId,sd.HotelName,sd.NoOfHotels,sd.LocationName);
                            }
                            break;
                        case 7:
                            Hotel.DisplayHotel(ref hotels);
                            break;


                        case 8:
                            condition = false;
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            }
        }
}
