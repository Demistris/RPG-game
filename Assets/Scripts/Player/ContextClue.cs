using UnityEngine;

public class ContextClue : MonoBehaviour
{
    [SerializeField] private GameObject _contextClue;

    public void Enable()
    {
        _contextClue.SetActive(true);
    }

    public void Disable()
    {
        _contextClue.SetActive(false);
    }
}
