using ExtensibleDiagnosticIntefaces;
using System;
using System.Collections.Generic;
using System.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace Albero
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteHeader();

            var runners = Compose();
            if (runners == null || runners.Count() == 0)
            {
                Console.WriteLine("Failed to find any plugins");
                return;
            }
            var dr = new DiagnosticRunner(runners);

            dr.Run();
        }


        private static IEnumerable<IDiagnositicRunner> Compose()
        {
            var executableLocation = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            var path = Path.Combine(executableLocation, "Plugins");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var assemblies = Directory
                        .GetFiles(path, "*.dll", SearchOption.AllDirectories)
                        .Select(AssemblyLoadContext.Default.LoadFromAssemblyPath)
                        .ToList();
            var configuration = new ContainerConfiguration()
                .WithAssemblies(assemblies);
            using (var container = configuration.CreateContainer())
            {
                return container.GetExports<IDiagnositicRunner>();
            }
        }

        private static void WriteHeader()
        {
            Console.WriteLine(@"
                 _    _ _                     
                / \  | | |__   ___ _ __ ___   
               / _ \ | | '_ \ / _ \ '__/ _ \  
              / ___ \| | |_) |  __/ | | (_) | 
             /_/   \_\_|_.__/ \___|_|  \___/  ");
             Console.Write("\r\n");
        }
    }
}
