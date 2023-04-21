using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] int numberOfEnemies;
    [SerializeField] int breakableBlocks;
    [SerializeField] float delayInSeconds = 3.5f;

    public void CountBreakableBlocks()
    {
        breakableBlocks = breakableBlocks + 1;
        // Two Shortcuts of code for the above
        //breakableBlocks += 1;
        //breakableBlocks++;
    }
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

    private IEnumerator WaitAndLoad() // MAKE THIS HAPPEN WHEN ENEMY ARE GONE NOT BLOCKS
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
}
