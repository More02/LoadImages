using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.UI;

public class LoadController : MonoBehaviour
{
    [SerializeField]
    private Button _loadButton;
    [SerializeField]
    private Button _cancelButton;
    [SerializeField]
    private static string _mediaUrl = "https://picsum.photos/200";

    public static string MediaUrl
    {
        get { return _mediaUrl; }
    }
    

    private void Start()
    {
        _loadButton.onClick.AddListener(LoadImages);
        _cancelButton.onClick.AddListener(CancelLoading);
    }

    private void LoadImages()
    {
        if (DropdownController.DropdownStatus == DropdownItems.WHENIMAGEREADY)
        {
            WhenImageReady.LoadImages(_mediaUrl);
        }
        if (DropdownController.DropdownStatus == DropdownItems.ALLATONCE)
        {
            AllAtOnce jobData = new AllAtOnce();
            //jobData.MediaUrl = (NativeArray<char>)_mediaUrl;
            //jobData.MonoBehaviourObj = this;
            //jobData.MediaUrl = (NativeArray<char>)_mediaUrl;
            //jobData.MonoBehaviourObj = this;
            JobHandle handle = jobData.Schedule();
            handle.Complete();
        }
    }

    private void CancelLoading()
    {

    }

}
