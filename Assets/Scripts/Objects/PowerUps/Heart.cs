using UnityEngine;

public class Heart : PowerUp
{
    [SerializeField] private FloatValue _playerHealth;
    [SerializeField] private FloatValue _heartContainers;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !collision.isTrigger)
        {
            _playerHealth.RuntimeValue += _amountToIncrease;
            if(_heartContainers.InitialValue > _heartContainers.RuntimeValue * 2f)
            {
                _playerHealth.InitialValue = _heartContainers.RuntimeValue * 2f;
            }

            CollectedPowerUp();
        }
    }
}
