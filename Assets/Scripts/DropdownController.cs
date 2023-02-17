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
    private static DropdownItems _dropdownStatus;

    public TMP_Dropdown Dropdown
    {
        get { return _dropdown; }
    }
    public static DropdownItems DropdownStatus 
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
            case 0:
                _dropdownStatus = DropdownItems.ALLATONCE;
                break;
            case 1:
                _dropdownStatus = DropdownItems.ONEBYONE;
                break;
            case 2:
                _dropdownStatus = DropdownItems.WHENIMAGEREADY;
                break;
            default:
                break;
        }            
    }
}
