﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmoni.Business.Exceptions
{
    public class FileDoesNotExsistException : Exception
    {
        public FileDoesNotExsistException(string? message) : base(message)
        {
        }
    }
}
