using UnityEngine;

public class EnemyDoors : Room
{
    [SerializeField] private Door[] _doors;
    [SerializeField] private SignalListener _enemyUpdate;

    private void CheckEnemies()
    {
        for (int i = 0; i < _enemies.Length; i++)
        {
            if(_enemies[i].gameObject.activeInHierarchy)
            {
                return;
            }
        }

        OpenDoors();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            ChangeActivation(true);
        }

        CloseDoors();
    }

    protected override void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            ChangeActivation(false);
        }
    }

    private void CloseDoors()
    {
        DoorsActivity(false);
    }

    private void OpenDoors()
    {
        DoorsActivity(true);
    }

    private void DoorsActivity(bool openDoor)
    {
        for (int i = 0; i < _doors.Length; i++)
        {
            _doors[i].SetDoorOpen(openDoor);
        }
    }
}
