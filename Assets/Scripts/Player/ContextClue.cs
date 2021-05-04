using UnityEngine;

public class ContextClue : MonoBehaviour
{
    [SerializeField] private GameObject _contextClue;

    private bool _contextActive;

    public void ChangeContext()
    {
        _contextActive = !_contextActive;
        _contextClue.SetActive(_contextActive);
    }
}
