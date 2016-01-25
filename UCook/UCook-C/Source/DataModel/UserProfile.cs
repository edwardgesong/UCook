using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace UCookC
{
	public class UserProfile : BaseDataModel
	{
		public UserProfile ()
		{
		}

		public string email { 
			get; 
			set;
		}

		public int gender {
			get;
			set;
		}

		public int age {
			get;
			set;
		}

		public List<int> unlock_product {
			get;
			set;
		}
	}
}

