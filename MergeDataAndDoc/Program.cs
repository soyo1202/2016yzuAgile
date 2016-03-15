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
        public static List<string[]> dataBucket = new List<string[]>();
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
            }
            if (File.Exists(inputFileName))
                fileFound = true;
            else
            {
                fileFound = false;
                Console.WriteLine("Can not found the inputfile : " + inputFileName);
            }
            if (File.Exists(templateFileName))
                fileFound = true;
            else
            {
                Console.WriteLine("Can not found the templatefile : " + templateFileName);
                fileFound = false;
            }
            if (fileFound)
            {
                using (StreamReader inputFile = new StreamReader(inputFileName))
                using (StreamReader templateFile = new StreamReader(templateFileName))
                using (StreamWriter outputFile = new StreamWriter(outputFileName))
                {
                    readFile(inputFile);
                    setTemplete(templateFile);
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
        public static void setTemplete(StreamReader template) {
            char[] cut = { '{', '$', '}' };
            string linebuf = template.ReadToEnd();
            string[] result = linebuf.Split(cut);
            Console.WriteLine("result check: \n");
            foreach (string s in result) {
                Console.Write(s);
            }
        }
        public static void readFile(StreamReader input) {
            string linebuf = input.ReadLine();
            char[] cut = {'\t', '\n'};
            string[] col = linebuf.Split(cut);
            dataBucket.Add(col);
            while (!input.EndOfStream) {
                linebuf = input.ReadLine();
                string[] element = new string[col.Length];
                element = linebuf.Split(cut);
                dataBucket.Add(element);
            }
            foreach (string[] s in dataBucket) {
                foreach (string e in s) {
                    Console.Write(e + " ");
                }
                Console.Write("\n");
            }
        }
    }
}
