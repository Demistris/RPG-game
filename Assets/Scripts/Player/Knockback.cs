using UnityEngine;

public class Knockback : MonoBehaviour
{
    [SerializeField] private float _thrust;
    [SerializeField] private float _knockTime;
    [SerializeField] private float _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Breakable") && this.CompareTag("Player"))
        {
            collision.GetComponent<ObjectBreaker>().BreakObject();
        }

        if (collision.CompareTag("Enemy") || collision.CompareTag("Player"))
        {
            Rigidbody2D hitRB = collision.GetComponent<Rigidbody2D>();

            if(hitRB != null)
            {
                Vector2 difference = hitRB.transform.position - transform.position;
                difference = difference.normalized * _thrust;
                hitRB.AddForce(difference, ForceMode2D.Impulse);

                if (collision.CompareTag("Enemy") && collision.isTrigger)
                {
                    //Enemies pushing eachother
                    if(!gameObject.CompareTag("Enemy"))
                    {
                        Enemy enemy = collision.GetComponent<Enemy>();
                        enemy.CurrentState = EnemyState.Stagger;
                        enemy.Knock(hitRB, _knockTime, _damage);
                    }
                }

                if(collision.CompareTag("Player"))
                {
                    Player player = collision.GetComponent<Player>();

                    if (player.CurrentState != PlayerState.Stagger)
                    {
                        player.CurrentState = PlayerState.Stagger;
                        player.Knock(_knockTime, _damage);
                    }
                }
            }
        }
    }
}
