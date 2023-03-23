using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets
{
    public class DonationRo : MonoBehaviour
    {
        // {username}
        private readonly string token = "n7R0wGwLPFJIhkIXy5IA";

        // tLyxk6BG8LkWuYLqCQF1GpvUxv9t4nYx3SLgxqEI
        //-X GET https://www.donationalerts.com/api/v1/alerts/donations \
        //-H "Authorization: Bearer <token>"

        public string _request = "https://www.donationalerts.com/api/v1/alerts/donations";
        public string APP_ID = "10760";
        public string REDIRECT_URI = "https://www.donationalerts.com/widget/instream-stats?id=1591406&token=n7R0wGwLPFJIhkIXy5IA";
        public string SCOPE = "oauth-donation-index";
        public string uri = "https://www.donationalerts.com/oauth/authorize?client_id=10760&redirect_uri=https://www.donationalerts.com/widget/instream-stats?id=1591406&token=n7R0wGwLPFJIhkIXy5IA&response_type=token&scope=oauth-donation-index";


        private void Start()
        {
            StartCoroutine(GetRequest());
        }

        public IEnumerator GetRequest()
        {


            //var uri = new Uri("https://www.donationalerts.com/oauth/authorize?" + "client_id=" + APP_ID + "&redirect_uri=" + REDIRECT_URI + "&response_type=token" + "&scope=" + SCOPE);
            using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
            {
                webRequest.method = "GET";
                webRequest.SetRequestHeader("Authorization", "Bearer  " + "tLyxk6BG8LkWuYLqCQF1GpvUxv9t4nYx3SLgxqEI");
                yield return webRequest.SendWebRequest();

                Debug.Log(webRequest.error);

                var jsonText = webRequest.downloadHandler.text;
                Debug.Log(jsonText);

                RootData data = JsonUtility.FromJson<RootData>(jsonText);

                Debug.Log(data.Datas[0].UserName);
            }                
        }
    }

    public class Data
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string MessageType { get; set; }
        public string Message { get; set; }
        public int Amount { get; set; }
        public string Currency { get; set; }
        public int IsShown { get; set; }
        public string CreatedAt { get; set; }
        public object ShownAt { get; set; }
    }

    public class Links
    {
        public string First { get; set; }
        public string Last { get; set; }
        public object Prev { get; set; }
        public object Next { get; set; }
    }

    public class Meta
    {
        public int CurrentPage { get; set; }
        public int From { get; set; }
        public int LastPage { get; set; }
        public string Path { get; set; }
        public int PerPage { get; set; }
        public int To { get; set; }
        public int Total { get; set; }
    }

    public class RootData
    {
        public List<Data> Datas { get; set; }
        public Links Links { get; set; }
        public Meta Meta { get; set; }
    }

}