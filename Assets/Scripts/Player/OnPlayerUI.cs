using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class OnPlayerUI : MonoBehaviour
{
    [SerializeField] private Text _text;

    private void Start()
    {
        _text.text = "";
    }

    public async UniTaskVoid ShowMessage(string message)
    {
        _text.text = message;
        await UniTask.Delay(TimeSpan.FromSeconds(1));
        _text.text = "";
    }
}
