using System.Collections;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class Api_GetJson
{
/*
{
    "data": {
        "id": 123,
        "name": "Test Object",
        "tags": [
            "unity",
            "flask",
            "api"
        ]
    },
    "error": null,
    "message": "샘플 JSON",
    "status": true
}
*/
    public class Result
    {
        public class Data
        {
            public int id;
            public string name;
            public string[] tags;
        }
    
        public Data data;
        public string error;
        public string message;
        public bool status;
    }
    
    public static IEnumerator Send()
    {
        var webRequest = UnityWebRequest.Get($"{Constants.Url}/get-json");
        Debug.Log(webRequest.uri.ToString());
        
        webRequest.SetRequestHeader("Content-Type", "text/plain");
        
        yield return webRequest.SendWebRequest();
        
        Debug.Log(webRequest.downloadHandler.text);

        string jsonText = webRequest.downloadHandler.text;
        Result getJson = JsonConvert.DeserializeObject<Result>(jsonText);
        Debug.Log($"{getJson.data.id} / {getJson.data.name} / {getJson.data.tags}");
    }
}