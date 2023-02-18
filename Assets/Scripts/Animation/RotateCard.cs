using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// Перечисляемый тип с видами состояния карты
/// </summary>
public enum CardState
{
    FRONT,
    BACK
}

/// <summary>
/// Анимания поворота карты через DOTween
/// </summary>
public class RotateCard : MonoBehaviour
{
    [SerializeField]
    private GameObject _frontSide;
    [SerializeField]
    private GameObject _backSide;
    [SerializeField]
    private CardState _cardState = CardState.BACK;
    [SerializeField]
    private float _time = 0.4f;

    public void Init()
    {
        if (_cardState == CardState.FRONT)
        {
            _frontSide.transform.eulerAngles = Vector3.zero;
            _backSide.transform.eulerAngles = new Vector3(0, 90, 0);
        }
        else
        {
            _frontSide.transform.eulerAngles = new Vector3(0, 90, 0);
            _backSide.transform.eulerAngles = Vector3.zero;
        }
    }

    private void Start()
    {
        Init();
    }

	public async Task ToBack()
    {
        _frontSide.transform.DORotate(new Vector3(0, 90, 0), _time);
        for (float i = _time; i >= 0; i -= Time.deltaTime)
            await Task.Yield();
        _backSide.transform.DORotate(new Vector3(0, 0, 0), _time);
    }

    public async Task ToFront()
    {
        _backSide.transform.DORotate(new Vector3(0, 90, 0), _time);
        for (float i = _time; i >= 0; i -= Time.deltaTime)
            await Task.Yield();
        _frontSide.transform.DORotate(new Vector3(0, 0, 0), _time);
    }
}
