using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class BaseLoadImages : MonoBehaviour
{
    [SerializeField] 
    private RawImage _cardImage;
    private string _mediaUrl = "https://picsum.photos/200";

    private void Start()
    {
        StartCoroutine(BaseLoadImage(_mediaUrl));
    }
    private IEnumerator BaseLoadImage(string _mediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(_mediaUrl);
        yield return request.SendWebRequest();
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
        }            
        else
        {
            _cardImage.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
        }
    } 
}
