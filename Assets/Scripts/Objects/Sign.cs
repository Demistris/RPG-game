using UnityEngine;
using TMPro;

public class Sign : MonoBehaviour
{
    [SerializeField] private Signal _contextOn;
    [SerializeField] private Signal _contextOff;
    [SerializeField] private GameObject _dialogBox;
    [SerializeField] private TextMeshProUGUI _dialogText;
    [SerializeField] private string _dialog;
    private bool _playerInRange;

    //Fix display dialog
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && _playerInRange)
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            _contextOn.Raise();
            _playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _contextOff.Raise();
            _playerInRange = false;
            _dialogBox.SetActive(false);
        }
    }
}
