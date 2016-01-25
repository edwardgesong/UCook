using System;

namespace UCookC
{
	public abstract class Singleton<T> where T : class
	{
		static T _instance = null;
		public static T Instance 
		{
			get {
				if (_instance == null) {
					_instance = CreateInstanceOfT ();
				}
				return _instance;
			}
		}

		private static T CreateInstanceOfT()
		{
			return Activator.CreateInstance(typeof(T)) as T;
		}
	}
}

