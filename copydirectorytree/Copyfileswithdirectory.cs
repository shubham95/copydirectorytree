using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace copydirectorytree
{
    class Copyfileswithdirectory
    {
       
             public  void DirectoryCopywithbak(string sourceDirName, string destDirName, string bakDirName)
             {
                    // Get the subdirectories for the specified directory.
                    DirectoryInfo dir = new DirectoryInfo(sourceDirName);

                    if (!dir.Exists)
                    {
                        throw new DirectoryNotFoundException(
                            "Source directory does not exist or could not be found: "
                                + sourceDirName);
                     }

                    DirectoryInfo[] dirs = dir.GetDirectories();
                    // If the destination directory doesn't exist, create it.
                    if (!Directory.Exists(destDirName))
                    {
                        Directory.CreateDirectory(destDirName);
                    }

            if (!Directory.Exists(bakDirName))
            {
                Directory.CreateDirectory(bakDirName);
            }

            // Get the files in the directory and copy them to the new location.


            FileInfo[] files = dir.GetFiles();

            foreach(FileInfo file in files )
            {
                string temppath = Path.Combine(destDirName, file.Name);

                if(File.Exists(temppath))
                {  
                    //Take BackUp
                    File.Copy(temppath, Path.Combine(bakDirName, file.Name));
                    File.Delete(temppath);
                }
                File.Copy(Path.Combine(sourceDirName, file.Name), temppath);


            }
                    //FileInfo[] files = dir.GetFiles();
                     //foreach (FileInfo file in files)
                     //{
                     //    string temppath = Path.Combine(destDirName, file.Name);
                     //    file.CopyTo(temppath, false);
                     //}

                     // If copying subdirectories, copy them and their contents to new location.
                     
                        foreach (DirectoryInfo subdir in dirs)
                        {
                            string temppath = Path.Combine(destDirName, subdir.Name);
                
                            DirectoryCopywithbak(subdir.FullName, temppath, Path.Combine(bakDirName,subdir.Name));
                        }
                    
        }

    }
}

