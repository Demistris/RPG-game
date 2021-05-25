using Cinemachine;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public List<Enemy> Enemies => _enemies;

    [SerializeField] protected List<Enemy> _enemies = new List<Enemy>();
    [SerializeField] private ObjectBreaker[] _breakableObjects;
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;

    private void Start()
    {
        ChangeActivation(false);
        _virtualCamera.m_Follow = GameObject.FindWithTag("Player").transform;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !collision.isTrigger)
        {
            ChangeActivation(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        for (int i = 0; i < _enemies.Count; i++)
        {
            if (_enemies[i] == null)
            {
                _enemies.RemoveAt(i);
            }
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            ChangeActivation(false);
        }
    }

    protected void ChangeActivation(bool activation)
    {
        _virtualCamera.gameObject.SetActive(activation);

        for (int i = 0; i < _enemies.Count; i++)
        {
            if (_enemies[i] != null)
            {
                _enemies[i].gameObject.SetActive(activation);
            }
        }
        for (int i = 0; i < _breakableObjects.Length; i++)
        {
            if (_breakableObjects[i] != null)
            {
                _breakableObjects[i].gameObject.SetActive(activation);
            }
        }
    }
}
