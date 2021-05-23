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

    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Animator _animator;
    [SerializeField] private FloatValue _currentHealth;
    [SerializeField] private Signal _playerHealthSignal;
    [SerializeField] private VectorValue _startingPosition;
    [SerializeField] private Inventory _playerInventory;
    [SerializeField] private SpriteRenderer _receivedItemSprite;
    [SerializeField] private Signal _playerHit;

    [SerializeField] private float _moveSpeed;

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
        if(CurrentState == PlayerState.Interact)
        {
            return;
        }

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

        if (CurrentState != PlayerState.Interact)
        {
            CurrentState = PlayerState.Walk;
        }
    }

    public void RaiseItem()
    {
        if (_playerInventory.CurrentItem != null)
        {
            if (CurrentState != PlayerState.Interact)
            {
                _animator.SetBool("ReceivedItem", true);
                CurrentState = PlayerState.Interact;
                _receivedItemSprite.sprite = _playerInventory.CurrentItem.ItemSprite;
            }
            else
            {
                _animator.SetBool("ReceivedItem", false);
                CurrentState = PlayerState.Idle;
                _receivedItemSprite.sprite = null;
                _playerInventory.CurrentItem = null;
            }
        }
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
        _playerHit.Raise();

        if (_rigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            _rigidbody.velocity = Vector2.zero;
            CurrentState = PlayerState.Idle;
            _rigidbody.velocity = Vector2.zero;
        }
    }
}
