using TMPro;
using UnityEngine;

namespace UI
{
    /// <summary>
    /// Обработка выпадающего списка с видами загрузки и отображения изображений
    /// </summary>
    public class DropdownController : MonoBehaviour
    {
        [SerializeField]
        private TMP_Dropdown _dropdown;

        public static DropdownItems DropdownStatus { get; private set; }

        private void Start()
        {
            _dropdown.onValueChanged.AddListener(delegate {
                OnDropdownValueChanged(_dropdown);
            });
        }

        private static void OnDropdownValueChanged(TMP_Dropdown change)
        {
            DropdownStatus = change.value switch
            {
                0 => DropdownItems.Allatonce,
                1 => DropdownItems.Onebyone,
                2 => DropdownItems.Whenimageready,
                _ => DropdownStatus
            };
        }
    }
}
