using System;

namespace ViewModels {
    public class StorageModel : ObservableObject {

        public Guid Id { get; set; }

        public string Owner { get; set; }
        public SpecificType SpecificType { get; set; }

    }
}
