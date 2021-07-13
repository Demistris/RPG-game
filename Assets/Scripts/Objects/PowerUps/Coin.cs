using UnityEngine;

public class Coin : PowerUp
{
    [SerializeField] private Inventory _playerInventory;

    private void Start()
    {
        _powerUpSignal.Raise();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            _playerInventory.Coins += (int)_amountToIncrease;
            CollectedPowerUp();
        }
    }
}
