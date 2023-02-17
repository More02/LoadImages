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
        }
        if (!ImageLoader.IsCanceled) LoadController.Instanse.InteractableToggle();       
    }

    public static async Task OneByOneLoadImages(string mediaUrl)
    {
        foreach (var card in CardHolder.Instanse.AllCards)
        {
            await card.ImageLoader.LoadingImage(mediaUrl);
            await card.ImageLoader.SetImage(card.CardImage);
        }
        if (!ImageLoader.IsCanceled) LoadController.Instanse.InteractableToggle();
    }

    public static async Task WhenImageReadyLoadImages(string mediaUrl)
    {
        foreach (var card in CardHolder.Instanse.AllCards)
        {            
            card.ImageLoader.LoadingImage(mediaUrl);
            card.ImageLoader.SetImage(card.CardImage);
        }
        if (!ImageLoader.IsCanceled) LoadController.Instanse.InteractableToggle();
    }
}
