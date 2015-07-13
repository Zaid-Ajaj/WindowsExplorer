using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Windows.Media.Imaging;


namespace WinExp
{
    class DataManeger
    {

        // checks if the corresponding file/folder is available (openable).
        public static bool IsAvailable(string file,bool isFolder)
        {
            if (!isFolder)
            {
                if ((File.GetAttributes(file) & FileAttributes.Hidden) != FileAttributes.Hidden)
                    return true;
                else
                    return false;
            }
            else
            {
                try
                {
                    object[] files = Directory.GetFiles(file);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        
        // Loads files and folders (items) from a folder.
        public static List<FileInformation> GetItems(string path)
        {
            List<FileInformation> items = new List<FileInformation>();
            string[] files = Directory.GetFiles(path);
            string[] folders = Directory.GetDirectories(path);

            // Add folder items into the collection
            foreach (string folder in folders)
            {
                if (IsAvailable(folder, true))
                {
                    DirectoryInfo info = new DirectoryInfo(folder);
                    items.Add(new FileInformation()
                    {
                        Name = info.Name,
                        FullPath = info.FullName,
                        Extension = "",
                        ImagePath = new BitmapImage(new Uri("Images/folder_vista.png", UriKind.Relative)),
                        IsFolder = true
                    });
                }
            }
            //Add file items into the colection
            foreach (string file in files)
            {
                if (IsAvailable(file,false))
                {
                    items.Add(new FileInformation()
                    {
                        Name = Path.GetFileNameWithoutExtension(file),
                        FullPath = file,
                        Extension = Path.GetExtension(file),
                        ImagePath = new BitmapImage(new Uri("Images/File.png", UriKind.Relative)),
                        IsFolder = false
                    });
                }
            }

           

            return items;
        }

        // Gets the drives :)
        public static List<FileInformation> GetDrives()
        {
            List<FileInformation> driveList = new List<FileInformation>();
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                if (drive.IsReady)
                {
                    driveList.Add(new FileInformation() 
                    {
                        Name = "(" + drive.RootDirectory.FullName + ") " + drive.VolumeLabel,
                        FullPath=drive.RootDirectory.FullName,
                        Extension = "",
                        ImagePath = new BitmapImage(new Uri("Images/drive.png",UriKind.Relative)),
                        IsFolder = true
                    });
                }
            }
            return driveList;
        }

        // Loads the Desktop
        public static List<FileInformation> Desktop()
        {
            List<FileInformation> items = new List<FileInformation>();
            FileInformation myComputer = new FileInformation()
            {
                Name = "My Computer",
                Extension = "",
                FullPath = "",
                IsComputer = true,
                IsFolder = false,
                ImagePath = new BitmapImage(new Uri("Images/laptop_black.png", UriKind.Relative))
            };
            items.Add(myComputer);
            string[] files = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory));
            string[] adFiles = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
            string[] folders = Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
            List<String> allFiles = new List<string>();
            allFiles.AddRange(files);
            allFiles.AddRange(adFiles);
            foreach (string folder in folders)
            {
                if(IsAvailable(folder,true))
                {
                    DirectoryInfo info = new DirectoryInfo(folder);
                    items.Add(new FileInformation()
                    {
                        Name = info.Name,
                        FullPath = info.FullName,
                        Extension = "",
                        ImagePath = new BitmapImage(new Uri("Images/folder_vista.png", UriKind.Relative)),
                        IsFolder = true
                    });
                }
            }
            foreach (string file in allFiles)
            {
                if (IsAvailable(file, false))
                {
                    items.Add(new FileInformation()
                    {
                        Name = Path.GetFileNameWithoutExtension(file),
                        FullPath = file,
                        Extension = Path.GetExtension(file),
                        ImagePath = new BitmapImage(new Uri("Images/File.png", UriKind.Relative)),
                        IsFolder = false
                    });
                }
            }

            
            return items;
        }
    }
}
