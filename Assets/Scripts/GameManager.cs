using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] private float _surviveTime;
    [SerializeField] ResultUI _resultUI;
    [SerializeField] CommonUI _commonUI;
    private IDisposable _timeDisposable;
    private IntReactiveProperty _coinCount = new(0);
    private float _startTime;

    private void Start()
    {
        _startTime = Time.time;
        _player.OnDestroyAsObservable().Subscribe(_ =>
        {
            _timeDisposable.Dispose();
            _resultUI?.ShowResult();
            float elapsedTime = Time.time - _startTime;
            TimeSpan timeSpan = TimeSpan.FromSeconds(elapsedTime);
            _resultUI.SetTimeText(timeSpan);
        }).AddTo(this);

        _timeDisposable = Observable.EveryUpdate().Subscribe(_ =>
        {
            _surviveTime += Time.deltaTime;
            float elapsedTime = Time.time - _startTime;
            TimeSpan timeSpan = TimeSpan.FromSeconds(elapsedTime);
            _commonUI.ShowTime(timeSpan);
        }).AddTo(this);

        _coinCount.Subscribe(count => _commonUI.ShowCoin(count)).AddTo(this);
    }

    public void AddCoin(int num)
    {
        _coinCount.Value += num;
    }
    
    public bool UseCoin(int num)
    {
        if (num > _coinCount.Value) return false;
        _coinCount.Value -= num;
        return true;
    }
}