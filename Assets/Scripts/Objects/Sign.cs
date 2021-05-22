using UnityEngine;
using TMPro;

public class Sign : Interactable
{
    [SerializeField] private GameObject _dialogBox;
    [SerializeField] private TextMeshProUGUI _dialogText;
    [SerializeField] private string _dialog;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && _playerInRange)
        {
            if(_dialogBox.activeInHierarchy)
            {
                _dialogBox.SetActive(false);
            }
            else
            {
                _dialogBox.SetActive(true);
                _dialogText.text = _dialog;
            }
        }
    }

    //Dry
    private new void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            _context.Raise();
            _playerInRange = false;
            _dialogBox.SetActive(false);
        }
    }
}
