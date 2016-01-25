using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UCookC
{
	public class ManagerUserProfile : Singleton<ManagerUserProfile>
	{
		private UserProfile userProfile = null;

		public void InitUserProfile () {
			if (userProfile == null)
				userProfile = new UserProfile ();
		}

		public UserProfile GetUserProfile () {
			return userProfile;

		}

		public async Task StartLoadUserProfile (string _username, string _password) {
			
		}

		public async Task StartRequestFromServer () {
			
		}

		public async Task StartSignUpUserProfile () {
			
		}
	}
}

