using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RabbitAI : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    public Transform targetPosition;

    private float speed = 2;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = speed;
    }

    private void Update()
    {
        navMeshAgent.destination = targetPosition.position;
    }
}