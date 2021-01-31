using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TaxiManager.Customers
{
    public class CustomerSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject customerPrefab;
        [SerializeField] private float timePerSpawn;
        [SerializeField] private float spawnTimeVariance;
        private DropOff[] _dropOffs;

        private void Awake()
        {
            _dropOffs = GetComponentsInChildren<DropOff>();
        }

        private IEnumerator Start()
        {

            while (true)
            {
                yield return new WaitForSeconds(Random.Range(timePerSpawn - spawnTimeVariance,
                    timePerSpawn + spawnTimeVariance));
                SpawnCustomer();
            }
            
        }

        private void SpawnCustomer()
        {
            var validDropOffs = _dropOffs.Where(d => !d.IsOccupied).ToArray();
            if (validDropOffs.Length == 0) return;
            var dropOff = validDropOffs[Random.Range(0, validDropOffs.Length)];
            Instantiate(customerPrefab, dropOff.transform);
        }
        
    }
    
}
