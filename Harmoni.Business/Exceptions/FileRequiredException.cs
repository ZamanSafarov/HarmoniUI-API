﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmoni.Business.Exceptions
{
    public class FileRequiredException : Exception
    {
        public FileRequiredException(string? message) : base(message)
        {
        }
    }
}
