﻿using ProjektCSharp.models;
using System.Linq;
namespace ProjektCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string workingDirectory = Environment.CurrentDirectory + "\\images";
            string[] directories = Directory.GetDirectories(workingDirectory, "*", SearchOption.AllDirectories);
            List<Folder> l = new List<Folder>();
            foreach (var d in directories)
            {
                l.Add(new Folder(d, directories.ToList()));
            }
            Console.WriteLine();
            //string path = Directory.GetCurrentDirectory();
            //Console.WriteLine(path);
            //System.IO.DirectoryInfo di = new DirectoryInfo(path+"/images/sub05");
            //foreach (FileInfo file in di.GetFiles().Where(x=>x.FullName.EndsWith("html")))
            //{
            //    file.Delete();
            //}
        }
    }
}