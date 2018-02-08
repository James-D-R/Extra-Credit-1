using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_and_Streams_Exercise_4
{
    class Customer
    {
        static void Main(string[] args)
        {
            FileStream data = new FileStream ("Employee data.csv", FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(data);
            int enteredValue = WriteCustomerRecords(data, writer);
            Console.Clear();
            ReadCustomerRecords(enteredValue);
        }
        static int WriteCustomerRecords(FileStream data, StreamWriter writer)
        {
            string[] IDnumber = { };
            string[] name = { };
            string[] balanceOwed = { };

            Console.WriteLine("Please enter the number of customers.");
            string a = Console.ReadLine();
            int enteredValue = Int32.Parse(a);
            for (var i = 0; i < enteredValue; i++)
            {
                Console.WriteLine("Enter customer ID number:");
                string b = Console.ReadLine();
                string[] enteredID = { b };
                IDnumber = IDnumber.Concat(enteredID).ToArray();

                Console.WriteLine("Enter customer name:");
                string c = Console.ReadLine();
                string[] enteredName = { c };
                name = name.Concat(enteredName).ToArray();

                Console.WriteLine("Enter customer's current balance owed:");
                string d = Console.ReadLine();
                string[] enteredBalance = { d };
                balanceOwed = balanceOwed.Concat(enteredBalance).ToArray();
            }
            for (int x = 0; x < enteredValue; x++)
            {
                writer.WriteLine("{0},{1},{2}", IDnumber[x], name[x], balanceOwed[x]);
               // writer.WriteLine(name[x]);
               // writer.WriteLine(balanceOwed[x]);
            }
            /*for (int x = 0; x < enteredValue; x++)
            {
                writer.WriteLine("{0}", name[x]);
            }
            for (int x = 0; x < enteredValue; x++)
            {
                writer.WriteLine("{0}", balanceOwed);
            }*/

            writer.Close(); data.Close();
            return enteredValue;
        }
        static void ReadCustomerRecords(int enteredValue)
        {
            FileStream file = new FileStream("Employee data.csv", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(file);

            Console.WriteLine("Printing off customer data...\n");

            for (int x = 0; x < enteredValue; x++)
            {
                string names = reader.ReadLine();
                Char delimeter = ',';
                string[] namesList = names.Split(delimeter);
                string a = namesList[0];
                string b = namesList[1];
                string c = namesList[2];
                string customerData = ("ID:"+a + " Name:"+ b + " Balance Due:" + c);
                Console.WriteLine(customerData);
            }
            
            Console.ReadKey();
        }
    }
}
