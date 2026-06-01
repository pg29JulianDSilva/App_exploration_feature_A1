using System;
using System.Globalization;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(SphereCollider))]
public class Coin : MonoBehaviour
{
    [Header("Pick Up Values")]
    [SerializeField] private float secondsAdded = 5f;
    [SerializeField] private float scoreTimer = 1f; 

    private int score = 30;
    private float time;

    private void Start()
    {
        time = Time.time;
    }

    private void Update()
    {
        if (Time.time >= scoreTimer + time)
        {
            score--;
            time = Time.time;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameSettings.LocalPlayerScore += score;
            if(GameSettings.InGameTime <= 120f) GameSettings.InGameTime += secondsAdded;
            Destroy(gameObject);
        }
    }
}