using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] public Enemy[] _enemies;
    [SerializeField] private ObjectBreaker[] _breakableObjects;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !collision.isTrigger)
        {
            ChangeActivation(true);
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            ChangeActivation(false);
        }
    }

    protected void ChangeActivation(bool activation)
    {
        for (int i = 0; i < _enemies.Length; i++)
        {
            if (_enemies[i] != null)
            {
                _enemies[i].gameObject.SetActive(activation);
            }
        }
        for (int i = 0; i < _breakableObjects.Length; i++)
        {
            if (_breakableObjects[i] != null)
            {
                _breakableObjects[i].gameObject.SetActive(activation);
            }
        }
    }
}
