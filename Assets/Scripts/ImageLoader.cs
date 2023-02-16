using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public static class ImageLoader
{
    public static async void LoadWhenReady(string mediaUrl, RawImage cardImage)
    {
        Loading(mediaUrl, cardImage);
    }

    public static async Task LoadOneByOne(string mediaUrl, RawImage cardImage)
    {
        await Loading(mediaUrl, cardImage);
    }
    private static async Task Loading(string mediaUrl, RawImage cardImage)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(mediaUrl);
        request.SendWebRequest();

        while (!request.isDone)
        {
            await Task.Yield();
        }
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
        }
        else
        {
            cardImage.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
        }
    }
}
