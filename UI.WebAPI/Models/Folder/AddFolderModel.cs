using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.WebAPI {
    public class AddFolderModel {
        public Guid Id { get; set; }
        public Guid IdFolderParent { get; set; }
        public Guid IdStorageParent { get; set; }

        public string Name { get; set; }
        public string Type { get; set; } = "folder";

    }
}