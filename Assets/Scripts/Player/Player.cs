using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] NavMeshAgent _agent;
    [SerializeField] private Transform _playerMoveTarget;
    [SerializeField] private Animator _animator;
    [SerializeField] private Gun _gun;
    [SerializeField] CommonUI _commonUI;
    [SerializeField] float _rotateOffset = 30;
    public float MaxHP { get; private set; } = 100;
    private Vector3 _prevPos;
    private float _hp = 100;
    private GameObject _target;
    public float HP => _hp;
    public Gun Gun => _gun;
    
    // Start is called before the first frame update
    void Start()
    {
        _prevPos = transform.position;
        _commonUI.ShowCoin(0);
    }

    // Update is called once per frame
    void Update()
    {
        _agent.SetDestination(_playerMoveTarget.position);
        Shoot();
        Reload();
        PlayMoveAnim();
        _target = FindNearestEnemy();
        if (_target) LookAtEnemy(_target.gameObject);
    }

    private void LookAtEnemy(GameObject nearestEnemy)
    {
        if (nearestEnemy != null)
        {
            // 敵の方を向く
            Vector3 directionToEnemy = nearestEnemy.transform.position - transform.position;
            directionToEnemy.y = 0; // Y軸の回転は無視する（オプション）
            Quaternion lookRotation = Quaternion.LookRotation(directionToEnemy);
            lookRotation *= Quaternion.AngleAxis(_rotateOffset, Vector3.up); // Y軸の回転を追加
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5); // スムーズな回転
        }
    }

    GameObject FindNearestEnemy()
    {
        var enemies = FindObjectsByType<Enemy>(sortMode: FindObjectsSortMode.None);
        GameObject nearestEnemy = null;
        float minDistance = Mathf.Infinity;
        Vector3 currentPosition = transform.position;

        foreach (var enemy in enemies)
        {
            float distance = Vector3.Distance(enemy.transform.position, currentPosition);
            if (distance < minDistance)
            {
                nearestEnemy = enemy.gameObject;
                minDistance = distance;
            }
        }

        return nearestEnemy;
    }
    
    private void Shoot()
    {
        if (!_target) return;
 
        _gun.Shoot(_target.transform);
        _animator.SetBool("Aiming", true);
    }

    private void Reload()
    {
        if (_gun.CurrentAmmo <= 0 && !_gun.IsReloading)
        {
            _gun.Reload().Forget();
        }
    }

    private void PlayMoveAnim()
    {
        var speed = Vector3.Distance(_prevPos, transform.position);
        _animator.SetFloat("Speed", speed);
        _prevPos = transform.position;
    }
    
    public void Damage(float damage)
    {
        _hp -= damage;
        if (_hp >= 0) _commonUI.ShowHP(_hp);
        if (_hp <= 0)
        {
            // 死亡処理
            Destroy(this.gameObject);
        }
    }
    
    public void Heal(float heal)
    {
         _hp = Math.Min(_hp + heal, MaxHP);
        _commonUI.ShowHP(_hp);
    }
}
