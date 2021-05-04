using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private string _sceneToLoad;
    [SerializeField] private Vector2 _playerPosition;
    [SerializeField] private VectorValue _playerPositionStorage;
    [SerializeField] private GameObject _fadeOutPanel;
    [SerializeField] private GameObject _fadeInPanel;
    [SerializeField] private float _fadeWait;

    private void Awake()
    {
        if(_fadeOutPanel != null)
        {
            GameObject fadingPanel = Instantiate(_fadeOutPanel, Vector3.zero, Quaternion.identity);
            Destroy(fadingPanel, 1f);
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
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(_sceneToLoad);

        while(!asyncOperation.isDone)
        {
            yield return null;
        }
    }
}
