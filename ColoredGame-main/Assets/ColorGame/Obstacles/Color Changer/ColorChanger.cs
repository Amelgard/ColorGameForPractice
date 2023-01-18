using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ColorChanger : MonoBehaviour
{
    [SerializeField] private SpriteRenderer splashPrefab;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnDestroy()
    {
        if(splashPrefab != null)
        {
            var splash = Instantiate(splashPrefab, transform.parent);
            
            splash.transform.position = transform.position;
            splash.color = _spriteRenderer.color;
        }
    }
}
