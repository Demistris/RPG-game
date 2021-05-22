using UnityEngine;
using TMPro;

public class Chest : Interactable
{
    [SerializeField] private Item _contents;
    [SerializeField] private Inventory _playerInventory;
    [SerializeField] private bool _isOpen;
    [SerializeField] private Signal _raiseItem;
    [SerializeField] private GameObject _dialogBox;
    [SerializeField] private TextMeshProUGUI _dialogText;
    [SerializeField] private Animator _animator;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _playerInRange)
        {
            if(!_isOpen)
            {
                OpenChest();
            }
            else
            {
                ChestAlreadyOpened();
            }
        }
    }

    private void OpenChest()
    {
        _animator.SetBool("ChestOpened", true);
        _dialogBox.SetActive(true);
        _dialogText.text = _contents.ItemDescription;
        _playerInventory.AddItem(_contents);
        _playerInventory.CurrentItem = _contents;
        _raiseItem.Raise();
        _context.Raise();
        _isOpen = true;
    }

    private void ChestAlreadyOpened()
    {
        _dialogBox.SetActive(false);
        _raiseItem.Raise();
    }

    //Dry1
    protected new void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger && !_isOpen)
        {
            _context.Raise();
            _playerInRange = true;
        }
    }

    //Dry2
    protected new void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger && !_isOpen)
        {
            _context.Raise();
            _playerInRange = false;
        }
    }
}
