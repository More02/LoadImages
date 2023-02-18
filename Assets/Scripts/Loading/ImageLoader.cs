using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

/// <summary>
/// Инструменты для загрузки и отображения изображений
/// </summary>
public class ImageLoader
{
    private UnityWebRequest _request;
    private static bool _isCanceled = false;
    private bool _isSetted = false;

    public static bool IsCanceled 
    { 
        get { return _isCanceled; }
        set { _isCanceled = value; }
    }
    public async Task LoadingImage(string mediaUrl)
    {
        if (_isCanceled) 
        {
            if (!_request.isDone) { _request.Abort(); }            
            return;
        }
        
        _isSetted = false;
        _request = UnityWebRequestTexture.GetTexture(mediaUrl);
        _request.SendWebRequest();
        await YieldRequest();
    }

    public async Task SetImage(RawImage cardImage)
    {        
        await YieldRequest();
        if (_isCanceled)
        {
            if (!_request.isDone) { _request.Abort(); }
            return;
        }
        if (_request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(_request.error);
        }
        else if (!_isCanceled)
        {
            cardImage.texture = ((DownloadHandlerTexture)_request.downloadHandler).texture;
            _isSetted = true;
        }
    }

    public async Task RotateAfterSetting(Card card)
    {
        await YieldRequest();
        if (_isCanceled)
        {
            if (!_request.isDone) { _request.Abort(); }
            return;
        }
        while (!_isSetted && !_isCanceled)
        {
            await Task.Yield();
        }
        if (_isCanceled) return;
        if (_isSetted) await card.RotateCards.ToFront();
    }

    private async Task YieldRequest()
    {
        if (_isCanceled)
        {
            if (!_request.isDone) { _request.Abort(); }
            return;
        }
        while (!_request.isDone && !_isCanceled)
        {
            await Task.Yield();
        }
    }
}
