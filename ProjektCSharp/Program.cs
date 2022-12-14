using ProjektCSharp.models;
using System.IO;
using System.Linq;
namespace ProjektCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if(args.Length<2)
            {
                Console.WriteLine("Adjon meg egy elérési utat");
                return;
            }
            string workingDirectory = args[1];
            List<string> directories = Directory.GetDirectories(workingDirectory, "*", SearchOption.AllDirectories).ToList();
            directories.Add(workingDirectory);
            if (args.Length > 2 && args[2] == "clr")
            {
                ClearHtml(directories);
                return;
            }
            List<Folder> l = new List<Folder>();
            l.Add(new Folder(workingDirectory, directories));
            foreach (var d in directories)
            {
                l.Add(new Folder(d, directories));
                if (args.Length>2 && args[2]=="clr")
                {
                    DirectoryInfo di = new DirectoryInfo(d);
                    foreach (FileInfo file in di.GetFiles().Where(x => x.FullName.EndsWith("html")))
                    {
                        file.Delete();
                    }
                }
            }
            Console.WriteLine();
            Html.Create(l);
        }
        static void ClearHtml(List<string> directories)
        {
            foreach (var d in directories)
            {
                DirectoryInfo di = new DirectoryInfo(d);
                foreach (FileInfo file in di.GetFiles().Where(x => x.FullName.EndsWith("html")))
                {
                    file.Delete();
                }
            }
        }
    }
}