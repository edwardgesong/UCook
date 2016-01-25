using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace UCookC
{
	[DataContract]
	public class Products : BaseDataModel
	{
		[DataMember]
		public int suisine_id {
			get;
			set;
		}

		[DataMember]
		public int classification_id {
			get;
			set;
		}

		[DataMember]
		public string desc {
			get;
			set;
		}

		[DataMember]
		public int difficulty_level {
			get;
			set;
		}

		[DataMember]
		public List<int> material {
			get;
			set;
		}

		[DataMember]
		public List<Step> step {
			get;
			set;
		}
	}
}

