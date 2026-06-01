using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private float spawnRate = 5;
    private float currentTime;

    private float spawnWidth;
    private float spawnHeight;

    private void Start()
    {
        currentTime = Time.time;
    }

    private void Update()
    {
        
        if(!coinPrefab) return;
        
        if (Time.time >= currentTime + spawnRate)
        {
            spawnWidth = Random.Range((transform.localScale.x / 2) * -1,transform.localScale.x / 2);
            spawnHeight = Random.Range((transform.localScale.z / 2) * -1,transform.localScale.z / 2);
            
            Instantiate(coinPrefab, new Vector3(transform.position.x + spawnWidth, transform.position.y + (transform.localScale.y / 2), transform.position.z + spawnHeight), Quaternion.identity);
            currentTime = Time.time;
        }
    }
}