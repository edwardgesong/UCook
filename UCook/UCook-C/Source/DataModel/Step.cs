using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace UCookC
{
	[DataContract]
	public class Step
	{
		[DataMember]
		public bool time_count {
			get;
			set;
		}

		[DataMember]
		public double duration {
			get;
			set;
		}

		[DataMember]
		public string desc {
			get;
			set;
		}

		[DataMember]
		public List<int> material {
			get;
			set;
		}
	}
}

