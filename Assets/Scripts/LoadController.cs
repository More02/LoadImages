using UnityEngine;
using UnityEngine.UI;

public class LoadController : MonoBehaviour
{
    [SerializeField]
    private Button _loadButton;
    [SerializeField]
    private Button _cancelButton;
    [SerializeField]
    private string _mediaUrl = "https://picsum.photos/200";
    

    private void Start()
    {
        _loadButton.onClick.AddListener(LoadImages);
        _cancelButton.onClick.AddListener(CancelLoading);
    }

    private void LoadImages()
    {
        if (DropdownController.DropdownStatus == (int)DropdownItems.WHENIMAGEREADY)
        {
            WhenImageReady.LoadImages(_mediaUrl, this);
        }
    }

    private void CancelLoading()
    {

    }
}
