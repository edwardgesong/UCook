using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace UCookC
{
	public class Products : BaseDataModel
	{
		public Products ()
		{
		}

		public int suisine_id {
			get;
			set;
		}

		public int classification_id {
			get;
			set;
		}

		public string desc {
			get;
			set;
		}

		public int difficulty_level {
			get;
			set;
		}

		public List<int> material {
			get;
			set;
		}

		public List<Step> step {
			get;
			set;
		}
	}
}

