using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Vector3 _offset;

    private void Start()
    {
        _offset = transform.position - _player.position;
    }

    private void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        if (!_player) return;
        transform.position = _player.position + _offset;
        transform.LookAt(_player);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            foreach (var renderer in other.GetComponentsInChildren<Renderer>())
            {
                renderer.enabled = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            foreach (var renderer in other.GetComponentsInChildren<Renderer>())
            {
                renderer.enabled = true;
            }
        }
    }
}