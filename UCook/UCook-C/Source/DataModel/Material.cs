using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace UCookC
{
	public class Material : BaseDataModel
	{
		public Material ()
		{
		}

		public double amount {
			get;
			set;
		}

		public string unit {
			get;
			set;
		}
	}
}

