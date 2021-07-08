using System.Collections;
using UnityEngine;

public class MeleeEnemy : Log
{
    private float _attackDuration = 1f;

    protected override void CheckDistance()
    {
        if (Vector3.Distance(_target.position, transform.position) <= _chaseRadius && Vector3.Distance(_target.position, transform.position) > _attackRadius)
        {
            if (CurrentState == EnemyState.Idle || CurrentState == EnemyState.Walk && CurrentState != EnemyState.Stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, _target.position, _moveSpeed * Time.deltaTime);
                UpdateAnimation(temp - transform.position);
                _rigidbody.MovePosition(temp);
                ChangeState(EnemyState.Walk);
            }
        }
        else if(Vector3.Distance(_target.position, transform.position) <= _chaseRadius && Vector3.Distance(_target.position, transform.position) <= _attackRadius)
        {
            if (CurrentState == EnemyState.Walk && CurrentState != EnemyState.Stagger)
            {
                StartCoroutine(AttackCoroutine());
            }
        }
    }

    private IEnumerator AttackCoroutine()
    {
        CurrentState = EnemyState.Attack;
        _animator.SetBool("Attack", true);
        yield return new WaitForSeconds(_attackDuration);
        CurrentState = EnemyState.Walk;
        _animator.SetBool("Attack", false);
    }
}
