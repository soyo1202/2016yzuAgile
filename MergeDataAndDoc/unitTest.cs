using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;

namespace MergeDataAndDoc
{
    [TestFixture]
    class unitTest
    {
        [Test]
        void refectorSuccess() {
            StringReader dataReader  = new StringReader("");
            StringReader tempReader = new StringReader("");
            StringWriter writer = new StringWriter();
            Program.testMethod(dataReader, tempReader, writer);
            Assert.That(dataReader.ToString(), Is.EqualTo("123"));
            Console.WriteLine(dataReader.ToString());
        }
    }
}
