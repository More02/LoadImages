using System.Threading.Tasks;
using UnityEngine;

public static class AllAtOnce
{
    public static async void LoadImages(string mediaUrl)
    {
        foreach (var card in CardHolder.Instanse.AllCards)
        {
            await card.ImageLoader.LoadingImage(mediaUrl);
        }
        foreach (var card in CardHolder.Instanse.AllCards)
        {
            await card.ImageLoader.SetImage(card.CardImage);
        }
    }
}
