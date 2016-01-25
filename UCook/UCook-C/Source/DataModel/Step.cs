using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace UCookC
{
	public class Step
	{
		public Step ()
		{
		}

		public bool time_count {
			get;
			set;
		}

		public double duration {
			get;
			set;
		}

		public string desc {
			get;
			set;
		}

		public List<int> material {
			get;
			set;
		}
	}
}

