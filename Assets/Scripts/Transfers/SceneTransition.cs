using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private Vector2 _playerPosition;
    [SerializeField] private Vector2 _cameraNewMin;
    [SerializeField] private Vector2 _cameraNewMax;

    [SerializeField] private VectorValue _cameraMin;
    [SerializeField] private VectorValue _cameraMax;
    [SerializeField] private VectorValue _playerPositionStorage;
    [SerializeField] private GameObject _fadeOutPanel;
    [SerializeField] private GameObject _fadeInPanel;

    [SerializeField] private string _sceneToLoad;
    [SerializeField] private float _fadeWait;

    private float _timeToDestroy = 1f;

    private void Awake()
    {
        if(_fadeOutPanel != null)
        {
            GameObject fadingPanel = Instantiate(_fadeOutPanel, Vector3.zero, Quaternion.identity);
            Destroy(fadingPanel, _timeToDestroy);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !collision.isTrigger)
        {
            _playerPositionStorage.InitialValue = _playerPosition;
            StartCoroutine(FadeCoroutine());
        }
    }

    private IEnumerator FadeCoroutine()
    {
        if (_fadeInPanel != null)
        {
            Instantiate(_fadeInPanel, Vector3.zero, Quaternion.identity);
        }

        yield return new WaitForSeconds(_fadeWait);

        ResetCameraBounds();
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(_sceneToLoad);

        while(!asyncOperation.isDone)
        {
            yield return null;
        }
    }

    private void ResetCameraBounds()
    {
        _cameraMax.InitialValue = _cameraNewMax;
        _cameraMin.InitialValue = _cameraNewMin;
    }
}
