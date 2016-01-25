using System;
using System.Threading.Tasks;

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

		public async Task StartLoadUserProfile () {
			
		}

		public async Task StartRequestFromServer () {
			
		}

		public async Task StartSignUpUserProfile () {
			
		}
	}
}

