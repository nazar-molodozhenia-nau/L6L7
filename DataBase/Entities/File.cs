﻿using System;

namespace DataBase {
    public class File {

        public Guid Id { get; set; }
        public Guid IdFolderParent { get; set; }
        public Guid IdStorageParent { get; set; }
        public bool OrDirectStorageParent { get; set; }

        public string Type { get; set;}

        public string Name { get; set; }
        public string Path { get; set; }

    }
}