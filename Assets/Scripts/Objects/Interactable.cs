using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] protected Signal _context;
    protected bool _playerInRange;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            _context.Raise();
            _playerInRange = true;
        }
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            _context.Raise();
            _playerInRange = false;
        }
    }
}
