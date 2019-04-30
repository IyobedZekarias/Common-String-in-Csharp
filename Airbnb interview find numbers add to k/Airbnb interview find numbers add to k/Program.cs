using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb_interview_find_numbers_add_to_k
{
    class Program
    {
        
        static void Main(string[] args)
        {
            ArrayList values = new ArrayList();

            Console.Write("How many numbers will be in your list?  ");
            string numofnums = Console.ReadLine();
            int numofnum = Int32.Parse(numofnums);

            for(int i = 0; i < numofnum; i++)
            {
                Console.WriteLine("Enter number:  ");
                values.Add(Int32.Parse(Console.ReadLine()));
            }

            Console.Write("What is k?  ");
            int k = Int32.Parse(Console.ReadLine());

            DataTable nums = Findnum(values, k);

            foreach (DataRow row in nums.Rows)
            {
                // ... Write value of first field as integer.
                Console.WriteLine(row.Field<int>(0) + " " + row.Field<int>(1));
            }

            Console.ReadLine();
        }

        public static DataTable Findnum(ArrayList values, int k)
        {
            DataTable table = new DataTable();
            table.Columns.Add("first", typeof(int));
            table.Columns.Add("second", typeof(int));

            for (int i = 0; i < values.Count; i++)
            {
                int currentnumI = (int)values[i];
                for(int j = 0; j < values.Count; j++)
                {
                    int currentnumJ = (int)values[j];
                    if(j != i)
                    {
                        if((currentnumI + currentnumJ) == k)
                        {
                            table.Rows.Add(currentnumI, currentnumJ);
                            Console.WriteLine(currentnumI + " " + currentnumJ);
                            values.Remove(currentnumI);
                            values.Remove(currentnumJ);
                            break;
                        }
                    }
                }
            }

            

            return table;
        }
    }
}
