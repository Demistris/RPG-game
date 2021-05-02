using UnityEngine;

public class Log : Enemy
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Transform _homePosition;
    [SerializeField] private float _chaseRadius;
    [SerializeField] private float _attackRadius;

    private Transform _target;
    

    private void Start()
    {
        _target = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        if (_target != null)
        {
            CheckDistance();
        }
    }

    private void CheckDistance()
    {
        if(Vector3.Distance(_target.position, transform.position) <= _chaseRadius && Vector3.Distance(_target.position, transform.position) > _attackRadius)
        {
            Vector3 temp = Vector3.MoveTowards(transform.position, _target.position, _moveSpeed * Time.deltaTime);
            _rigidbody.MovePosition(temp);
        }
    }
}
