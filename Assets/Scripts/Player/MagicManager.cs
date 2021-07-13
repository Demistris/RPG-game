using UnityEngine;
using UnityEngine.UI;

public class MagicManager : MonoBehaviour
{
    [SerializeField] private Slider _magicSlider;
    [SerializeField] private Inventory _playerInventory;

    private void Start()
    {
        _magicSlider.maxValue = _playerInventory.MaxMagic;
        _magicSlider.value = _playerInventory.MaxMagic;
        _playerInventory.CurrentMagic = _playerInventory.MaxMagic;
    }

    public void AddMagic()
    {
        _magicSlider.value++;
        _playerInventory.CurrentMagic++;

        if(_magicSlider.value >= _magicSlider.maxValue)
        {
            _magicSlider.value = _magicSlider.maxValue;
            _playerInventory.CurrentMagic = _playerInventory.MaxMagic;
        }
    }

    public void DecreaseMagic()
    {
        _magicSlider.value--;
        _playerInventory.CurrentMagic--;

        if (_magicSlider.value <= _magicSlider.minValue)
        {
            _magicSlider.value = 0f;
            _playerInventory.CurrentMagic = 0f;
        }
    }
}
