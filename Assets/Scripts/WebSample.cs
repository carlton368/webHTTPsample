using UnityEngine;
using UnityEngine.UI;

public class WebSample : MonoBehaviour
{
    public Texture2D uploadTexture;

    public Image image;
    
    public void SendHelloWorld()
    {
        Debug.Log("SendHelloWorld");
        StartCoroutine(Api_HelloWorld.Send());
    }
    
    public void SendGetJson()
    {
        Debug.Log("SendGetJson");
        StartCoroutine(Api_GetJson.Send());
    }

    public void SendGetEchoText()
    {
        Debug.Log("SendGetEchoText");
        StartCoroutine(Api_GetEchoText.Send("안녕"));
    }

    public void SendPostEchoJson()
    {
        Debug.Log("SendPostEchoJson");
        StartCoroutine(Api_PostEchoJson.Send());
    }

    public void SendPostForm()
    {
        Debug.Log("SendPostForm");
        StartCoroutine(Api_PostForm.Send("호두", 8));
    }

    public void SendUploadFile()
    {
        Debug.Log("SendUploadFile");
        StartCoroutine(Api_UploadFile.Send(uploadTexture));
    }
    public void SendGetFile()
    {
        Debug.Log("SendGetFile");
        StartCoroutine(Api_GetFile.Send(
            Api_UploadFile.LatestUploadTextureFilename,
            sprite => image.sprite = sprite));
    }
}
