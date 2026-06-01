using System;
using System.Globalization;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(SphereCollider))]
public class Coin : MonoBehaviour
{
    [SerializeField] private float secondsAdded = 1f;
    [SerializeField] private float scoreTimmer = 1f; 

    private int score = 30;
    private float time;
    
    private Renderer mateirRenderer;

    private void Start()
    {
        time = Time.time;
    }

    private void Update()
    {
        if (Time.time >= scoreTimmer + time)
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