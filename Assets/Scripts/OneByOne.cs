using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneByOne : MonoBehaviour
{
    public static async void LoadImages(string mediaUrl)
    {
        foreach (var card in CardHolder.Instanse.AllCards)
        {
            await ImageLoader.LoadOneByOne(mediaUrl, card.CardImage);
        }
    }
}
