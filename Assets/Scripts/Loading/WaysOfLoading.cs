using System.Threading.Tasks;

/// <summary>
/// Виды загрузки и отображения изображений 
/// </summary>
public static class WaysOfLoading 
{
    /// <summary>
    /// Параллельная загрузка и показ изображений
    /// </summary>
    /// <param name="mediaUrl"></param>
    /// <returns></returns>
    public static async Task AllAtOnceLoadImages(string mediaUrl)
    {
        foreach (var card in CardHolder.Instanse.AllCards)
        {
            await card.ImageLoader.LoadingImage(mediaUrl);
        }
        foreach (var card in CardHolder.Instanse.AllCards)
        {
            await card.ImageLoader.SetImage(card.CardImage);
            card.ImageLoader.RotateAfterSetting(card);
        }
    }

    /// <summary>
    /// Последовательная загрузка и показ изображений
    /// </summary>
    /// <param name="mediaUrl"></param>
    /// <returns></returns>
    public static async Task OneByOneLoadImages(string mediaUrl)
    {
        foreach (var card in CardHolder.Instanse.AllCards)
        {
            await card.ImageLoader.LoadingImage(mediaUrl);
            await card.ImageLoader.SetImage(card.CardImage);
        }
        foreach (var card in CardHolder.Instanse.AllCards)
        {
            await card.ImageLoader.RotateAfterSetting(card);
        }
    }

    /// <summary>
    /// Загрузка и показ изображений по готовности
    /// </summary>
    /// <param name="mediaUrl"></param>
    /// <returns></returns>
    public static async Task WhenImageReadyLoadImages(string mediaUrl)
    {
        foreach (var card in CardHolder.Instanse.AllCards)
        {            
            card.ImageLoader.LoadingImage(mediaUrl);
            card.ImageLoader.SetImage(card.CardImage);
            card.ImageLoader.RotateAfterSetting(card);
        }

        await Task.Delay(500);
    }
}
