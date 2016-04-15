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
            string inputFileName = "simpleInput.txt";
            string templateFileName = "simpleTemplate.txt";
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
               StreamReader inputFile = new StreamReader(inputFileName);
               StreamReader templateFile = new StreamReader(templateFileName);
               StreamWriter outputFile = new StreamWriter(outputFileName);

               testMethod(inputFile, templateFile, outputFile);
                
            }
        }

        public static void testMethod(TextReader inputFile, TextReader templateFile, TextWriter outputFile)
        {
            readFile(inputFile);
            setTemplete(templateFile, outputFile);
        }
        public static void setTemplete(TextReader template, TextWriter writeFile) {
            string linebuf = template.ReadToEnd();
            string result = linebuf;
            for (int i = 1; i < dataBucket.Count; i++) {
                result = linebuf;
                for (int j = 0; j < dataBucket[0].Length; j++)
                {
                   result = result.Replace("${"+dataBucket[0][j]+"}", dataBucket[i][j]);
                }
                Console.WriteLine(result);
                writeFile.WriteLine(result);
            }
            writeFile.Close();
        }
        public static void readFile(TextReader input) {
            string linebuf = input.ReadLine();
            char[] cut = {'\t', '\n'};
            string[] col = linebuf.Split(cut);
            dataBucket.Add(col);
            while ( (linebuf = input.ReadLine()) != null) {
                string[] element = new string[col.Length];
                element = linebuf.Split(cut);
                dataBucket.Add(element);
            }
        }
    }
}
