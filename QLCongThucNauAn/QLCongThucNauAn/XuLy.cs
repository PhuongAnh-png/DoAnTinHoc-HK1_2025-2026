using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace QLCongThucNauAn
{
    internal class XuLy
    {
        public static List<string[]> ReadCsvFile(string filePath)
        {
            List<string[]> rows = new List<string[]>();

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] values = line.Split(',');
                    rows.Add(values);
                }

                Console.WriteLine("CSV file read successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return rows;
        }


    }
}
