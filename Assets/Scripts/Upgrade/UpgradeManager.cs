using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] GameObject _upgradePanel;
    [SerializeField] Button _upgradeButton1;
    [SerializeField] Button _upgradeButton2;
    [SerializeField] Button _upgradeButton3;
    [SerializeField] int _upgradePrice1 = 100;
    [SerializeField] int _upgradePrice2 = 300;
    [SerializeField] int _upgradePrice3 = 2000;
    [SerializeField] int _increacePrice = 100;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] GameObject _supplyDrop;
    [SerializeField] GameObject _soldier;
    [SerializeField] OnPlayerUI _onPlayerUI;
    
    public int UpgradePrice1 => _upgradePrice1;
    public int UpgradePrice2 => _upgradePrice2;
    public int UpgradePrice3 => _upgradePrice3;
    
    // Start is called before the first frame update
    void Start()
    {
        _upgradePanel.SetActive(false);
        _upgradeButton1.onClick.AddListener(SupplyDrop);
        _upgradeButton2.onClick.AddListener(CoolTimeDown);
        _upgradeButton3.onClick.AddListener(ReinForce);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            if (!_upgradePanel.activeInHierarchy) _upgradePanel.SetActive(true);
            else _upgradePanel.SetActive(false);
        }
    }

    private void SupplyDrop()
    {
        Debug.Log("Supply Drop!");
        if (_gameManager.UseCoin(_upgradePrice1))
        {
            _onPlayerUI.ShowMessage("Supply Drop!");
            Instantiate(_supplyDrop);
            _upgradePrice1 += _increacePrice;
        }
    }

    private void CoolTimeDown()
    {
        if (_gameManager.UseCoin(_upgradePrice2))
        {
            _onPlayerUI.ShowMessage("Cool Time Down!");
            _upgradePrice2 += _increacePrice;
        }
    }
    
    private void ReinForce()
    {
        if (_gameManager.UseCoin(_upgradePrice3))
        {
            _onPlayerUI.ShowMessage("Reinforce!");
            Instantiate(_soldier);
            _upgradePrice3 += _increacePrice;
        }
    }
}
