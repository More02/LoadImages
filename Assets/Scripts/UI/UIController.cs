using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Перечисляемый тип с видами задержки 
/// </summary>
public enum TypesOfDelay
{
    YELD,
    DELAY
}

/// <summary>
/// Обработка нажатий на UI элементы
/// </summary>
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
        if (DropdownController.DropdownStatus == DropdownItems.ALLATONCE)
        {
            await PreparationForLoading(TypesOfDelay.YELD);
            await WaysOfLoading.AllAtOnceLoadImages(_mediaUrl);
            if (!ImageLoader.IsCanceled) InteractableToggle(false);
        }
        else if (DropdownController.DropdownStatus == DropdownItems.ONEBYONE)
        {
            await PreparationForLoading(TypesOfDelay.YELD);
            await WaysOfLoading.OneByOneLoadImages(_mediaUrl);
            if (!ImageLoader.IsCanceled) InteractableToggle(false);
        }
        else if (DropdownController.DropdownStatus == DropdownItems.WHENIMAGEREADY)
        {
            await PreparationForLoading(TypesOfDelay.DELAY);
            await WaysOfLoading.WhenImageReadyLoadImages(_mediaUrl);
            if (!ImageLoader.IsCanceled) InteractableToggle(false);
        }
    }

    private async void CancelButtonHandler()
    {
        ResetCardsToBack();
        await Task.Yield();
        InteractableToggle(false);
        
        ImageLoader.IsCanceled = true;        
    }

    public void InteractableToggle (bool toggle)
    {
        _loadButton.interactable = !toggle;
        _dropdown.interactable = !toggle;
        _cancelButton.interactable = toggle;
    }

    private void ResetCardsToBack()
    {
        foreach (var card in CardHolder.Instanse.AllCards)
        {
            card.RotateCards.ToBack();
        }
    }

    private async Task PreparationForLoading(TypesOfDelay typeOfDelay)
    {
        ResetCardsToBack();
        if (typeOfDelay == TypesOfDelay.YELD)
        {
            await Task.Yield();
        }
        else if (typeOfDelay == TypesOfDelay.DELAY)
        {
            await Task.Delay(800);
        }       
        InteractableToggle(true);
        ImageLoader.IsCanceled = false;
    }
}
