using UnityEngine;

public enum DoorType
{
    Key,
    Enemy,
    Button
}

public class Door : Interactable
{
    [SerializeField] private DoorType _thisDoorType;
    [SerializeField] private Inventory _playerInventory;
    [SerializeField] private Room _room;
    [SerializeField] private GameObject _openedDoor;
    [SerializeField] private GameObject _closedDoor;
    [SerializeField] private bool _isOpen;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(_playerInRange)
            {
                if (_thisDoorType == DoorType.Key)
                {
                    if (_playerInventory.NumberOfKeys > 0)
                    {
                        _playerInventory.NumberOfKeys--;
                        SetDoorOpen(true);
                    }
                }
                else if (_thisDoorType == DoorType.Enemy)
                {
                    if(_room.Enemies.Count > 0)
                    {
                        SetDoorOpen(false);
                    }
                    else
                    {
                        SetDoorOpen(true);
                    }
                }
                else if(_thisDoorType == DoorType.Button)
                {
                    Debug.Log("Button doors - not finished");
                }
            }
        }
    }

    public void SetDoorOpen(bool openDoor)
    {
        _openedDoor.SetActive(openDoor);
        _closedDoor.SetActive(!openDoor);
        _isOpen = openDoor;
    }
}
