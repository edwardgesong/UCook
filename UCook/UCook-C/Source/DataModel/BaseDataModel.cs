﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace UCookC
{
	[DataContract]
	public class BaseDataModel
	{
		[DataMember]
		public int id {
			get;
			set;
		}

		[DataMember]
		public string name {
			get;
			set;
		}

		[DataMember]
		public string img_url {
			get;
			set;
		}
	}
}

