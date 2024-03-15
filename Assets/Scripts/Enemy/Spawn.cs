using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] float _intervalSeconds = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        Observable.Interval(TimeSpan.FromSeconds(_intervalSeconds))
            .Subscribe(_ =>
            {
                // オブジェクトを生成
                Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
            })
            .AddTo(this);
    }
}
