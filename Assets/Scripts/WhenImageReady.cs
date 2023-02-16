using UnityEngine;

public static class WhenImageReady
{
    public static void LoadImages(string mediaUrl)
    {
        foreach (var card in CardHolder.Instanse.AllCards)
        {
            ImageLoader.LoadWhenReady(mediaUrl, card.CardImage);
        }
    }
}
