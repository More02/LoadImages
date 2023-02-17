using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ImageLoader
{
    private UnityWebRequest _request;
    public async Task LoadingImage(string mediaUrl)
    {
        _request = UnityWebRequestTexture.GetTexture(mediaUrl);
        _request.SendWebRequest();
        await YieldRequest();
    }

    public async Task SetImage(RawImage cardImage)
    {
        await YieldRequest();
        if (_request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(_request.error);
        }
        else
        {
            cardImage.texture = ((DownloadHandlerTexture)_request.downloadHandler).texture;
        }
    }

    private async Task YieldRequest()
    {
        while (!_request.isDone)
        {
            await Task.Yield();
        }
    }
}
