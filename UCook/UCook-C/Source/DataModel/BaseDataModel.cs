using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace UCookC
{
	public class BaseDataModel
	{
		public BaseDataModel ()
		{
		}

		public int id {
			get;
			set;
		}

		public string name {
			get;
			set;
		}

		public string img_url {
			get;
			set;
		}
	}
}

