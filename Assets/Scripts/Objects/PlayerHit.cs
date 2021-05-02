using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Breakable"))
        {
            collision.GetComponent<ObjectBreaker>().BreakObject();
        }
    }
}
