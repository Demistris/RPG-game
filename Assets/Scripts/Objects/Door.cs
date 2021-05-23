using UnityEngine;

public enum DoorType
{
    Key,
    Enemy,
    Button
}

public class Door : Interactable
{
    [Header("Door variables")]
    [SerializeField] private DoorType _thisDoorType;
    [SerializeField] private bool _isOpen;
    [SerializeField] private Inventory _playerInventory;

    [SerializeField] private GameObject _openedDoor;
    [SerializeField] private GameObject _closedDoor;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(_playerInRange && _thisDoorType == DoorType.Key)
            {
                if(_playerInventory.NumberOfKeys > 0)
                {
                    _playerInventory.NumberOfKeys--;
                    SetDoorOpen(true);
                }
            }
        }
    }

    private void SetDoorOpen(bool openDoor)
    {
        _openedDoor.SetActive(openDoor);
        _closedDoor.SetActive(!openDoor);
        _isOpen = openDoor;
    }
}
