using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected string _name;
    [SerializeField] protected int _health;
    [SerializeField] protected int _baseAttack;
    [SerializeField] protected float _moveSpeed;
}
