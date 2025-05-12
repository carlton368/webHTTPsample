using System.Collections;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class Api_PostForm
{
    public class Result
    {
        public class Data
        {
            public int age;
            public string name;
        }
    
        public Data data;
        public string error;
        public string message;
        public bool status;
    }

    public static IEnumerator Send(string name, int age)
    {
        WWWForm formData = new WWWForm();
        formData.AddField("name", name);
        formData.AddField("age", age.ToString());
        
        // var formData2 = new List<IMultipartFormSection>
        // {
        //     new MultipartFormDataSection("name", name),
        //     new MultipartFormDataSection("age", age)
        // };
        
        var webRequest = UnityWebRequest.Post($"{Constants.Url}/post-form", formData);
        // var webRequest = UnityWebRequest.Post($"{Constants.Url}/post-form", formData2);
        yield return webRequest.SendWebRequest();
        
        Debug.Log(webRequest.downloadHandler.text);

        string jsonText = webRequest.downloadHandler.text;
        Result result = JsonConvert.DeserializeObject<Result>(jsonText);
        Debug.Log($"{result.data.age}, {result.data.name}");
    }
}