using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;

namespace UCookC
{
	[DataContract]
	public class AccountRequest
	{
		[DataMember]
		public string username {
			get;
			set;
		}

		[DataMember]
		public string password {
			get;
			set;
		}
	}
}

