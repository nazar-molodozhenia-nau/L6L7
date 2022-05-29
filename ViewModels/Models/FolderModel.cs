using System;

namespace ViewModels {
    public class FolderModel {

        public Guid Id { get; set; }
        public Guid IdFolderParent { get; set; }
        public Guid IdStorageParent { get; set; }
        public bool OrDirectStorageParent { get; set; }

        public string Name { get; set; }
        public string Type { get; set; } = "folder";
        public string Path { get; set; }

    }
}