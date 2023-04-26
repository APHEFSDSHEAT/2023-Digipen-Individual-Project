using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] bool doYouMultiply = false;
    [SerializeField] float durationOfExplosion = 1f;
    [SerializeField] GameObject explosionVFX;
    [SerializeField] GameObject waddleDee;

    [SerializeField] Vector3 waddlePosition;
    [SerializeField] Vector3 waddlePosition2;

    Level levelScript;

    public bool IsCollide = false;

    //public int points = 10;
    [SerializeField] int scoreValue = 10;

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
