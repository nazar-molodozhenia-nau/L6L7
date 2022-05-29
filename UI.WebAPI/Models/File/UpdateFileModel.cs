using System;

namespace UI.WebAPI {
    public class UpdateFileModel {
        public Guid Id { get; set; }
        public Guid IdFolderParent { get; set; }
        public Guid IdStorageParent { get; set; }

        public string Name { get; set; }
        public string Type { get; set; }
    }
}