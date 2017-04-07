using System;

namespace GitToolbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Arguments(args);
            try
            {
                switch (a.Next)
                {
                    case "only-on-branch":
                        a.Shift();
                        new BranchNotAnyOtherBranches(a.Next).Execute();
                        break;

                    default:
                        if (string.IsNullOrWhiteSpace(a.Next))
                            Console.Error.WriteLine("error: specify command to execute");
                        else
                            Console.Error.WriteLine($"error: unknown command '{a.Next}'");
                        break;
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.Error.WriteLine($"error: {ex.Message}");
                Environment.Exit(1);
            }
        }
    }
}