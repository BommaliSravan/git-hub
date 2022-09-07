using System;
using System.Collections.Generic;
using System.Text;
using Ganss.Excel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace HotelManagementSystem
{
    class HotelFile
    {
        
        public static void SaveToExcel(ref List<Hotel> hotels)
        {
            ExcelMapper mapper = new ExcelMapper();
            var data = @"C:\Users\mindc1july50\source\repos\TicketAllocationSystem\HotelDetails";
            mapper.Save(data, hotels, "SheetName", true);
            Console.WriteLine("stored in excel");
        }
        public static void SerializeHotel(ref List<Hotel> hotels, string filePath)
        {
            FileStream fileStream;
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            if (File.Exists(filePath)) File.Delete(filePath);
            fileStream = File.Create(filePath);
            binaryFormatter.Serialize(fileStream, hotels);
            fileStream.Close();
            Console.WriteLine("successfully serialize)");
        }
        public static object DeserializeHotel(string filePath)
        {
            List<Hotel> obj = null;
            FileStream fileStream;
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            if (File.Exists(filePath))
            {
                fileStream = File.OpenRead(filePath);
                obj = (List<Hotel>)binaryFormatter.Deserialize(fileStream);
                fileStream.Close();
            }
            return obj;
        }




    }
}
