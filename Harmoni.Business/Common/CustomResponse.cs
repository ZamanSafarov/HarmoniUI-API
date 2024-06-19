using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmoni.Business.Common
{
	public class CustomResponse
	{
		public int Code { get; set; }
		public string Message { get; set; }
		public CustomResponse(int code, string msg)
		{

			Code = code;
			Message = msg;
		}
	}
}
