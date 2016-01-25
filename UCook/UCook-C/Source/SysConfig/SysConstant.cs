using System;

namespace UCookC
{
	public class SysConstant
	{
		public const string BaseUrl = "http://www.google.com";
		public const int HttpRequetTiemout = 100000;

		public static string API_PATH_USER_LOGIN
		{
			get{
				return "{0}/api/profile";
			}
		}

		public static string API_PATH_USER_REGISTER
		{
			get{
				return "{0}/api/profile";
			}
		}

		public enum USER_REQUEST_TYPE {
			LOGIN = 0,
			REGISTER
		}
	}
}

