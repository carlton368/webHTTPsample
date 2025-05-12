using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class Api_GetFile
{
    public static IEnumerator Send(string filename, Action<Sprite> OnCompleted)
    {
        var webRequest = UnityWebRequestTexture.GetTexture($"{Constants.Url}/get-file/{filename}");
        Debug.Log(webRequest.uri.ToString());
        
        webRequest.SetRequestHeader("Content-Type", "text/plain");
        
        yield return webRequest.SendWebRequest();

        Sprite sprite = GetSprite(webRequest);
        OnCompleted.Invoke(sprite);
    }
    
    public static IEnumerator SendWav(string filename, Action<AudioClip> OnCompleted)
    {
        var webRequest = UnityWebRequestMultimedia.GetAudioClip($"{Constants.Url}/get-file/{filename}", AudioType.WAV);
        Debug.Log(webRequest.uri.ToString());
        
        webRequest.SetRequestHeader("Content-Type", "text/plain");
        
        yield return webRequest.SendWebRequest();

        AudioClip clip = GetAudioClip(webRequest);
        OnCompleted.Invoke(clip);
    }
    
    private static Sprite GetSprite(UnityWebRequest webRequest)
    {
        // 응답 데이터를 Texture2D로 복원
        var texture = DownloadHandlerTexture.GetContent(webRequest);
        var sprite = Sprite.Create(texture,
            new Rect(0, 0, texture.width, texture.height),
            new Vector2(0.5f, 0.5f));
        sprite.name = Path.GetFileName(webRequest.url);
        return sprite;
    }
    
    private static AudioClip GetAudioClip(UnityWebRequest webRequest)
    {
        var audioClip = DownloadHandlerAudioClip.GetContent(webRequest);
        audioClip.name = Path.GetFileName(webRequest.url);
        return audioClip;
    }
}
