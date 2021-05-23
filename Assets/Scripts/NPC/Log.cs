using UnityEngine;

public class Log : Enemy
{
    //[SerializeField] private Transform _homePosition;

    [SerializeField] protected Rigidbody2D _rigidbody;
    [SerializeField] protected Animator _animator;
    [SerializeField] protected float _chaseRadius;
    [SerializeField] protected float _attackRadius;

    protected Transform _target;

    private void Start()
    {
        CurrentState = EnemyState.Idle;
        _target = GameObject.FindWithTag("Player").transform;
        _animator.SetBool("WakeUp", true);
    }

    private void FixedUpdate()
    {
        if (_target != null)
        {
            CheckDistance();
        }
    }

    protected virtual void CheckDistance()
    {
        if(Vector3.Distance(_target.position, transform.position) <= _chaseRadius && Vector3.Distance(_target.position, transform.position) > _attackRadius)
        {
            if (CurrentState == EnemyState.Idle || CurrentState == EnemyState.Walk && CurrentState != EnemyState.Stagger)
            {
                GoToTarget();
                ChangeState(EnemyState.Walk);
            }
        }
        else if(Vector3.Distance(_target.position, transform.position) > _chaseRadius)
        {
            _animator.SetBool("WakeUp", false);
        }
    }

    protected void GoToTarget()
    {
        Vector3 temp = Vector3.MoveTowards(transform.position, _target.position, _moveSpeed * Time.deltaTime);
        UpdateAnimation(temp - transform.position);
        _rigidbody.MovePosition(temp);
        _animator.SetBool("WakeUp", true);
    }

    protected void UpdateAnimation(Vector2 direction)
    {
        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if(direction.x > 0)
            {
                SetAnimationFloat(Vector2.right);
            }
            else
            {
                SetAnimationFloat(Vector2.left);
            }
        }
        else if(Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if (direction.y > 0)
            {
                SetAnimationFloat(Vector2.up);
            }
            else
            {
                SetAnimationFloat(Vector2.down);
            }
        }
    }

    private void SetAnimationFloat(Vector2 setVector)
    {
        _animator.SetFloat("Horizontal", setVector.x);
        _animator.SetFloat("Vertical", setVector.y);
    }

    protected void ChangeState(EnemyState newState)
    {
        if(CurrentState != newState)
        {
            CurrentState = newState;
        }
    }
}
