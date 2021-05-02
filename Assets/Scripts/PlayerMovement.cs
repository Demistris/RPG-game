using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Animator _animator;

    private Vector3 _movement;

    private void Update()
    {
        _movement = Vector3.zero;
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        MovePlayer();
        UpdateAnimation();
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
