using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed;

    private float _timtimeToDestroy = 5f;

    private void Start()
    {
        DestroyArrow(_timtimeToDestroy);
    }

    public void Setup(Vector2 velocity, Vector3 direction)
    {
        _rigidbody.velocity = velocity.normalized * _speed;
        transform.rotation = Quaternion.Euler(direction);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            DestroyArrow(0f);
        }
    }

    private void DestroyArrow(float timeToDestroy)
    {
        Destroy(gameObject, timeToDestroy);
    }
}
