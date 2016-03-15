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
            bool fileFound = false;
            string inputFileName = "defaultInput.txt";
            string templateFileName = "";
            string outputFileName = "defaultOutput.txt";
            if (args.Length >0)
            {
                for (int i = 0; i < args.Length; i++) {
                    if (args[i] == "-r") {
                        outputFileName = args[i + 1];
                        i++;
                        continue;
                    }
                    if (args[i] == "-i") {
                        inputFileName = args[i+1];
                        i++;
                        continue;
                    }
                    if (args[i] == "-t") {
                        templateFileName = args[i + 1];
                        i++;
                        continue;
                    }
                }
                Console.Write(inputFileName);
                Console.Write(outputFileName);
                Console.Write(templateFileName);
            }
            if (File.Exists(inputFileName))
                fileFound = true;
            else
                Console.WriteLine("Can not found the inputfile : " + inputFileName);
            if (File.Exists(templateFileName))
                fileFound = true;
            else
                Console.WriteLine("Can not found the templatefile : " + templateFileName);
            if (fileFound)
            {
                using (StreamReader inputFile = new StreamReader(inputFileName))
                using (StreamWriter outputFile = new StreamWriter(outputFileName))
                {
                    readFile(inputFile);
                    string line; //test
                    while ((line = inputFile.ReadLine()) != null)
                    {
                        string outputLine = "***" + line;
                        Console.WriteLine("Write line: " + outputLine);
                        outputFile.WriteLine(outputLine);
                    }
                }
            }
        }
        public static void readFile(StreamReader input) {
            string linebuf = input.ReadLine();
            char[] cut = {'\t', '\n'};
            string[] col = linebuf.Split(cut);
            foreach (string s in col) {
                Console.WriteLine(s);
            }
        }
    }
}
