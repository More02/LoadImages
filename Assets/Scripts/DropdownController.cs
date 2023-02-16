using TMPro;
using UnityEngine;

public enum DropdownItems
{
    ALLATONCE = 0,
    ONEBYONE = 1,
    WHENIMAGEREADY = 2
}

public class DropdownController : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown _dropdown;
    private static int _dropdownStatus;

    public static int DropdownStatus 
    { 
        get { return _dropdownStatus; } 
    }

    private void Start()
    {
        _dropdown.onValueChanged.AddListener(delegate {
            OnDropdownValueChanged(_dropdown);
        });
    }

    private void OnDropdownValueChanged(TMP_Dropdown change)
    {
        switch (change.value)
        {
            case (int)DropdownItems.ALLATONCE:
                _dropdownStatus = (int)DropdownItems.ALLATONCE;
                break;
            case (int)DropdownItems.ONEBYONE:
                _dropdownStatus = (int)DropdownItems.ONEBYONE;
                break;
            case(int)DropdownItems.WHENIMAGEREADY:
                _dropdownStatus = (int)DropdownItems.WHENIMAGEREADY;
                break;
            default:
                break;
        }            
    }
}
