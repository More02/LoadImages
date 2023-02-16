using UnityEngine;

public static class WhenImageReady
{
    public static async void LoadImages(string mediaUrl)
    {
        foreach (var card in CardHolder.Instanse.AllCards)
        {
           await ImageLoader.LoadImage(mediaUrl, card.CardImage);
        }
    }
}
