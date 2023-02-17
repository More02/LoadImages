using System.Diagnostics;
using System.Threading.Tasks;

public static class WaysOfLoading 
{
    public static async Task AllAtOnceLoadImages(string mediaUrl)
    {
        foreach (var card in CardHolder.Instanse.AllCards)
        {
            await card.ImageLoader.LoadingImage(mediaUrl);
        }
        foreach (var card in CardHolder.Instanse.AllCards)
        {
            await card.ImageLoader.SetImage(card.CardImage);
            card.RotateCards.ToFront();
        }
    }

    public static async Task OneByOneLoadImages(string mediaUrl)
    {
        foreach (var card in CardHolder.Instanse.AllCards)
        {
            await card.ImageLoader.LoadingImage(mediaUrl);
            await card.ImageLoader.SetImage(card.CardImage);
        }
        foreach (var card in CardHolder.Instanse.AllCards)
        {
            await card.RotateCards.ToFront();
        }
    }

    public static async Task WhenImageReadyLoadImages(string mediaUrl)
    {
        foreach (var card in CardHolder.Instanse.AllCards)
        {            
            card.ImageLoader.LoadingImage(mediaUrl);
            card.ImageLoader.SetImage(card.CardImage);
            var checkLoad = card.ImageLoader.SetImage(card.CardImage);
            while (!checkLoad.IsCompleted)
            {
                await Task.Yield();
            }
            card.RotateCards.ToFront(); 
        }
        await Task.Delay(500);
    }
}
