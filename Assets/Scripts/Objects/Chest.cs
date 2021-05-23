using UnityEngine;
using TMPro;

public class Chest : Interactable
{
    [SerializeField] private Item _contents;
    [SerializeField] private Inventory _playerInventory;
    [SerializeField] private Signal _raiseItem;
    [SerializeField] private GameObject _dialogBox;
    [SerializeField] private TextMeshProUGUI _dialogText;
    [SerializeField] private Animator _animator;
    [SerializeField] private BoolValue _storedOpen;
    [SerializeField] private bool _isOpen;

    private void Start()
    {
        _isOpen = _storedOpen.RuntimeValue;

        if(_isOpen)
        {
            _animator.SetBool("ChestOpened", true);
        }
    }

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
        _storedOpen.RuntimeValue = _isOpen;
    }

    private void ChestAlreadyOpened()
    {
        _dialogBox.SetActive(false);
        _raiseItem.Raise();
    }

    protected new void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger && !_isOpen)
        {
            InRange(true);
        }
    }

    protected new void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger && !_isOpen)
        {
            InRange(false);
        }
    }
}
