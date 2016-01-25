using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace UCookC
{
	[DataContract]
	public class Material : BaseDataModel
	{
		[DataMember]
		public double amount {
			get;
			set;
		}

		[DataMember]
		public string unit {
			get;
			set;
		}
	}
}

