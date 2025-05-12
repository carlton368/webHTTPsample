using System.Collections;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class Api_PostEchoJson
{
    public class Request
    {
        public string name;
        public int age;
    }
    
    public class Result
    {
        public class Data
        {
            public class Info
            {
                public string name;
                public int age;
            }

            public Info received_json;
        }
    
        public Data data;
        public string error;
        public string message;
        public bool status;
    }
    
    public static IEnumerator Send()
    {
        Request req = new Request()
        {
            name = "호두",
            age = 7,
        };
        string body = JsonConvert.SerializeObject(req);
        
        var webRequest = UnityWebRequest.Post($"{Constants.Url}/post-echo-json", body, UnityWebRequest.kHttpVerbPOST);
        Debug.Log(webRequest.uri.ToString());
        
        webRequest.SetRequestHeader("Content-Type", "application/json");
        
        yield return webRequest.SendWebRequest();
        
        Debug.Log(webRequest.downloadHandler.text);

        string jsonText = webRequest.downloadHandler.text;
        Result result = JsonConvert.DeserializeObject<Result>(jsonText);
        Debug.Log($"{result.data.received_json.age}, {result.data.received_json.name}");
    }
}