using System;
using System.Collections;
using System.Collections.Generic;
using UltimateClean;
using UnityEngine;
using UnityEngine.UI;

public class CommonUI : MonoBehaviour
{
    [SerializeField] Text _timeText;
    [SerializeField] Text _coinText;
    [SerializeField] SlicedFilledImage _hpBar;
    public void ShowTime(TimeSpan timeSpan)
    {
        _timeText.text = timeSpan.ToString(@"hh\:mm\:ss");
    }
    
    public void ShowHP(float hp)
    {
        _hpBar.fillAmount = hp / 100;
    }
    
    public void ShowCoin(int coin)
    {
        _coinText.text = $"{coin}";
    }
}
