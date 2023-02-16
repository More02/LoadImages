using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

public struct AllAtOnce : IJob
{
    private NativeArray<char> _mediaUrl;
    private MonoBehaviour _monoBehaviourObj;

    public NativeArray<char> MediaUrl
    {
        get { return _mediaUrl; }
        set { _mediaUrl = value; }
    }

    public MonoBehaviour MonoBehaviourObj
    {
        get { return _monoBehaviourObj; }
        set { _monoBehaviourObj = value; }
    }

    public void Execute()
    {
        LoadImages(MediaUrl.ToString(), _monoBehaviourObj);
    }

    public static void LoadImages(string mediaUrl, MonoBehaviour monoBehaviour)
    {
        foreach (var card in CardHolder.Instanse.AllCards)
        {
            //ImageLoader.LoadImage(mediaUrl, card.CardImage);
        }
    }

    
}
