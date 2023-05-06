using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    [Header("Slingshot Things")] 
    public LineRenderer[] lineRenderers;
    public Transform[] stripPositions;
    public Transform centre;
    public Transform idlePosition;

    public Vector3 currentPosition;

    public float maxLength;
    public float bottomBoundary;
    public float force;

    public bool isMouseDown; //originally private

    [Header("Bird")]
    public float birdPositionOffset;

    public GameObject birdPrefab;

    Rigidbody2D bird;
    Collider2D birdCollider;

    [Header("My Additions")]
    [SerializeField] public int maxBirds = 5;
    [SerializeField] float delayInSeconds = 4f;
    [SerializeField] float delayInSeconds2 = 1.4f;


    [SerializeField] Vector3 explosionPosition;
    [SerializeField] Vector3 explosionPosition2;

    [SerializeField] GameObject explosionNDeathVFX;
    float durationOfExplosion = 1.5f;
    [SerializeField] public GameObject sparkle;
    [SerializeField] Vector3 sparklePosition;

    bool allowedToShoot = true;
    /*[Header("sound")]
    [SerializeField] AudioClip launchSFX;
    [SerializeField][Range(0, 1)] float launchSFXVolume = 0.75f;
    */

    [Header("sound")]
    [SerializeField] AudioClip launchSFX;
    [SerializeField] AudioClip explosionSFX;

    void Start()
    {
        lineRenderers[0].positionCount = 2;
        lineRenderers[1].positionCount = 2;
        lineRenderers[0].SetPosition(0, stripPositions[0].position);
        lineRenderers[1].SetPosition(0, stripPositions[1].position);

        CreateBird();
    }
    
    void CreateBird()
    {
        bird = Instantiate(birdPrefab).GetComponent<Rigidbody2D>();
        birdCollider = bird.GetComponent<Collider2D>();
        birdCollider.enabled = false;

        bird.isKinematic = true;

        ResetStrips();
        
    }

    
    
    void Update()
    {
        if (isMouseDown)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10;

            currentPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            currentPosition = centre.position + Vector3.ClampMagnitude(currentPosition
                - centre.position, maxLength);

            currentPosition = ClampBoundary(currentPosition);

            SetStrips(currentPosition);

            if (birdCollider)
            {
                birdCollider.enabled = true;
            }
        }
        else
        {
            ResetStrips();
        }
    }

    private void OnMouseDown() 
    {
        isMouseDown = true; 
    }

    private void OnMouseUp()
    {
        isMouseDown = false;
        if(allowedToShoot == true)
        {
            Shoot();
        }
        
        WhenThereAreNoMoreBirds();
    }

    void Shoot()
    {
        AudioManagerSlingshot.instance.PlayClip(launchSFX);
        bird.isKinematic = false;
        Vector3 birdForce = (currentPosition - centre.position) * force * -1;
        bird.velocity = birdForce;
        FindObjectOfType<ObjectCounter>().HasLaunched();

        bird = null;
        birdCollider = null;
        Invoke("CreateBird", 2 );

        maxBirds--;

        //AudioSource.PlayClipAtPoint(launchSFX, Camera.main.transform.position, launchSFXVolume);

        if (birdCollider)
        {
            birdCollider.enabled = true; 
        }
    }

    void ResetStrips()
    {
        currentPosition = idlePosition.position;
        SetStrips(currentPosition);
    }

    void SetStrips(Vector3 position)
    {
        lineRenderers[0].SetPosition(1, position);
        lineRenderers[1].SetPosition(1, position);

        if (bird)
        {



           Vector3 dir = position - centre.position;
           bird.transform.position = position + dir.normalized * birdPositionOffset;
           bird.transform.right = -dir.normalized;
        }
    }

    Vector3 ClampBoundary(Vector3 vector)
    {
        vector.y = Mathf.Clamp(vector.y, bottomBoundary, 1000);
        return vector;
    }

    public int GetBirds()
    {
        return maxBirds;
    }
    public void WhenThereAreNoMoreBirds()
    {
        if (maxBirds <= 0 && FindObjectOfType<Level>().numberOfEnemies > 0)
        {
            StartCoroutine(WaitJustASec());
        }
        
    }

    private IEnumerator WaitJustASec()
    {
        allowedToShoot = false;
        yield return new WaitForSeconds(delayInSeconds);
        AudioManagerSlingshot.instance.PlayClip(explosionSFX);
        GameObject explosion = Instantiate(explosionNDeathVFX, transform.position, transform.rotation);
        GameObject explosion2 = Instantiate(explosionNDeathVFX, explosionPosition, transform.rotation);
        GameObject explosion3 = Instantiate(explosionNDeathVFX, explosionPosition2, transform.rotation);
        Destroy(explosion, durationOfExplosion);
        Destroy(explosion2, durationOfExplosion);
        Destroy(explosion3, durationOfExplosion);
        yield return new WaitForSeconds(delayInSeconds2);
        FindObjectOfType<SceneLoader>().LoadGameOver();
    }

}
