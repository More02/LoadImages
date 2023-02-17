using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private Button _loadButton;
    [SerializeField]
    private Button _cancelButton;
    [SerializeField]
    private TMP_Dropdown _dropdown;
    private static string _mediaUrl = "https://picsum.photos/200";

    private void Start()
    {
        _loadButton.onClick.AddListener(LoadButtonHandler);
        _cancelButton.onClick.AddListener(CancelButtonHandler);
        _cancelButton.interactable = false;
    }

    private async void LoadButtonHandler()
    {
        ResetCardsToBack();
        InteractableToggle();
        ImageLoader.IsCanceled = false;      
        if (DropdownController.DropdownStatus == DropdownItems.ALLATONCE)
        {
            await WaysOfLoading.AllAtOnceLoadImages(_mediaUrl);
            if (!ImageLoader.IsCanceled) InteractableToggle();
        }
        else if (DropdownController.DropdownStatus == DropdownItems.ONEBYONE)
        {
            await WaysOfLoading.OneByOneLoadImages(_mediaUrl);
            if (!ImageLoader.IsCanceled) InteractableToggle();
        }
        else if (DropdownController.DropdownStatus == DropdownItems.WHENIMAGEREADY)
        {
            await WaysOfLoading.WhenImageReadyLoadImages(_mediaUrl);
            if (!ImageLoader.IsCanceled) InteractableToggle();
        }
    }

    private void CancelButtonHandler()
    {
        ResetCardsToBack();
        InteractableToggle();
        ImageLoader.IsCanceled = true;        
    }

    public void InteractableToggle ()
    {
        _loadButton.interactable = !_loadButton.interactable;
        _dropdown.interactable = !_dropdown.interactable;
        _cancelButton.interactable = !_cancelButton.interactable;
    }

    private void ResetCardsToBack()
    {
        foreach (var card in CardHolder.Instanse.AllCards)
        {
            card.RotateCards.ToBack();
        }
    }
}
