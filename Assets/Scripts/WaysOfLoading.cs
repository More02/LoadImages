public static class WaysOfLoading 
{
    public static async void AllAtOnceLoadImages(string mediaUrl)
    {
        foreach (var card in CardHolder.Instanse.AllCards)
        {
            card.ImageLoader.IsCanceled = false;
            await card.ImageLoader.LoadingImage(mediaUrl);
        }
        foreach (var card in CardHolder.Instanse.AllCards)
        {
            await card.ImageLoader.SetImage(card.CardImage);
        }
    }

    public static async void OneByOneLoadImages(string mediaUrl)
    {
        foreach (var card in CardHolder.Instanse.AllCards)
        {
            card.ImageLoader.IsCanceled = false;
            await card.ImageLoader.LoadingImage(mediaUrl);
            await card.ImageLoader.SetImage(card.CardImage);
        }
    }

    public static void WhenImageReadyLoadImages(string mediaUrl)
    {
        foreach (var card in CardHolder.Instanse.AllCards)
        {
            card.ImageLoader.IsCanceled = false;
            card.ImageLoader.LoadingImage(mediaUrl);
            card.ImageLoader.SetImage(card.CardImage);
        }
    }

    public static void AbordLoadImages()
    {
        foreach (var card in CardHolder.Instanse.AllCards)
        {
            card.ImageLoader.AbortRequest();
        }
    }
}
