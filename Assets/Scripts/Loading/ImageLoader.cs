using System.Threading.Tasks;
using Cards;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Loading
{
    /// <summary>
    /// Инструменты для загрузки и отображения изображений
    /// </summary>
    public class ImageLoader
    {
        private UnityWebRequest _request;
        private bool _isSetted = false;

        public static bool IsCanceled { get; set; } = false;

        public async Task LoadingImage(string mediaUrl)
        {
            if (IsCanceled)
            {
                if (!_request.isDone)
                {
                    _request.Abort();
                }

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
            if (IsCanceled)
            {
                if (!_request.isDone)
                {
                    _request.Abort();
                }

                return;
            }

            if (_request.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(_request.error);
            }
            else if (!IsCanceled)
            {
                cardImage.texture = ((DownloadHandlerTexture)_request.downloadHandler).texture;
                _isSetted = true;
            }
        }

        public async Task RotateAfterSetting(Card card)
        {
            await YieldRequest();
            if (IsCanceled)
            {
                if (!_request.isDone)
                {
                    _request.Abort();
                }

                return;
            }

            while (!_isSetted && !IsCanceled)
            {
                await Task.Yield();
            }

            if (IsCanceled) return;
            if (_isSetted) await card.RotateCards.ToFront();
        }

        private async Task YieldRequest()
        {
            if (IsCanceled)
            {
                if (!_request.isDone)
                {
                    _request.Abort();
                }

                return;
            }

            while (!_request.isDone && !IsCanceled)
            {
                await Task.Yield();
            }
        }
    }
}