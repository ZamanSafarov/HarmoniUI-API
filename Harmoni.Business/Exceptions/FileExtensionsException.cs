using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmoni.Business.Exceptions
{
    public class FileExtensionsException : Exception
    {
        public FileExtensionsException(string? message) : base(message)
        {
        }
    }
}
