using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace UCookC
{
	public class UCookHttpClient : HttpClient
	{
		private static readonly Lazy<UCookHttpClient> Lazy = new Lazy<UCookHttpClient>(() => new UCookHttpClient());

		public static UCookHttpClient Instance {
			get { return Lazy.Value; }
		}

		public UCookHttpClient () : base(new HttpClientHandler()) 
		{
			this.DefaultRequestHeaders.Clear ();
			this.DefaultRequestHeaders.Accept.Add (System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse ("application/json"));
			this.DefaultRequestHeaders.Accept.Add (System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse ("*/*"));
		}

		public async Task<string> PostAndGetStringResponseAsync (string requestUri, HttpContent content) {
			#if DEBUG
			Stopwatch timer = new Stopwatch();
			timer.Start();
			#endif
			using(HttpClient client = new HttpClient(new HttpClientHandler())) {
				client.DefaultRequestHeaders.Clear ();
				client.DefaultRequestHeaders.Accept.Add (System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse ("application/json"));
				client.DefaultRequestHeaders.Accept.Add (System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse ("*/*"));
				client.Timeout = new TimeSpan (0, 0, 0, 0, SysConstant.HttpRequetTiemout);
				HttpResponseMessage resp = await client.PostAsync(requestUri, content);

				#if DEBUG
				timer.Stop();
				Debug.Print(string.Format("Request Url: {0}, Time Duration: {1}ms", requestUri, timer.ElapsedMilliseconds));
				Debug.Print(string.Format("Response Data: {0}", resp.Content.ReadAsStringAsync()));
				#endif
				return await resp.Content.ReadAsStringAsync();
			}
		}

		public async Task<byte[]> GetByteArrayAsync (string requestUri) {
			#if DEBUG
			Stopwatch timer = new Stopwatch();
			timer.Start();
			#endif
			using(HttpClient client = new HttpClient(new HttpClientHandler())) {
				client.DefaultRequestHeaders.Clear ();
				client.DefaultRequestHeaders.Accept.Add (System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse ("application/json"));
				client.DefaultRequestHeaders.Accept.Add (System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse ("*/*"));
				byte[] resp = await client.GetByteArrayAsync(requestUri);
				#if DEBUG
				timer.Stop();
				Debug.Print(string.Format("Request Url: {0}, Time Duration: {1}ms", requestUri, timer.ElapsedMilliseconds));
				var responseString = Encoding.UTF8.GetString(resp, 0, resp.Length - 1);
				Debug.Print(string.Format("Response Data: {0}", responseString));
				#endif
				return resp;
			}
		}

		public async Task<string> GetStringAsync (string requestUri) {
			#if DEBUG
			Stopwatch timer = new Stopwatch();
			timer.Start();
			#endif
			using(HttpClient client = new HttpClient(new HttpClientHandler())) {
				client.DefaultRequestHeaders.Clear ();
				client.DefaultRequestHeaders.Accept.Add (System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse ("application/json"));
				client.DefaultRequestHeaders.Accept.Add (System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse ("*/*"));
				var resp = await client.GetStringAsync(requestUri);
				#if DEBUG
				timer.Stop();
				Debug.Print(string.Format("Request Url: {0}, Time Duration: {1}ms", requestUri, timer.ElapsedMilliseconds));
				Debug.Print(string.Format("Response Data: {0}", resp));
				#endif
				return resp;
			}
		}

		public async Task<string> GetSpecialAsync (string requestUri) {
			#if DEBUG
			Stopwatch timer = new Stopwatch();
			timer.Start();
			#endif
			using(HttpClient client = new HttpClient(new HttpClientHandler())) {
				client.DefaultRequestHeaders.Clear ();
				var resp = await client.GetStringAsync(requestUri);
				#if DEBUG
				timer.Stop();
				Debug.Print(string.Format("Request Url: {0}, Time Duration: {1}ms", requestUri, timer.ElapsedMilliseconds));
				Debug.Print(string.Format("Response Data: {0}", resp));
				#endif
				return resp;
			}
		}
	}
}

