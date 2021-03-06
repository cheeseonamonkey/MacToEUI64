using System;
using static System.Console;

namespace MacConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("\tMac to EUI-64:\n___________________\n");
            WriteLine("\tEnter MAC address (i.e. 0015.2BE4.9B60) or \"A\" for an example: ");

            string mac = ReadLine();

            //sets example
            if (mac.ToLower().Equals("a"))
            {
                mac = "0015.2BE4.9B60";
                WriteLine("\n\tExample address:\n" + mac + "\n");
            }

            WriteLine("\n\tSplit mac address down middle:\n");
            string split1 = mac.Substring(0, 6);
            string split2 = mac.Substring(7, 6);
            WriteLine($"{split1}\t{split2}");

            WriteLine("\n\tInsert FF:FE in the middle:\n");
            mac = split1 + "FF:FE" + split2;
            WriteLine(mac);

            WriteLine("\n\tChange the format to use a colon delimiter:\n");
            mac = mac.Replace('.', ':');
            WriteLine(mac);

            WriteLine("\n\tConvert the first eight bits to binary:\n");
            
            string firstEight = mac.Substring(0,2);
            string otherStuff = mac.Substring(2);
            string firstEightBinary = Convert.ToString(Convert.ToInt32(firstEight, 16), 2).PadLeft(8, '0');

            WriteLine(firstEightBinary);


            WriteLine("\n\tflip 7th bit:\n");

            
            char[] chars = firstEightBinary.ToCharArray();


            if (chars[6] == '1')
                chars[6] = '0';
            else if (chars[6] == '0')
                chars[6] = '1';

            string newBits = "";
            foreach (char c in chars)
                newBits += c;

            WriteLine(newBits);

            WriteLine("\n\tConvert these first 8 bits back to hex:\n");

            byte shortie = (byte) Convert.ToSByte(newBits, 2);
            string hexStr = shortie.ToString("X").PadLeft(2, '0') ;

            WriteLine(hexStr);

            WriteLine("\n\tPut address back together:\n");

            Write($"{hexStr}{otherStuff}");

            WriteLine("\n\tDone! Press any key to continue...");
            ReadKey();


        }
    }
}
