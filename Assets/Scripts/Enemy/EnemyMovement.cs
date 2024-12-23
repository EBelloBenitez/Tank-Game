using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private GameObject _player;
    private NavMeshAgent _agent;
    
    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _agent = GetComponent<NavMeshAgent>();
    }
    
    void Update()
    {
        if (_player == null)
            return;
        
        _agent.SetDestination(_player.transform.position);
    }
}
