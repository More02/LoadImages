using UnityEngine;

public static class WhenImageReady
{
    public static void LoadImages(string mediaUrl, MonoBehaviour monoBehaviour)
    {
        foreach (var card in CardHolder.Instanse.AllCards)
        {
            monoBehaviour.StartCoroutine(ImageLoader.LoadImage(mediaUrl, card.CardImage));
        }
    }
}
