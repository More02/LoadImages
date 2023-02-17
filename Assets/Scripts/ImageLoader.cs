using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ImageLoader
{
    private UnityWebRequest _request;
    private static bool _isCanceled = false;

    public static bool IsCanceled 
    { 
        get { return _isCanceled; }
        set { _isCanceled = value; }
    }
    public async Task LoadingImage(string mediaUrl)
    {
        if (_isCanceled) return;
        _request = UnityWebRequestTexture.GetTexture(mediaUrl);
        _request.SendWebRequest();
        await YieldRequest();
    }

    public async Task SetImage(RawImage cardImage)
    {
        if (_isCanceled) return;

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
        if (_isCanceled) return;
        while (!_request.isDone && !_isCanceled)
        {
            await Task.Yield();
        }
    }
}
