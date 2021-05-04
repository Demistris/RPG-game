using UnityEngine;
using TMPro;
using System.Collections;

public class RoomTransfer : MonoBehaviour
{
    [SerializeField] private Vector2 _cameraChange;
    [SerializeField] private Vector3 _playerChange;
    [SerializeField] private CameraMovement _cameraMovement;

    [SerializeField] private bool _needText;
    [SerializeField] private string _placeName;
    [SerializeField] private GameObject _textObject;
    [SerializeField] private TextMeshProUGUI _placeNameText;

    //Add cam boundries for big map
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !collision.isTrigger)
        {
            _cameraMovement.MinPosition += _cameraChange;
            _cameraMovement.MaxPosition += _cameraChange;

            collision.transform.position += _playerChange;

            if(_needText)
            {
                StartCoroutine(PlaceNameCoroutine());
            }
        }
    }

    //Fix this
    private IEnumerator PlaceNameCoroutine()
    {
        if (_placeName != null)
        {
            _textObject.SetActive(true);
            _placeNameText.text = _placeName;
            yield return new WaitForSeconds(4f);
            _textObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Place name is null");
        }
    }
}
