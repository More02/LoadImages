using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Animation
{
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
        private CardState _cardState = CardState.Back;
        [SerializeField] 
        private float _time = 0.4f;

        private void Init()
        {
            if (_cardState == CardState.Front)
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
            for (var i = _time; i >= 0; i -= Time.deltaTime)
                await Task.Yield();
            _backSide.transform.DORotate(new Vector3(0, 0, 0), _time);
        }

        public async Task ToFront()
        {
            _backSide.transform.DORotate(new Vector3(0, 90, 0), _time);
            for (var i = _time; i >= 0; i -= Time.deltaTime)
                await Task.Yield();
            _frontSide.transform.DORotate(new Vector3(0, 0, 0), _time);
        }
    }
}