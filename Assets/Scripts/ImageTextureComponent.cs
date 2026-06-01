using System;
using UnityEngine;

public class ImageTextureComponent : MonoBehaviour
{
    private Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        GameSettings.ApplyMaterial(renderer.material);
    }
}