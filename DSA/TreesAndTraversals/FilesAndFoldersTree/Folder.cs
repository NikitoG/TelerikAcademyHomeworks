namespace FilesAndFoldersTree
{
    using System.Collections.Generic;

    public class Folder
    {
        private ICollection<File> files;
        private ICollection<Folder> childFolders;

        public Folder(string name)
        {
            this.Name = name;
            this.files = new List<File>();
            this.childFolders = new List<Folder>();
        }

        public string Name { get; set; }

        public ICollection<File> Files
        {
            get { return this.files; }
            set { this.files = value; }
        }

        public ICollection<Folder> ChildFolder
        {
            get { return this.childFolders; }
            set { this.childFolders = value; }
        }
    }
}
