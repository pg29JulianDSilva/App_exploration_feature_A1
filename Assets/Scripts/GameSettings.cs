using UnityEngine;

public static class GameSettings
{
    public static Texture2D PhotoToMaterial = new Texture2D(1,1);

    public static void ApplyMaterial(Material mat)
    {
        if (!PhotoToMaterial || !mat) return;

        mat.mainTexture = PhotoToMaterial;
    }
}