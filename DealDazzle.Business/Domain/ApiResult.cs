using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DealDazzle.Business.Domain
{
	public class ApiResult<T> where T : class
	{
		public T Result { get; set; }
		public HttpStatusCode StatusCode { get; set; }
		public bool IsSuccessful { get; set; }
		public string Message { get; set; }
	}
}
