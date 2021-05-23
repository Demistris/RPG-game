using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] protected Signal _powerUpSignal;

    protected void CollectedPowerUp()
    {
        _powerUpSignal.Raise();
        Destroy(gameObject);
    }
}
