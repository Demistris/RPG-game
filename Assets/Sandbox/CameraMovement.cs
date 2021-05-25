using System.Collections;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Vector2 MaxPosition;
    public Vector2 MinPosition;

    [SerializeField] private Transform _target;
    [SerializeField] private Animator _animator;
    [SerializeField] private VectorValue _cameraMin;
    [SerializeField] private VectorValue _cameraMax;
    [SerializeField] private float _smoothing;

    private void Start()
    {
        MaxPosition = _cameraMax.InitialValue;
        MinPosition = _cameraMin.InitialValue;

        transform.position = new Vector3(_target.position.x, _target.position.y, transform.position.z);
    }

    private void LateUpdate()
    {
        if(transform.position != _target.position)
        {
            Vector3 targetPosition = new Vector3(_target.position.x, _target.position.y, transform.position.z);

            targetPosition.x = Mathf.Clamp(targetPosition.x, MinPosition.x, MaxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, MinPosition.y, MaxPosition.y);

            transform.position = Vector3.Lerp(transform.position, targetPosition, _smoothing);
        }
    }

    public void BeginKick()
    {
        _animator.SetBool("ScreenKick", true);
        StartCoroutine(KickCoroutine());
    }

    private IEnumerator KickCoroutine()
    {
        yield return null;
        _animator.SetBool("ScreenKick", false);
    }
}
