using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    Level level;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.CountBreakableBlocks();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);        
        Destroy(gameObject);
        level.BlockDestroyed();
    }
}