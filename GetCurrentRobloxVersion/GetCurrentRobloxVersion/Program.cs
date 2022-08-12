using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetCurrentRobloxVersion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Keep in mind this is NOT api-based. This app will not grab the latest version UNLESS the local-user has it installed. It's just a thing to add to a executor or something.
            Console.WriteLine("[FINDER] Roblox Version Grabber Through LocalAppData");
            Console.WriteLine("Hello! Welcome! This is a simplistic Roblox Version grabber, if you need it for some reason. Anyways, you can take the source of this program, and implement it into yours.");
            var lad = $"C:\\Users\\{Environment.UserName}\\AppData\\Local\\Roblox\\Versions";
            Console.WriteLine("[FOUND] LocalAppData was found!");

            foreach (var flds in Directory.GetDirectories(lad))
            {
                // most likely wont happen, but just to make sure. 
                var i = new DirectoryInfo(flds);
                if (i.GetFiles().Length == 0 || i.GetDirectories().Length == 0)
                {
                    Console.WriteLine("[FINDER] Found corrupted version: " + i.FullName);
                }

                if (i.GetFiles().Length != 0)
                {
                    // Checks for builtinplugins, it's a folder, when that roblox ver is outdated
                    foreach (var fe in Directory.GetFiles(i.FullName))
                    {
                        var fileInfo1 = new FileInfo(fe);
                        if (Directory.Exists(i.FullName + "BuiltInPlugins"))
                        {
                            Console.WriteLine("[FINDER] Found old version: " + i.FullName);
                        }
                    }
                }

                if (File.Exists(i.FullName + "\\RobloxPlayerBeta.exe"))
                {
                    Console.WriteLine("[RESULTS] Found Latest Version! - " + i.FullName);
                }
            }

            Console.ReadLine();
        }
    }
}
