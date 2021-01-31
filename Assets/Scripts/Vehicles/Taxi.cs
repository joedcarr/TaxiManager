using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace TaxiManager.Vehicles
{
 
    [RequireComponent(typeof(NavMeshAgent))]
    public class Taxi : MonoBehaviour
    {
        [SerializeField] private float searchDistance;
        [SerializeField] private float distanceThreshold;
        private Vector3 _destination;
        private NavMeshAgent _navMeshAgent;

        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            SetRandomDestination();
        }

        private void Update()
        {

            if (CheckIfReachedDestination())
            {
                SetRandomDestination();
            }

        }

        private bool CheckIfReachedDestination()
        {
            return _navMeshAgent.remainingDistance <= distanceThreshold;
        }

        private void SetRandomDestination()
        {
            _destination = GetRandomDestination();
            _navMeshAgent.SetDestination(_destination);
        }

        private Vector3 GetRandomDestination()
        {
            var target = transform.position + (Random.insideUnitSphere * searchDistance);
            NavMesh.SamplePosition(target, out var hit, searchDistance, _navMeshAgent.areaMask);
            return hit.position;
        }
        
    }
    
}
