using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Models
{
    public class FileTypes : ObservableCollection<string>
    {
        public FileTypes()
        {
            Add("json");
            Add("xml");
            Add("csv");
            Add("txt");
        }
    }
}
