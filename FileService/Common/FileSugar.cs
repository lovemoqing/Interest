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

        /// <summary>
        /// 检测指定目录是否存在
        /// </summary>
        /// <param name="directoryPath">目录的绝对路径</param>        
        public static bool IsExistDirectory(string directoryPath)
        {
            return Directory.Exists(directoryPath);
        }
        public static void CreateFolder(string path)
        {
            //如果目录不存在则创建该目录
            if (!IsExistDirectory(path))
            {
                Directory.CreateDirectory(path);
            }
        }
        public static void DelFolder(string path)
        {
            //如果目录存在则删除该目录
            if (IsExistDirectory(path))
            {
                //删除子级
                DelectDir(path);
                //删除自己
                Directory.Delete(path);
            }
        }

        public static void DelectDir(string srcPath)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(srcPath);
                FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();  //返回目录中所有文件和子目录
                foreach (FileSystemInfo i in fileinfo)
                {
                    if (i is DirectoryInfo)            //判断是否文件夹
                    {
                        DirectoryInfo subdir = new DirectoryInfo(i.FullName);
                        subdir.Delete(true);          //删除子目录和文件
                    }
                    else
                    {
                        File.Delete(i.FullName);      //删除指定文件
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
