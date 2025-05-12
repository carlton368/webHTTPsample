using System.Collections;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class Api_UploadFile
{
    public class Result
    {
        public class Data
        {
            public string filename;
            public int filesize;
        }
    
        public Data data;
        public string error;
        public string message;
        public bool status;
    }

    public static string LatestUploadTextureFilename;

    public static IEnumerator Send(Texture2D texture)
    {
        WWWForm formData = new WWWForm();
        formData.AddBinaryData(
            "file",
            texture.EncodeToPNG(),
            $"{texture.name}.png",
            "image/png");
        
        var webRequest = UnityWebRequest.Post($"{Constants.Url}/upload-file", formData);
        yield return webRequest.SendWebRequest();
        
        Debug.Log(webRequest.downloadHandler.text);

        string jsonText = webRequest.downloadHandler.text;
        Result result = JsonConvert.DeserializeObject<Result>(jsonText);
        Debug.Log($"{result.data.filename}, {result.data.filesize}");

        LatestUploadTextureFilename = result.data.filename;
    }
}