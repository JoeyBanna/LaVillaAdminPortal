﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Models
{
    public class FileConfig
    {
        public static FileConfig Current;



        public FileConfig()
        {
            Current = this;
        }



        public string FilePath { get; set; }
    }
}
