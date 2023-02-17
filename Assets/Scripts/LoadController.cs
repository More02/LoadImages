using System.Threading;
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

    private static void LoadImages()
    {
        if (DropdownController.DropdownStatus == DropdownItems.WHENIMAGEREADY)
        {
            WaysOfLoading.WhenImageReadyLoadImages(_mediaUrl);
        }
        else if (DropdownController.DropdownStatus == DropdownItems.ALLATONCE)
        {
            WaysOfLoading.AllAtOnceLoadImages(_mediaUrl);
        }
        else if (DropdownController.DropdownStatus == DropdownItems.ONEBYONE)
        {
            WaysOfLoading.OneByOneLoadImages(_mediaUrl);
        }
    }

    private void CancelLoading()
    {
        WaysOfLoading.AbordLoadImages();
    }

}
