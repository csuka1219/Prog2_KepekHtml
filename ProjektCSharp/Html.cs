using Microsoft.VisualBasic;
using ProjektCSharp.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProjektCSharp
{
    public static class Html
    {
        public static void Create(List<Folder> folders)
        {
            List<string> ext = new List<string>() { "png", "jpg", "jpeg", "gif" };
            var wd=Environment.CurrentDirectory + "\\images";
            foreach (Folder folder in folders)
            {
                CreateFolderPage(folder);
                foreach (var file in Directory.GetFiles(folder.Path))
                {
                    if(ext.Any(x=> file.EndsWith(x)))
                    {
                        //kép oldalak
                        CreateImagePage(folder, file);
                    }
                }
            }
        }
        private static void CreateFolderPage(Folder f)
        {
            using (StreamWriter sw = new StreamWriter(f.Path+ "\\index.html"))
            {
                sw.WriteLine("<html><head><title>Projekt</title></head>\n");
                sw.WriteLine("<h1><a href = \"" + Environment.CurrentDirectory + "\\images\\index.html" + "\">Home Page</a></h1>\n");
                if (!f.Path.EndsWith("images"))
                {
                    sw.WriteLine("<p><a href=\"../index.html\">"+"< - "+f.ParentFolder.Split("\\").Last() +"</a></p>\n");
                }
                sw.WriteLine("<hr><h2>Folders</h2>\n");
                sw.WriteLine("<ul>");
                foreach (var sf in f.SubFolders)
                {
                    string folderName = sf.Split("\\").Last();
                    sw.WriteLine("<li><a href=\"" + folderName + "/index.html\">" + folderName + "</a></li>\n");
                }
                sw.WriteLine("</ul>");
                sw.WriteLine("<hr><h2>Pictures</h2>\n");
                sw.WriteLine("<ul>");
                foreach(var img in Directory.GetFiles(f.Path).Where(x=>x.EndsWith("jpg")).ToList())
                {
                    string imgName = img.Split("\\").Last();
                    sw.WriteLine("<li><a href=\"" + imgName.Replace(".jpg", "") + ".html\">" + imgName + "</a></li>\n");
                }
                sw.WriteLine("</ul>");
                sw.WriteLine("</p><br></p></html>");
                sw.Close();

            }
        }
        private static void CreateImagePage(Folder f, string imagePath)
        {
            using (StreamWriter sw=new StreamWriter(imagePath.Replace("jpg", "html")))
            {
                sw.WriteLine("<html> <head> <title>Projekt</title></head>\n");
                sw.WriteLine("<h1><a href = \"" + Environment.CurrentDirectory + "\\images\\index.html" + "\">Home Page</a></h1>\n");
                var files = Directory.GetFiles(f.Path).Where(x=>x.EndsWith("jpg")).ToList();
                int currentFileIndex = files.FindIndex(x => x == imagePath);
                if (!f.Path.EndsWith("images"))
                {
                    sw.WriteLine("<p><a href=\"../index.html\">"+f.ParentFolder.Split("\\").Last()+"</a></p>\n");
                }
                else
                {
                    sw.WriteLine("<p><a href=\"index.html\">" + "images" + "</a></p>\n");
                }
                if (currentFileIndex!=0)
                {
                    sw.WriteLine("<p><a href=\"" + files[currentFileIndex-1].Replace(".jpg", ".html") + "\"> <<&emsp;</a>\n");
                }
                if (currentFileIndex!=files.Count-1)
                {
                    sw.WriteLine("<a href=\"" + files[currentFileIndex + 1].Replace(".jpg", ".html") + "\"> <span style=\"padding-left: 200px;\">  >></a> </p>\n");
                    sw.WriteLine("<p> <a href = \"" + files[currentFileIndex + 1].Replace(".jpg", ".html") + "\"> <img align = \"middle\"  src=\"" + files[currentFileIndex + 1] + "\" width=\"300\" height=\"300\" > </a> </p>\n");
                }
                else
                {
                    sw.WriteLine("<p> <a href = \"" + files[currentFileIndex].Replace(".jpg", ".html") + "\"> <img align = \"middle\"  src=\"" + files[currentFileIndex] + "\" width=\"300\" height=\"300\" > </a> </p>\n");
                }
                sw.WriteLine("<p> <span style=\"padding-left: 100px;\">" + files[currentFileIndex].Split("\\").Last() + "</p></html>\n");
                sw.Close();
            }
        }
    }
}
