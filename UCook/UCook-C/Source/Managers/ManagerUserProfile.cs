using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;

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

		public void StartLogin (string _username, string _password, Action callback) {
			Task.Run (async () => {
				var response = await StartRequestFromServer (_username, _password);
				if (response != null) {
					userProfile = response;
				} else {

				}
				if (callback != null)
					callback ();
			});
		}

		public async Task<UserProfile> StartRequestFromServer (string _username, string _password) {
			UserProfile userProfile = null;
			AccountRequest obj = new AccountRequest {
				username = _username,
				password = _password
			};

			var objStr = JsonConvert.SerializeObject (obj);
			var content = new StringContent (objStr, Encoding.UTF8, "application/json");
			try {
				var response = await UCookHttpClient.Instance.PostAndGetStringResponseAsync (SysConstant.BaseUrl, content);
				userProfile = JsonConvert.DeserializeObject <UserProfile> (response);
			} catch (Exception e) {
				
			}
			return userProfile;
		}

		public async Task StartSignUpUserProfile () {
			
		}
			
		public async Task StartLogout () {
			
		}
	}
}

