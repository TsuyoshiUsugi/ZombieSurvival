using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class ShopUI : MonoBehaviour
{
    [SerializeField] Text _timeText;
    Shop _shop;
    
    private void Start()
    {
        _shop = FindObjectOfType<Shop>();
        _shop.CurrentTime.Subscribe(time => _timeText.text = time.ToString("F2")).AddTo(this);
        _shop.CurrentTime.Where(x => x <= 0).Subscribe(_ => _timeText.text = "Ready").AddTo(this);
    }
}
