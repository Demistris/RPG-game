using UnityEngine;
using TMPro;

public class Sign : Interactable
{
    [SerializeField] private GameObject _dialogBox;
    [SerializeField] private TextMeshProUGUI _dialogText;
    [SerializeField] public string _dialog;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && _playerInRange)
        {
            if(_dialogBox.activeInHierarchy)
            {
                DialogBoxActivity(false);
            }
            else
            {
                DialogBoxActivity(true);
                _dialogText.text = _dialog;
            }
        }
    }

    private new void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            InRange(false);
            DialogBoxActivity(false);
        }
    }

    private void DialogBoxActivity(bool openDialog)
    {
        _dialogBox.SetActive(openDialog);
    }
}
