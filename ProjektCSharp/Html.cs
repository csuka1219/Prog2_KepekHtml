using ProjektCSharp.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektCSharp
{
    public static class Html
    {
        public static void Create(List<Folder> folders)
        {
            foreach (Folder f in folders)
            {
                if(f.Path.EndsWith("images"))
                {
                    //főoldal
                }
                else
                {
                    //sub oldalak
                }
            }
        }
        private static void CreateFolderPage(Folder f)
        {

        }
        private static void CreateImagePage(Folder f)
        {

        }
    }
}
