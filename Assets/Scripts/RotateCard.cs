using DG.Tweening;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public enum CardState
{
    FRONT,
    BACK
}
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
    private bool _isActive = false;

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

    public async void StartBack()
    {
        if (_isActive)
            return;
        ToBack();
    }

    public async void StartFront()
    {
        if (_isActive)
            return;
        ToFront();
    }

	public async Task ToBack()
    {
        _isActive = true;
        _frontSide.transform.DORotate(new Vector3(0, 90, 0), _time);
        for (float i = _time; i >= 0; i -= Time.deltaTime)
            await Task.Yield();
        _backSide.transform.DORotate(new Vector3(0, 0, 0), _time);
        _isActive = false;
    }

    public async void ToFront()
    {
        _isActive = true;
        _backSide.transform.DORotate(new Vector3(0, 90, 0), _time);
        for (float i = _time; i >= 0; i -= Time.deltaTime)
            await Task.Yield();
        _frontSide.transform.DORotate(new Vector3(0, 0, 0), _time);
        _isActive = false;
    }
}
