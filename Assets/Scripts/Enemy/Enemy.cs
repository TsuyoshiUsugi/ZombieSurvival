using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] float _damage = 1;
    [SerializeField] int _coin = 10;
    [SerializeField] float _attackRange = 1;
    private float _hp = 100;
    private Transform _player;
    private NavMeshAgent _agent;
    
    private void Start()
    {
        _player = FindObjectOfType<Player>()?.transform;
        _agent = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate()
    {
        if (_player)
        {
            Attack();
            _agent.SetDestination(_player.position);
        }
    }

    public void Damage(float damage)
    {
        _hp -= damage;
        if (_hp <= 0)
        {
            FindObjectOfType<GameManager>().AddCoin(_coin);
            Destroy(gameObject);
        }
    }

    private void Attack()
    {
        if (Vector3.Distance(transform.position, _player.position) < _attackRange)
        {
            _player.GetComponent<Player>().Damage(_damage);
        }
    }
}
