using System;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinSpawner : MonoBehaviour
{
    [Header("Spawn Data")]
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
            spawnHeight = Random.Range(((transform.localScale.x - coinPrefab.transform.localScale.x) / 2) * -1, (transform.localScale.x - coinPrefab.transform.localScale.x) / 2);
            spawnWidth = Random.Range(((transform.localScale.z - coinPrefab.transform.localScale.z) / 2) * -1, (transform.localScale.z - coinPrefab.transform.localScale.z) / 2);
            
            Instantiate(coinPrefab, new Vector3(transform.position.x + spawnWidth, transform.position.y + (transform.localScale.y / 2), transform.position.z + spawnHeight), Quaternion.identity);
            currentTime = Time.time;
            
        }
    }
}