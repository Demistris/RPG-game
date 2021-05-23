using UnityEngine;
using TMPro;

public class CoinTextManager : MonoBehaviour
{
    [SerializeField] private Inventory _playerInventory;
    [SerializeField] private TextMeshProUGUI _coinText;

    public void UpdateCoinCount()
    {
        _coinText.text = "" + _playerInventory.Coins;
    }
}
