using UnityEngine;

public class TurretEnemy : Log
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _fireDelay;
    private float _timer;
    private bool _canFire;

    protected override void Start()
    {
        base.Start();
        _timer = _fireDelay;
    }

    private void Update()
    {
        _timer -= Time.deltaTime;

        if(_timer <= 0)
        {
            _canFire = true;
            _timer = _fireDelay;
        }
    }

    protected override void CheckDistance()
    {
        if (Vector3.Distance(_target.position, transform.position) <= _chaseRadius && Vector3.Distance(_target.position, transform.position) > _attackRadius)
        {
            if (CurrentState == EnemyState.Idle || CurrentState == EnemyState.Walk && CurrentState != EnemyState.Stagger)
            {
                if (_canFire)
                {
                    _canFire = false;
                    Vector3 tempVector = _target.transform.position - transform.position;
                    Bullet currentBullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
                    currentBullet.Launch(tempVector);
                    ChangeState(EnemyState.Idle);
                    _animator.SetBool("WakeUp", true);
                }
            }
        }
        else if (Vector3.Distance(_target.position, transform.position) > _chaseRadius)
        {
            _animator.SetBool("WakeUp", false);
        }
    }
}
