using System.Collections;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class Api_GetEchoText
{
    public class Result
    {
        public class Data
        {
            public string received_message;
        }
    
        public Data data;
        public string error;
        public string message;
        public bool status;
    }

    public static IEnumerator Send(string message)
    {
        var webRequest = UnityWebRequest.Get($"{Constants.Url}/get-echo-text?message={message}");
        Debug.Log(webRequest.uri.ToString());
        
        webRequest.SetRequestHeader("Content-Type", "text/plain");
        
        yield return webRequest.SendWebRequest();
        
        Debug.Log(webRequest.downloadHandler.text);

        string jsonText = webRequest.downloadHandler.text;
        Result getJson = JsonConvert.DeserializeObject<Result>(jsonText);
        Debug.Log($"{getJson.data.received_message}");
    }
}