using UnityEngine;

public class PatrolEnemy : Log
{
    [SerializeField] private Vector2[] _path;
    [SerializeField] private float _roundingDistance;
    private int _currentPoint;

    protected override void CheckDistance()
    {
        if (Vector3.Distance(_target.position, transform.position) <= _chaseRadius && Vector3.Distance(_target.position, transform.position) > _attackRadius)
        {
            if (CurrentState == EnemyState.Idle || CurrentState == EnemyState.Walk && CurrentState != EnemyState.Stagger)
            {
                GoToTarget();
            }
        }
        else if (Vector3.Distance(_target.position, transform.position) > _chaseRadius)
        {
            if (Vector3.Distance(transform.position, _path[_currentPoint]) > _roundingDistance)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, _path[_currentPoint], _moveSpeed * Time.deltaTime);
                UpdateAnimation(temp - transform.position);
                _rigidbody.MovePosition(temp);
            }
            else
            {
                ChangeGoal();
            }
        }
    }

    private void ChangeGoal()
    {
        if(_currentPoint == _path.Length - 1)
        {
            _currentPoint = 0;
        }
        else
        {
            _currentPoint++;
        }
    }
}
