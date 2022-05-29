using System.Linq;
using System.Collections.Generic;

namespace ViewModels {
    public enum SpecificType { GoogleDrive, MicrosoftOneDrive, Mega, Dropbox, Box }

    public static class SearchSpecificType {

        public static IEnumerable<T> GetEnumValues<T>() {
            return SpecificType.GetValues(typeof(SpecificType)).Cast<T>();
        }

    }

}