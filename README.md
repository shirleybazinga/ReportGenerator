# ReportGenerator

This is a Console App to genrate report file for "Product type - Broker" combination.

## Usage

Pre-requisite:
Visual Studio 2022 with .NET 6.0 or above

Run Unit Test:
1. Use Visual Studio to open solution file ReportGenerator.sln
2. From toolbar, select "Test" then click "Run All Tests"

Build Release:
1. Use Visual Studio to open solution file ReportGenerator.sln
2. Set Solution Configurations to "Release"
3. Set Startup Projects to "ReportGenerator"
4. Run "Start Without Debugging"

Run the app via command line:
For example, if you want to generate report file for "Fx Forward Trade, Broker-A" on "8 Jul 2021", and output the file to current directory (same as the directory of solution file ReportGenerator.sln), please run:

```bash
cd ReportGenerator\bin\Release\net6.0
ReportGenerator.exe -p FxForward -b Broker-A -d "8 Jul 2021" -v -t -o "..\..\..\..\fwd-a-20210708.csv"
```

Sample command for other "Product type - Broker" combination:

```bash
ReportGenerator.exe -p FxForward -b Broker-B -d "15 Jul 2021" -v -t -o "..\..\..\..\fwd-b-20210715.csv"
ReportGenerator.exe -p BondFuture -b Broker-A -d "12 Jul 2021" -v -t -o "..\..\..\..\bf-a-20210712.csv"
ReportGenerator.exe -p BondFuture -b Broker-B -d "17 Jul 2021" -v -t -o "..\..\..\..\bf-b-20210717.csv"
ReportGenerator.exe -p InterestRateSwap -b Broker-A -d "14 Jul 2021" -v -t -o "..\..\..\..\irs-a-20210714.csv"
ReportGenerator.exe -p InterestRateSwap -b Broker-B -d "15 Jul 2021" -v -t -o "..\..\..\..\irs-b-20210715.csv"
ReportGenerator.exe -p Others -b Broker-A -d "13 Jul 2021" -v -t -o "..\..\..\..\oth-a-20210713.csv"
ReportGenerator.exe -p Others -b Broker-B -d "19 Jul 2021" -v -t -o "..\..\..\..\oth-b-20210719.csv"
```

For more details about the input parameters, please run:
```bash
ReportGenerator.exe --help
```

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.
