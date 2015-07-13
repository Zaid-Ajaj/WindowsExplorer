using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.ComponentModel;

namespace WinExp
{
    class FileInformation
    {
        public string Name { get; set; }
        public string FullPath { get; set; }
        public string Extension { get; set; }
        public bool IsFolder { get; set; }
        public ImageSource ImagePath { get; set; }
        public bool IsComputer { get; set; }
    }
}
