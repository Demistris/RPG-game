using System.Collections;
using UnityEngine;

public enum PlayerState
{
    Idle,
    Walk,
    Attack,
    Interact,
    Stagger
}

public class Player : MonoBehaviour
{
    public PlayerState CurrentState;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Animator _animator;
    [SerializeField] private FloatValue _currentHealth;
    [SerializeField] private Signal _playerHealthSignal;
    [SerializeField] private VectorValue _startingPosition;

    private Vector3 _movement;

    private void Start()
    {
        CurrentState = PlayerState.Walk;
        _animator.SetFloat("Horizontal", 0);
        _animator.SetFloat("Vertical", -1);
        transform.position = _startingPosition.InitialValue;
    }

    private void Update()
    {
        _movement = Vector3.zero;
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        if(Input.GetButtonDown("Attack") && CurrentState != PlayerState.Attack && CurrentState != PlayerState.Stagger)
        {
            StartCoroutine(AttackCoroutine());
        }
        else if(CurrentState == PlayerState.Walk || CurrentState == PlayerState.Idle)
        {
            MovePlayer();
            UpdateAnimation();
        }
    }

    private IEnumerator AttackCoroutine()
    {
        _animator.SetBool("Attacking", true);
        CurrentState = PlayerState.Attack;
        yield return null;
        _animator.SetBool("Attacking", false);
        yield return new WaitForSeconds(.3f);
        CurrentState = PlayerState.Walk;
    }

    private void MovePlayer()
    {
        _movement.Normalize();
        _rigidbody.MovePosition(transform.position + _movement * _moveSpeed * Time.deltaTime);
    }

    private void UpdateAnimation()
    {
        if (_movement != Vector3.zero)
        {
            _animator.SetFloat("Horizontal", _movement.x);
            _animator.SetFloat("Vertical", _movement.y);
            _animator.SetBool("Moving", true);
        }
        else
        {
            _animator.SetBool("Moving", false);
        }
    }

    public void Knock(float knockTime, float damage)
    {
        _currentHealth.RuntimeValue -= damage;
        _playerHealthSignal.Raise();

        if (_currentHealth.RuntimeValue > 0)
        {
            StartCoroutine(KnockCoroutine(knockTime));
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private IEnumerator KnockCoroutine(float knockTime)
    {
        if (_rigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            _rigidbody.velocity = Vector2.zero;
            CurrentState = PlayerState.Idle;
            _rigidbody.velocity = Vector2.zero;
        }
    }
}
