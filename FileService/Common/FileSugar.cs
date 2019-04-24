using FileService.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileService.Common
{
    public class FileSugar
    {
        public static List<FileModel> List(string path)
        {
            List<FileModel> res = new List<FileModel>();
            DirectoryInfo TheFolder = new DirectoryInfo(path);
            foreach (DirectoryInfo NextFolder in TheFolder.GetDirectories())
            {
                FileModel model = new FileModel()
                {
                    Name = NextFolder.Name,
                    CreationTime = NextFolder.CreationTime,
                    LastWriteTime = NextFolder.LastWriteTime,
                    LastAccessTime = NextFolder.LastAccessTime,
                    Length= NextFolder.GetFiles().Length,
                    FileType="文件夹"
                };
                res.Add(model);
            }
            foreach (FileInfo NextFile in TheFolder.GetFiles())
            {
                FileModel model = new FileModel()
                {
                    Name = NextFile.Name,
                    CreationTime = NextFile.CreationTime,
                    LastWriteTime = NextFile.LastWriteTime,
                    LastAccessTime = NextFile.LastAccessTime,
                    Length = 0,
                    FileType = "文件"
                };
                res.Add(model);
            }
            return res;
        }
    }
}
