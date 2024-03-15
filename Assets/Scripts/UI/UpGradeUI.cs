using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpGradeUI : MonoBehaviour
{
    [SerializeField] Text _priceText1;
    [SerializeField] Text _priceText2;
    [SerializeField] Text _priceText3;
    [SerializeField] UpgradeManager _upgradeManager;
    
    private void Update()
    {
        _priceText1.text = $"{_upgradeManager.UpgradePrice1}";
        _priceText2.text = $"{_upgradeManager.UpgradePrice2}";
        _priceText3.text = $"{_upgradeManager.UpgradePrice3}";
    }
}
