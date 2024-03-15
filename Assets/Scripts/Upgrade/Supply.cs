using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Supply : MonoBehaviour
{
    [SerializeField] private int _upDamage = 1;
    [SerializeField] private GameObject _para;
    private OnPlayerUI _onPlayerUI;

    private void Start()
    {
        _onPlayerUI = FindObjectOfType<OnPlayerUI>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            _onPlayerUI.ShowMessage("Damage Up!");
            player.Gun.AddDamage(_upDamage);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        _para.SetActive(false);
    }
}
