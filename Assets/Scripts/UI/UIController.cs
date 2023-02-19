using System;
using System.Threading.Tasks;
using Cards;
using Loading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
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

        private const string MediaUrl = "https://picsum.photos/200";

        private void Start()
        {
            _loadButton.onClick.AddListener(LoadButtonHandler);
            _cancelButton.onClick.AddListener(CancelButtonHandler);
            _cancelButton.interactable = false;
        }

        private async void LoadButtonHandler()
        {
            switch (DropdownController.DropdownStatus)
            {
                case DropdownItems.Allatonce:
                {
                    await PreparationForLoading(TypesOfDelay.Yeld);
                    await WaysOfLoading.AllAtOnceLoadImages(MediaUrl);
                    if (!ImageLoader.IsCanceled) InteractableToggle(false);
                    break;
                }
                case DropdownItems.Onebyone:
                {
                    await PreparationForLoading(TypesOfDelay.Yeld);
                    await WaysOfLoading.OneByOneLoadImages(MediaUrl);
                    if (!ImageLoader.IsCanceled) InteractableToggle(false);
                    break;
                }
                case DropdownItems.Whenimageready:
                {
                    await PreparationForLoading(TypesOfDelay.Delay);
                    await WaysOfLoading.WhenImageReadyLoadImages(MediaUrl);
                    if (!ImageLoader.IsCanceled) InteractableToggle(false);
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private async void CancelButtonHandler()
        {
            ResetCardsToBack();
            await Task.Yield();
            InteractableToggle(false);

            ImageLoader.IsCanceled = true;
        }

        private void InteractableToggle(bool toggle)
        {
            _loadButton.interactable = !toggle;
            _dropdown.interactable = !toggle;
            _cancelButton.interactable = toggle;
        }

        private static void ResetCardsToBack()
        {
            foreach (var card in CardHolder.Instanse.AllCards)
            {
                card.RotateCards.ToBack();
            }
        }

        private async Task PreparationForLoading(TypesOfDelay typeOfDelay)
        {
            ResetCardsToBack();
            switch (typeOfDelay)
            {
                case TypesOfDelay.Yeld:
                    await Task.Yield();
                    break;
                case TypesOfDelay.Delay:
                    await Task.Delay(800);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(typeOfDelay), typeOfDelay, null);
            }

            InteractableToggle(true);
            ImageLoader.IsCanceled = false;
        }
    }
}