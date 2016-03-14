using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeDataAndDoc
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFileName = "defaultInput.txt";
            string outputFileName = "defaultOutput.txt";
            if (args.Length == 2)
            {
                inputFileName = args[0];
                outputFileName = args[1];
            }

            using (StreamReader inputFile = new StreamReader(inputFileName))
            using(StreamWriter outputFile = new StreamWriter(outputFileName))
            {
                string line; //test
                while((line = inputFile.ReadLine()) != null)
                {
                    string outputLine = "***" + line;
                    Console.WriteLine("Write line: " + outputLine);
                    outputFile.WriteLine(outputLine);
                }
            }
        }
        public void readFile(StreamReader input) {
            string linebuf = input.ReadLine();
            char[] cut = {'\t', '\n'};
            string[] col = linebuf.Split(cut);
            foreach (string s in col) {
                Console.WriteLine(s);
            }
        }
    }
}
