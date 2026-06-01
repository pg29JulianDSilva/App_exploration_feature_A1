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
            GameSettings.IsGameOver = true;
            TimeUp?.Invoke();
        }

        if (GameSettings.LocalPlayerScore > 400)
        {
            GameSettings.InGameTime -= (Time.deltaTime * 4);
            return;
        }
        
        if (GameSettings.LocalPlayerScore > 200)
        {
            GameSettings.InGameTime -= (Time.deltaTime * 2);
            return;
        }
        
        GameSettings.InGameTime -= Time.deltaTime;
        
    }
}