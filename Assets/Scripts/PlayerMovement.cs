using System.Collections;
using UnityEngine;

public enum PlayerState
{
    Walk,
    Attack,
    Interact
}

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerState _currentState;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Animator _animator;

    private Vector3 _movement;

    private void Start()
    {
        _currentState = PlayerState.Walk;
    }

    private void Update()
    {
        _movement = Vector3.zero;
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        if(Input.GetButtonDown("Attack") && _currentState != PlayerState.Attack)
        {
            StartCoroutine(AttackCoroutine());
        }
        else if(_currentState == PlayerState.Walk)
        {
            MovePlayer();
            UpdateAnimation();
        }
    }

    private IEnumerator AttackCoroutine()
    {
        _animator.SetBool("Attacking", true);
        _currentState = PlayerState.Attack;
        yield return null;
        _animator.SetBool("Attacking", false);
        yield return new WaitForSeconds(.3f);
        _currentState = PlayerState.Walk;
    }

    private void MovePlayer()
    {
        _rigidbody2D.MovePosition(transform.position + _movement * _moveSpeed * Time.deltaTime);
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
}
