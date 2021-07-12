using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLineUtility;

namespace ArgyBargyExample01
{
    class Program
    {
        static void Main(string[] args)
        {
            ExampleArgs ea = new ExampleArgs();
            CmdArgManager cam = new CmdArgManager(ea, args, "Example command line usage");

            CmdArgManager.ExitCode result = cam.ParseArgs();
            if (result == CmdArgManager.ExitCode.Success)
            {
                Console.WriteLine(String.Empty);
                Console.WriteLine("ExampleArgs property values are:");
                Console.WriteLine(ea.ToString());
            }
            else
            {
                Console.WriteLine(cam.ErrorMessage);
            }

            Console.WriteLine(String.Empty);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}

public class ExampleArgs
{
    const bool REQUIRED = true;
    const bool OPTIONAL = false;

    [CmdArg("--databasename", "-d", REQUIRED, "Database name")]
    public string databasename { get; set; }

    [CmdArg("--file", "-f", REQUIRED, "File name")]
    public string file { get; set; }

    [CmdArg("--outputpath", "-o", OPTIONAL, "Output path")]
    public string outputpath { get; set; } = "default output path";

    [CmdArg("--blockfactor", "-b", OPTIONAL, "Recording blocking factor")]
    public int blockfactor { get; set; } = 500;

    [CmdArg("--noheadings", "-nh", OPTIONAL, "Do not include headings row")]
    public bool noheadings { get; set; } = false;

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append(String.Format("{0} {1}\n", "databasename..:", this.databasename));
        sb.Append(String.Format("{0} {1}\n", "file..........:", this.file));
        sb.Append(String.Format("{0} {1}\n", "outpath.......:", this.outputpath));
        sb.Append(String.Format("{0} {1}\n", "blockfactor...:", this.blockfactor));
        sb.Append(String.Format("{0} {1}\n", "noheadings....:", this.noheadings));

        return sb.ToString();
    }
}




//--databasename "Production" --file "MyFile" --outputpath "c:\output" --blockfactor 500 --headings