using System;
using System.Net.Http;
using System.Text;
using System.Diagnostics;
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

		public void StartLogin (string _username, string _password, Action callback) {
			Task.Run (async () => {
				Debug.Print (string.Format ("[Start User Login] Username {0}, Password {1}", _username, _password));
				var response = await StartRequestFromServer (_username, _password, SysConstant.USER_REQUEST_TYPE.LOGIN);
				if (response != null) {
					userProfile = response;
				} else {

				}
				if (callback != null)
					callback ();
				Debug.Print ("[Finish User Login]");
			});
		}

		public void StartSignUp (string _username, string _password, Action callback) {
			Task.Run (async () => {
				Debug.Print (string.Format ("[Start User Sign Up] Username {0}, Password {1}", _username, _password));
				var response = await StartRequestFromServer (_username, _password, SysConstant.USER_REQUEST_TYPE.REGISTER);
				if (response != null) {
					userProfile = response;
				} else {

				}
				if (callback != null)
					callback ();
				Debug.Print ("[Finish User Sign Up]");
			});
		}

		public async Task<UserProfile> StartRequestFromServer (string _username, string _password, SysConstant.USER_REQUEST_TYPE _actionType) {
			UserProfile userProfile = null;
			AccountRequest obj = new AccountRequest {
				username = _username,
				password = _password
			};
			var url = string.Empty;
			if (_actionType.Equals (SysConstant.USER_REQUEST_TYPE.LOGIN)) {
				url = string.Format (SysConstant.API_PATH_USER_LOGIN, SysConstant.BaseUrl);
			} else if (_actionType.Equals (SysConstant.USER_REQUEST_TYPE.REGISTER)) {
				url = string.Format (SysConstant.API_PATH_USER_REGISTER, SysConstant.BaseUrl);
			}
			var objStr = JsonConvert.SerializeObject (obj);
			var content = new StringContent (objStr, Encoding.UTF8, "application/json");
			try {
				var response = await UCookHttpClient.Instance.PostAndGetStringResponseAsync (url, content);
				userProfile = JsonConvert.DeserializeObject <UserProfile> (response);
			} catch (Exception e) {
				
			}
			return userProfile;
		}
			
		public async Task StartLogout () {
			
		}
	}
}

