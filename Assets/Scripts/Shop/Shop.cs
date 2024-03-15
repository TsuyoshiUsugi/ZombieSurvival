using UniRx;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] float _heal = 10;
    [SerializeField] float _coolTime = 5;
    public FloatReactiveProperty CurrentTime { get; private set; } = new(0);
    
    private void Update()
    {
        if (CurrentTime.Value > 0) CurrentTime.Value -= Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        if (CurrentTime.Value > 0) return;
        if (other.TryGetComponent<Player>(out var player))
        {
            if (player.HP >= player.MaxHP) return;
            player.Heal(_heal);
            CurrentTime.Value = _coolTime;
        }
    }
}
