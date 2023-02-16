using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public static class ImageLoader
{
    public static async Task LoadImage(string mediaUrl, RawImage cardImage)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(mediaUrl);
        //yield return

        request.SendWebRequest();
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
        }            
        else
        {
            cardImage.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
        }
       // await Task.Yield();
    } 
}
