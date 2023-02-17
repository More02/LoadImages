public static class WhenImageReady
{
    public static async void LoadImages(string mediaUrl)
    {
        foreach (var card in CardHolder.Instanse.AllCards)
        {
            card.ImageLoader.LoadingImage(mediaUrl);
            card.ImageLoader.SetImage(card.CardImage);
        }
    }
}
