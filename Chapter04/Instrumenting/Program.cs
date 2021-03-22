using System;
using System.Diagnostics;
using System.IO;
using static System.Console;
using Microsoft.Extensions.Configuration;


namespace Instrumenting
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a text file in the project folder
            Trace.Listeners.Add(new TextWriterTraceListener(File.CreateText("log.txt")));

            //text writer is buffered , so this option calls
            //Flush() on all listerners after writing
            Trace.AutoFlush = true;
            Debug.WriteLine("Debug says, Im Watching!");

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json",
                optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            var ts = new TraceSwitch(
                displayName: "PacktSwitch",
                description: "This switch is set via a JSON config.");

            configuration.GetSection("PacktSwitch").Bind(ts);

            Trace.WriteLineIf(ts.TraceError, "Trace error");
            Trace.WriteLineIf(ts.TraceWarning, "Trace warning");
            Trace.WriteLineIf(ts.TraceInfo, "Trace information");
            Trace.WriteLineIf(ts.TraceVerbose, "Trace verbose");
        }
    }
}
