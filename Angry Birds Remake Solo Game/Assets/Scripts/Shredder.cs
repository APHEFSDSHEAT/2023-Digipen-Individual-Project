using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    [SerializeField] float durationOfExplosion = 1f;
    [SerializeField] GameObject explosionVFX;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        GameObject explosion = Instantiate(explosionVFX, transform.position, transform.rotation);
        Destroy(explosion, durationOfExplosion);
    }
}
