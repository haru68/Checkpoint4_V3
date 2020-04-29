using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Checkpoint4_V2
{
    public class FileWriter
    {
        public static void Write(String FileName, String text)
        {
            string path = @".\..\..\..\..\Root";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = $@"{path}\{FileName}.txt";
            
            File.WriteAllText(filepath, text);
        }
    }
}
