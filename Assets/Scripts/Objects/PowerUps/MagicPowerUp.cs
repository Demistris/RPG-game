using UnityEngine;

public class MagicPowerUp : PowerUp
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !collision.isTrigger)
        {
            _powerUpSignal.Raise();
            Destroy(gameObject);
        }
    }
}
