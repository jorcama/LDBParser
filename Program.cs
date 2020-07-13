using System.Collections.Generic;
using System.IO;

namespace LDBParser
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(@"C:\_jorge\meta4\LDBParser\ldb1-RICH1-A.txt");

            bool inside = false;
            List<string> result = new List<string>();

            foreach (string line in lines)
            {
                if (line.StartsWith(">>>C6<<< User"))
                {
                    inside = true;

                }
                else if (line.StartsWith(">>>"))
                {
                    inside = false;
                    if (result.Count > 0) { 
                        result.RemoveAt(result.Count - 1);
                    }
                }

                if (inside && !line.StartsWith(">>>"))
                {
                    result.Add(line);
                }
            }

            File.WriteAllLines(@"c:\temp\C6_HH01RSANJOSE.new.txt", result);
        }
    }
}
