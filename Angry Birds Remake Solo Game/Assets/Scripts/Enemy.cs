using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Level levelScript;
    [Header("bools")]
    [SerializeField] bool doYouMultiply = false;
    public bool IsCollide = false;

    [Header("waddleDee")]
    [SerializeField] GameObject waddleDee;
    [SerializeField] Vector3 waddlePosition;
    [SerializeField] Vector3 waddlePosition2;

    /*[Header("sound")]
    [SerializeField] AudioClip deathSFX;
    [SerializeField][Range(0, 1)] float deathSFXVolume = 0.75f;
    */


    [Header("variables")]
    [SerializeField] float durationOfExplosion = 1f;
    [SerializeField] GameObject explosionVFX;
    [SerializeField] int scoreValue = 10;
    //public int points = 10;

    private void Start()
    {
        levelScript = FindObjectOfType<Level>();
        if (tag == "Enemy")
        {
            levelScript.CountEnemies();
        }
    }

    void Update()
    {
        IfDead();
        IfDeadAndMultiply();
    }


    public void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Bird")
        {
            IsCollide = true;
        }
    }

    private void IfDead()
    {
        if (IsCollide == true && doYouMultiply ==false)
        {
            //AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathSFXVolume);
            FindObjectOfType<GameSession>().AddToScore(scoreValue);
            //Score.instance.AddPoint(points);
            GameObject explosion = Instantiate(explosionVFX, transform.position, transform.rotation);
            Destroy(explosion, durationOfExplosion);
            Destroy(gameObject);
            levelScript.enemyDied();
        }
    }
    private void IfDeadAndMultiply()
    {
        if (IsCollide == true && doYouMultiply == true)
        {
            //AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathSFXVolume);
            GameObject moreMultipliedWaddleDee = Instantiate(waddleDee, waddlePosition, transform.rotation);
            GameObject moreMultipliedWaddleDee2 = Instantiate(waddleDee, waddlePosition2, transform.rotation);
            FindObjectOfType<GameSession>().AddToScore(scoreValue);
            //Score.instance.AddPoint(points);
            GameObject explosion = Instantiate(explosionVFX, transform.position, transform.rotation);
            Destroy(explosion, durationOfExplosion);
            Destroy(gameObject);
            levelScript.enemyDied();
        }
    }
}
