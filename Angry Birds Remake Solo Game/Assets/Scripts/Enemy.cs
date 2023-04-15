using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float durationOfExplosion = 1f;
    [SerializeField] GameObject explosionVFX;

    public bool IsCollide = false;

    public int points = 10;

    void Update()
    {
        IfDead();
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
        if (IsCollide == true)
        {
            Score.instance.AddPoint(points);
            GameObject explosion = Instantiate(explosionVFX, transform.position, transform.rotation);
            Destroy(explosion, durationOfExplosion);
            Destroy(gameObject);
        }
    }
}
