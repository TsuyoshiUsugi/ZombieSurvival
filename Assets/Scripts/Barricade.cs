using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Barricade : MonoBehaviour
{
    [SerializeField] private int _price;
    [SerializeField] private Text _priceText;

    private void Start()
    {
        _priceText.text = $"{_price}";
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out var player))
        {
            var result = FindObjectOfType<GameManager>().UseCoin(_price);
            if (result) Destroy(gameObject);
        }
    }
}
