using UnityEngine;

public static class OneByOne
{
    public static async void LoadImages(string mediaUrl)
    {
        foreach (var card in CardHolder.Instanse.AllCards)
        {
            await ImageLoader.Loading(mediaUrl, card.CardImage);
        }
    }
}
