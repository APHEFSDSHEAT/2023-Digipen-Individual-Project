using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks;

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
        if (breakableBlocks <= 0)
        {
            FindObjectOfType<SceneLoader>().LoadNextScene();
        }
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
