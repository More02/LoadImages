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
    private static LoadController _instance;

    public static string MediaUrl
    {
        get { return _mediaUrl; }
    }

    private static LoadController _instanse;
    public static LoadController Instanse
    {
        get { return _instanse; }
        private set { _instanse = value; }
    }


    private void Start()
    {
        _loadButton.onClick.AddListener(LoadImages);
        _cancelButton.onClick.AddListener(CancelLoading);
        Instanse = this;
    }

    private void LoadImages()
    {
        if (DropdownController.DropdownStatus == DropdownItems.WHENIMAGEREADY)
        {
            WhenImageReady.LoadImages(_mediaUrl);
        }
        else if (DropdownController.DropdownStatus == DropdownItems.ALLATONCE)
        {
            //AllAtOnce jobData = new AllAtOnce();
            //jobData.MediaUrl = (NativeArray<char>)_mediaUrl;
            //jobData.MonoBehaviourObj = this;
            //jobData.MediaUrl = (NativeArray<char>)_mediaUrl;
            //jobData.MonoBehaviourObj = this;
            //JobHandle handle = jobData.Schedule();
            //handle.Complete();
        }
        else if (DropdownController.DropdownStatus == DropdownItems.ONEBYONE)
        {
            OneByOne.LoadImages(_mediaUrl);
        }
    }

    private void CancelLoading()
    {

    }

}
