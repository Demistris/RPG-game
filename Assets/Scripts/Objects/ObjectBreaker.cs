using System.Collections;
using UnityEngine;

public class ObjectBreaker : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _timeToDestroy;

    public void BreakObject()
    {
        _animator.SetBool("Break", true);

        StartCoroutine(BreakCoroutine());
    }

    private IEnumerator BreakCoroutine()
    {
        yield return new WaitForSeconds(_timeToDestroy);
        Destroy(gameObject);
    }
}
