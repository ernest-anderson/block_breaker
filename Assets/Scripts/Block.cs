using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] int timesHit;
    [SerializeField] Sprite[] hitSprites;

    Level level;
    GameStatus gameStatus;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.CountBreakableBlocks();

        gameStatus = FindObjectOfType<GameStatus>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        if (tag == "Breakable")
        {
            timesHit++;
            int maxHits = hitSprites.Length + 1;
            if (maxHits <= timesHit)
            {
                Destroy(gameObject);
                gameStatus.AddScore();
                TriggerSparklesVFX();
                level.BlockDestroyed();
            }
            else
            {
                ShowNextHitSprites();
            }
        }        
        PlayBlockDestroySFX();
    }

    private void ShowNextHitSprites()
    {
        GetComponent<SpriteRenderer>().sprite = hitSprites[timesHit - 1];
    }

    private void PlayBlockDestroySFX()
    {
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
    }

    public void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 2f);
    }
}