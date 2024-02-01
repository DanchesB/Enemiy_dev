using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionMaterial : MonoBehaviour
{
    [SerializeField] private Material _explosionTexture;
    private Renderer render;

    private void Start()
    {
        render = GetComponent<Renderer>();
        render.enabled = true;
        render.sharedMaterial = _explosionTexture;
    }
}
