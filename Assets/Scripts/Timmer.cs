using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Timmer : MonoBehaviour
{
    [SerializeField] private Image timmerImage;
    
    private float startTime = 60f;
    
    public UnityEvent TimeUp;

    private void Start()
    {
        startTime = GameSettings.InGameTime;
    }

    private void Update()
    {
        timmerImage.fillAmount = GameSettings.InGameTime / startTime;
        if (GameSettings.InGameTime <= 0f)
        {
            TimeUp?.Invoke();
        }
        
        GameSettings.InGameTime -= Time.deltaTime;
        
    }
}