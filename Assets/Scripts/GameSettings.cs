using UnityEngine;

public static class GameSettings
{
    public static Texture2D PhotoToMaterial = new Texture2D(1,1);

    public static int LocalPlayerScore = 0;
    
    public static float InGameTime = 60f;
    
    public static bool IsGameOver = false;
    
    public static void ApplyMaterial(Material mat)
    {
        if (!PhotoToMaterial || !mat) return;

        mat.mainTexture = PhotoToMaterial;
    }

    public static void RestartGame(float time)
    {
        GameSettings.LocalPlayerScore = 0;
        GameSettings.InGameTime = time;
    }
    
}