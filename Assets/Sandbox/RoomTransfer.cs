using UnityEngine;
using TMPro;
using System.Collections;

public class RoomTransfer : MonoBehaviour
{
    [SerializeField] private Vector2 _cameraMinChange;
    [SerializeField] private Vector2 _cameraMaxChange;
    [SerializeField] private Vector3 _playerChange;
    [SerializeField] private CameraMovement _cameraMovement;
    [SerializeField] private GameObject _textObject;
    [SerializeField] private TextMeshProUGUI _placeNameText;

    [SerializeField] private bool _needText;
    [SerializeField] private string _placeName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !collision.isTrigger)
        {
            _cameraMovement.MinPosition += _cameraMinChange;
            _cameraMovement.MaxPosition += _cameraMaxChange;

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
