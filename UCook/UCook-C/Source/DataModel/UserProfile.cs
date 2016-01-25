using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace UCookC
{
	[DataContract]
	public class UserProfile : BaseDataModel
	{
		[DataMember]
		public string email { 
			get; 
			set;
		}

		[DataMember]
		public int gender {
			get;
			set;
		}

		[DataMember]
		public int age {
			get;
			set;
		}

		[DataMember]
		public List<int> unlock_product {
			get;
			set;
		}
	}
}

