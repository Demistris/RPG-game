using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Vector2 _direction;
    [SerializeField] private float _speed;
    [SerializeField] private float _lifetime;

    private void Start()
    {
        Destroy(gameObject, _lifetime);
    }

    public void Launch(Vector2 initialVelocity)
    {
        _rigidbody.velocity = initialVelocity * _speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
