using UnityEngine;
using System.Collections;

public enum EnemyState
{
    Idle,
    Walk,
    Attack,
    Stagger
}

public class Enemy : MonoBehaviour
{
    public EnemyState CurrentState;

    [SerializeField] protected FloatValue _maxHealth;
    [SerializeField] protected LootTable _lootTable;
    [SerializeField] protected string _name;
    [SerializeField] protected float _health;
    [SerializeField] protected int _baseAttack;
    [SerializeField] protected float _moveSpeed;

    [SerializeField] private GameObject _deathEffectPrefab;

    private Vector2 _homePosition;
    private float _timeToDestroy = 1f;

    private void Awake()
    {
        _health = _maxHealth.InitialValue;
        _homePosition = transform.position;
    }

    private void OnEnable()
    {
        transform.position = _homePosition;
    }

    public void Knock(Rigidbody2D rigidbody, float knockTime, float damage)
    {
        StartCoroutine(KnockCoroutine(rigidbody, knockTime));
        TakeDamage(damage);
    }

    private void TakeDamage(float damage)
    {
        _health -= damage;
        if(_health <= 0)
        {
            DeathEffect();
            gameObject.SetActive(false);
            Destroy(gameObject, _timeToDestroy);
        }
    }

    private void DeathEffect()
    {
        if(_deathEffectPrefab != null)
        {
            GameObject deathEffect = Instantiate(_deathEffectPrefab, transform.position, Quaternion.identity);
            MakeLoot();
            Destroy(deathEffect, _timeToDestroy);
        }
    }

    private void MakeLoot()
    {
        if(_lootTable != null)
        {
            PowerUp currentLoot = _lootTable.LootPowerUp();

            if(currentLoot != null)
            {
                Instantiate(currentLoot.gameObject, transform.position, Quaternion.identity);
            }
        }
    }

    private IEnumerator KnockCoroutine(Rigidbody2D rigidbody, float knockTime)
    {
        if (rigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            rigidbody.velocity = Vector2.zero;
            CurrentState = EnemyState.Idle;
            rigidbody.velocity = Vector2.zero;
        }
    }
}
