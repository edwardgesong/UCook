using System;
using Security;
using Foundation;

namespace UCookC
{
	public class Utils
	{
		public static void StoreKeysInKeychain (string key, string value) {
			var s = new SecRecord (SecKind.GenericPassword) {
				ValueData = NSData.FromString (value),
				Generic = NSData.FromString (key)
			};
			var err = SecKeyChain.Add (s);
		}

		public static string GetRecordsFromKeychain (string key)
		{
			string result = string.Empty;
			SecStatusCode res;
			var rec = new SecRecord (SecKind.GenericPassword) {
				Generic = NSData.FromString (key)
			};
			var match = SecKeyChain.QueryAsRecord (rec, out res);
			if (match != null) {
				result = match.ValueData.ToString ();
			}

			return result;
		}
	}
}

