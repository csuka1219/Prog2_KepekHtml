using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektCSharp.models
{
    public class Folder
    {
        public string Path { get; set; }
        public string ParentFolder { get; set; }
        public List<string> SubFolders { get; set; }
        public Folder(string Path,List<string> folders)
        {
            this.Path = Path;
            this.ParentFolder= Path.TrimEnd('\\').Remove(Path.LastIndexOf('\\'));
            this.SubFolders = folders.Where(f => f.Split("\\").Reverse().Skip(1).Take(1).LastOrDefault() == Path.Split("\\").LastOrDefault() && f != Path).ToList();
        }
    }
}
