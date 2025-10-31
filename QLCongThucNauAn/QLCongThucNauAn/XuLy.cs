using System;
using System.Collections.Generic;
using System.IO;
using QLCongThucNauAn.Data; 

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

        //File ghi lại từ csdl dó
        public static RecipeLinkedList ReadCsvToLinkedList(string filePath)
        {
            RecipeLinkedList list = new RecipeLinkedList();

            try
            {
                var rows = ReadCsvFile(filePath);

                for (int i = 1; i < rows.Count; i++)
                {
                    var row = rows[i];
                    if (row.Length >= 8)
                    {
                        Recipe recipe = new Recipe
                        {
                            Title = row[0],
                            Category = row[1],
                            Subcategory = row[2],
                            Description = row[3],
                            Ingredients = row[4],
                            Directions = row[5],
                            Num_Ingredients = int.Parse(row[6]),
                            Num_Steps = int.Parse(row[7])
                        };

                        list.Add(recipe);
                    }
                }

                Console.WriteLine("Linked List created successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating Linked List: {ex.Message}");
            }

            return list;
        }
    }
}
