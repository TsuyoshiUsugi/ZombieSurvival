using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float _damage = 10;
    private BoxCollider _boxCollider;

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
        Destroy(gameObject, 3f);
    }

    public void SetDamage(float damage)
    {
        _damage = damage;
    }

    private void FixedUpdate()
    {
        Vector3 boxSize = _boxCollider.size;
        Vector3 boxCenter = transform.TransformPoint(_boxCollider.center); // ワールド空間での中心点
        float maxDistance = 5f; // BoxCastを行う最大の距離
        RaycastHit hit;
        // BoxCastの方向（ここでは下向き）
        Vector3 direction = transform.forward;
        Quaternion orientation = transform.rotation;
        bool isHit = Physics.BoxCast(boxCenter, boxSize / 2, direction, out hit, orientation, maxDistance);
        if (isHit)
        {
            var enemy = hit.collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.Damage(_damage);
            }
            Destroy(gameObject);
        }
    }
}
