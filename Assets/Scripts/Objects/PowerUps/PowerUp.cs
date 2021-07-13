using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] protected Signal _powerUpSignal;
    [SerializeField] protected float _amountToIncrease;

    protected void CollectedPowerUp()
    {
        _powerUpSignal.Raise();
        Destroy(gameObject);
    }
}
