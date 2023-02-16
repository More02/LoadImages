using UnityEngine;
using UnityEngine.UI;

public class ButtonsController : MonoBehaviour
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
        foreach (var card in CardHolder.Instanse.AllCards)
        {
            StartCoroutine(ImageLoader.LoadImage(_mediaUrl, card.CardImage));
        }
    }

    private void CancelLoading()
    {

    }
}
