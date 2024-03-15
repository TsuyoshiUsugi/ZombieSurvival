using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultUI : MonoBehaviour
{
    [SerializeField] Button _restartButton;
    [SerializeField] Text _resultText;
    [SerializeField] GameObject _resultPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        _restartButton.onClick.AddListener(() =>
        {
            // シーンを再読み込み
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        });
        _resultPanel.SetActive(false);
    }
    
    public void SetTimeText(TimeSpan timeSpan)
    {
        _resultText.text = timeSpan.ToString(@"hh\:mm\:ss");
    }
    public void ShowResult()
    {
        // リザルト画面を表示
        _resultPanel?.SetActive(true);
    }
}
