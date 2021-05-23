using UnityEngine;

public class AreaEnemy : Log
{
    [SerializeField] private Collider2D _collider;

    protected override void CheckDistance()
    {
        if (Vector3.Distance(_target.position, transform.position) <= _chaseRadius && Vector3.Distance(_target.position, transform.position) > _attackRadius && _collider.bounds.Contains(_target.transform.position))
        {
            if (CurrentState == EnemyState.Idle || CurrentState == EnemyState.Walk && CurrentState != EnemyState.Stagger)
            {
                GoToTarget();
                ChangeState(EnemyState.Walk);
            }
        }
        else if (Vector3.Distance(_target.position, transform.position) > _chaseRadius || !_collider.bounds.Contains(_target.transform.position))
        {
            _animator.SetBool("WakeUp", false);
        }
    }

}
