using System;

namespace UCookC
{
	public class SysConstant
	{
		public const string BaseUrl = "http://www.google.com";

		public const int HttpRequetTiemout = 100000;

		public string API_PATH_GET_USERPROFILE
		{
			get{
				return "/api/profile";
			}
		}
	}
}

