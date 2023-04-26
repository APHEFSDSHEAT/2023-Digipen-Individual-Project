using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MultipliedEnemy : MonoBehaviour
{

    [SerializeField] float durationOfExplosion = 1f;
    [SerializeField] GameObject explosionVFX;




    Level levelScript;

    public bool IsCollide = false;

    //public int points = 10;
    [SerializeField] int scoreValue = 10;

    private void Start()
    {
        /*levelScript = FindObjectOfType<Level>();
        if (tag == "Enemy")
        {
            levelScript.CountEnemies();
        }*/
    }

    void Update()
    {
        IfDead();
      
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bird")
        {
            IsCollide = true;
        }
    }

    private void IfDead()
    {
        if (IsCollide == true)
        {
            FindObjectOfType<GameSession>().AddToScore(scoreValue);
            //Score.instance.AddPoint(points);
            GameObject explosion = Instantiate(explosionVFX, transform.position, transform.rotation);
            Destroy(explosion, durationOfExplosion);
            Destroy(gameObject);
        
        }
    }
    
}
