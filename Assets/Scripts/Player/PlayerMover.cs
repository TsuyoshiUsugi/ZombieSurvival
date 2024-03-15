using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] float _speed = 5f;
    public float maxDistance = 1f; // 最大距離
    
    // Update is called once per frame
    void Update()
    {
        if (!_player) return;
        MoveTarget();
        NormPos();
    }

    private void NormPos()
    {
        float distance = Vector3.Distance(transform.position, _player.position);
        if (distance > maxDistance)
        {
            // 中心点から見たプレイヤーの方向を計算
            Vector3 fromCenterToPlayer = transform.position - _player.position;
            // 最大距離に制限するための新しい位置を計算
            transform.position = _player.position + fromCenterToPlayer.normalized * maxDistance;
        }
    }

    private void MoveTarget()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        if (moveDirection == Vector3.zero)
        {
            // 入力がない場合、プレイヤーを初期位置に戻す
            if (_player) transform.position = _player.position;
        }
        else
        {
            transform.position += moveDirection * (_speed * Time.deltaTime);
        }
    }
}
