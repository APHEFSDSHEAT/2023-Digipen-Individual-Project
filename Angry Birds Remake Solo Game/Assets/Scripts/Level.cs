using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [Header("Counter")]
    [SerializeField] public int numberOfEnemies;
    [SerializeField] int breakableBlocks;

    [Header("Variables")]
    [SerializeField] float delayInSeconds = 3.5f;
    //float delayInSeconds2 = 4f;
    //float delayInSeconds3 = 1f;
    //float durationOfExplosion = 1.5f;

    //[Header("Positions")]
    //Vector3 explosionPosition;
    //Vector3 explosionPosition2;

    //[Header("GameObjects")]
    //GameObject explosionNDeathVFX;

    public void CountEnemies()
    {
        numberOfEnemies = numberOfEnemies + 1;
    }

    public void enemyDied()
    {
        numberOfEnemies--;
        if (numberOfEnemies <= 0)
        {
            LoadTheNextScene();
            //FindObjectOfType<SceneLoader>().LoadNextScene();
        }
    }

    // COUNTING BLOCKS

    public void CountBreakableBlocks()
    {
        breakableBlocks = breakableBlocks + 1;
        // Two Shortcuts of code for the above
        //breakableBlocks += 1;
        //breakableBlocks++;
    }
    public void blockDestroyed()
    {
        breakableBlocks--;
        /*if (breakableBlocks <= 0)
        {
            LoadGameOver();
            FindObjectOfType<SceneLoader>().LoadNextScene();
        }*/
    }
    public void LoadTheNextScene()
    {
        StartCoroutine(WaitAndLoad());
    }

    private IEnumerator WaitAndLoad() 
    {
        yield return new WaitForSeconds(delayInSeconds);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        //SceneManager.LoadScene(1);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*public int GetBirds()
    {
        return FindObjectOfType<Slingshot>().maxBirds;
    }
    public void WhenThereAreNoMoreBirds()
    {
        if (FindObjectOfType<Slingshot>().maxBirds <= 0 && FindObjectOfType<Level>().numberOfEnemies > 0)
        {
            StartCoroutine(WaitJustASec());
        }

    }

    private IEnumerator WaitJustASec()
    {
        yield return new WaitForSeconds(delayInSeconds2);
        GameObject explosion = Instantiate(explosionNDeathVFX, transform.position, transform.rotation);
        GameObject explosion2 = Instantiate(explosionNDeathVFX, explosionPosition, transform.rotation);
        GameObject explosion3 = Instantiate(explosionNDeathVFX, explosionPosition2, transform.rotation);
        Destroy(explosion, durationOfExplosion);
        Destroy(explosion2, durationOfExplosion);
        Destroy(explosion3, durationOfExplosion);
        yield return new WaitForSeconds(delayInSeconds3);
        FindObjectOfType<SceneLoader>().LoadGameOver();
    }*/
}
