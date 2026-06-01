using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [Header("Text Display")]
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Update()
    {
        scoreText.text = $"Score: {GameSettings.LocalPlayerScore}";
    }
}