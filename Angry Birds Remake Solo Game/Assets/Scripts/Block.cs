using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] GameObject blockDestroyVFX;
    int timesHit;
    [SerializeField] Sprite[] blockHitSprites;

    Level levelScript;

    //public int points = 5;
    [SerializeField] int scoreValue = 10;

    [Header("Sound")]
    [SerializeField] AudioClip deathSFX;


    // Start is called before the first frame update
    private void Start()
    {
        levelScript = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            levelScript.CountBreakableBlocks();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision) //will making it OnTriggerEnter2D work? (maybe im missing something, no work
    {
        if (collision.gameObject.tag == "Bird" /*tag == "Breakable"*/) // objects colliding with "Breakable" will trigger ShowNextHitSprite() and eventually DestroyBlock()
        {
            timesHit++;
            int maxHits = blockHitSprites.Length + 1;
            if (timesHit >= maxHits)
            {
                DestroyBlock();
            }
            else
            {
                ShowNextHitSprite(); 
            }

        }

    }
    private void ShowNextHitSprite()
    {
        AudioManager.instance.PlayClip(deathSFX);
        int spriteIndex = timesHit - 1;
        GetComponent<SpriteRenderer>().sprite = blockHitSprites[spriteIndex];
    }
    private void DestroyBlock()
    {
        AudioManager.instance.PlayClip(deathSFX);
        FindObjectOfType<GameSession>().AddToScore(scoreValue);
        levelScript.blockDestroyed();
        TriggerBlockBreakVFX();
        Destroy(gameObject);
    }
    private void TriggerBlockBreakVFX()
    {

        GameObject VFX = Instantiate(blockDestroyVFX, transform.position, transform.rotation);
        Destroy(VFX, 1f);
    }

}
