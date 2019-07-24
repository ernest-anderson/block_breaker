using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] GameObject unbreakableBlock;

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
            Destroy(gameObject);
            gameStatus.AddScore();
            TriggerSparklesVFX();
            level.BlockDestroyed();
        }
        else {            
            Destroy(gameObject);
            GameObject block = Instantiate(unbreakableBlock, transform.position, transform.rotation);
        }
        PlayBlockDestroySFX();
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