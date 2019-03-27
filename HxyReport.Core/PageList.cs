﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HxyReport.Core
{
    public class PageList<T> where T : class
    {
        public int TotalCount { get; set; }
        public List<T> Results { get; set; }
    }
}
