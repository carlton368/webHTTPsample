using System.Collections;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class Api_HelloWorld
{
/*
{
  "data": null,
  "error": null,
  "message": "Hello World!",
  "status": true
}
*/
    public class Result
    {
        public string data;
        public string error;
        public string message;
        public bool status;
    }

    public static IEnumerator Send()
    {
        var webRequest = UnityWebRequest.Get($"{Constants.Url}/hello-world");
        Debug.Log(webRequest.uri.ToString());
        
        webRequest.SetRequestHeader("Content-Type", "text/plain");
        
        yield return webRequest.SendWebRequest();
        
        Debug.Log(webRequest.downloadHandler.text);

        string jsonText = webRequest.downloadHandler.text;
        Result helloWorld = JsonConvert.DeserializeObject<Result>(jsonText);
        Debug.Log(helloWorld.message);
    }
}