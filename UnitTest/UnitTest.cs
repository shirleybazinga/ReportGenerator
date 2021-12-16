using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using static System.IO.Directory;
using static ReportGenerator.Program;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        /* Sample command line params
            -p FxForward -b Broker-A -d "8 Jul 2021" -v -t -o "..\..\..\..\fwd-a-20210708.csv"
            -p FxForward -b Broker-B -d "15 Jul 2021" -v -t -o "..\..\..\..\fwd-b-20210715.csv"
            -p BondFuture -b Broker-A -d "12 Jul 2021" -v -t -o "..\..\..\..\bf-a-20210712.csv"
            -p BondFuture -b Broker-B -d "17 Jul 2021" -v -t -o "..\..\..\..\bf-b-20210717.csv"
            -p InterestRateSwap -b Broker-A -d "14 Jul 2021" -v -t -o "..\..\..\..\irs-a-20210714.csv"
            -p InterestRateSwap -b Broker-B -d "15 Jul 2021" -v -t -o "..\..\..\..\irs-b-20210715.csv"
            -p Others -b Broker-A -d "13 Jul 2021" -v -t -o "..\..\..\..\oth-a-20210713.csv"
            -p Others -b Broker-B -d "19 Jul 2021" -v -t -o "..\..\..\..\oth-b-20210719.csv"
        */

        const string SRC_DIR = "ExpectedOutput";
        const string DEST_DIR = "ActualOutput";
        static readonly string projectDir = GetParent(GetParent(GetParent(GetCurrentDirectory()).FullName).FullName).FullName;
        static readonly string destDir = Path.Combine(projectDir, DEST_DIR);

        [TestMethod]
        public void TestFxForwardA()
        {
            var opts = new Options
            {
                Product = "FxForward",
                Broker = "Broker-A",
                Date = DateTime.Parse("8 Jul 2021"),
                Verbose = true,
                UnitTest = true,
                OutputPath = Path.Combine(destDir, "fwd-a-20210708.csv"),
            };
            TestRunOptions(opts);
        }

        [TestMethod]
        public void TestFxForwardB()
        {
            var opts = new Options
            {
                Product = "Fx Forward",
                Broker = "Broker-B",
                Date = DateTime.Parse("15 Jul 2021"),
                Verbose = true,
                UnitTest = true,
                OutputPath = Path.Combine(destDir, "fwd-b-20210715.csv"),
            };
            TestRunOptions(opts);
        }

        [TestMethod]
        public void TestBondFutureA()
        {
            var opts = new Options
            {
                Product = "BondFuture",
                Broker = "Broker-A",
                Date = DateTime.Parse("12 Jul 2021"),
                Verbose = true,
                UnitTest = true,
                OutputPath = Path.Combine(destDir, "bf-a-20210712.csv"),
            };
            TestRunOptions(opts);
        }

        [TestMethod]
        public void TestBondFutureB()
        {
            var opts = new Options
            {
                Product = "Bond Future",
                Broker = "Broker-B",
                Date = DateTime.Parse("17 Jul 2021"),
                Verbose = true,
                UnitTest = true,
                OutputPath = Path.Combine(destDir, "bf-b-20210717.csv"),
            };
            TestRunOptions(opts);
        }

        [TestMethod]
        public void TestBondFutureC()
        {
            var opts = new Options
            {
                Product = "Bond Future",
                Broker = "Broker-C",
                Date = DateTime.Parse("20 Jul 2021"),
                Verbose = true,
                UnitTest = true,
                OutputPath = Path.Combine(destDir, "bf-c-20210720.csv"),
            };
            TestRunOptions(opts);
        }

        [TestMethod]
        public void TestInterestRateSwapA()
        {
            var opts = new Options
            {
                Product = "InterestRateSwap",
                Broker = "Broker-A",
                Date = DateTime.Parse("14 Jul 2021"),
                Verbose = true,
                UnitTest = true,
                OutputPath = Path.Combine(destDir, "irs-a-20210714.csv"),
            };
            TestRunOptions(opts);
        }

        [TestMethod]
        public void TestInterestRateSwapB()
        {
            var opts = new Options
            {
                Product = "Interest Rate Swap",
                Broker = "Broker-B",
                Date = DateTime.Parse("15 Jul 2021"),
                Verbose = true,
                UnitTest = true,
                OutputPath = Path.Combine(destDir, "irs-b-20210715.csv"),
            };
            TestRunOptions(opts);
        }

        [TestMethod]
        public void TestOthersA()
        {
            var opts = new Options
            {
                Product = "Others",
                Broker = "Broker-A",
                Date = DateTime.Parse("13 Jul 2021"),
                Verbose = true,
                UnitTest = true,
                OutputPath = Path.Combine(destDir, "oth-a-20210713.csv"),
            };
            TestRunOptions(opts);
        }

        [TestMethod]
        public void TestOthersB()
        {
            var opts = new Options
            {
                Product = "Others",
                Broker = "Broker-B",
                Date = DateTime.Parse("19 Jul 2021"),
                Verbose = true,
                UnitTest = true,
                OutputPath = Path.Combine(destDir, "oth-b-20210719.csv"),
            };
            TestRunOptions(opts);
        }

        private void TestRunOptions(Options opts)
        {
            RunOptions(opts);

            var fileName = Path.GetFileName(opts.OutputPath);

            //if (string.Compare(opts.Product.Replace(" ", ""), "BondFuture", true) == 0)
            //{
            //    var fileNameNoExt = Path.GetFileNameWithoutExtension(fileName);
            //    fileName = fileName.Replace(fileNameNoExt, $"{fileNameNoExt}-{opts.Broker}");
            //}

            var srcpath = Path.Combine(projectDir, SRC_DIR, fileName);
            var destPath = Path.Combine(destDir, fileName);
            CompareFile(srcpath, destPath);
        }

        private void CompareFile(string src, string dest)
        {
            var srcString = File.ReadAllText(src);
            var destString = File.ReadAllText(dest);
            Assert.AreEqual(srcString, destString);
        }
    }
}