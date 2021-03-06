﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileService.Model
{
    public class FileModel
    {
        public string Name { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastWriteTime { get; set; }
        public DateTime LastAccessTime { get; set; }
        public int Length { get; set; }
        public string FileType { get; set; }
    }
}
