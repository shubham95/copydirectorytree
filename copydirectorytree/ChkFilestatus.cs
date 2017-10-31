using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace copydirectorytree
{
    class ChkFilestatus
    {

        public static Boolean IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                //Don't change FileAccess to ReadWrite, 
                //because if a file is in readOnly, it fails.
                stream = file.Open
                (
                    FileMode.Open,
                    FileAccess.Read,
                    FileShare.None
                );
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }


        public bool chk(string foldername)
        {
            bool result = true;
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(foldername);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + foldername);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.


            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                //Chk if file is locked or not
                if (IsFileLocked(file))
                {
                    result= false;
                }
                //file.CopyTo(temppath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.

            if (result)
            {
                foreach (DirectoryInfo subdir in dirs)
                {

                    result=result& chk(subdir.FullName);
                }
            }

            return result;
        
        }
    }
}
