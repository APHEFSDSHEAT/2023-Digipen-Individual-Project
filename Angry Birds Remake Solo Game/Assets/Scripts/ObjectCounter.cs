using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ObjectCounter : MonoBehaviour
{
    [SerializeField] public int BirdsInGame;

    [SerializeField] float DestroyTime = 3.5f;

    bool hasLaunched = false;

    Coroutine death;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void HasLaunched()
    {
        hasLaunched = true;
    }

    // Update is called once per frame
    void Update()
    {
       CheckIfFunctionRanThenDestroy();
    }

    private void CheckIfFunctionRanThenDestroy()
   {
        if (hasLaunched == true) //if Shoot() has ran then ___
        {
            death = StartCoroutine(WaitToDestroy());
        }
        
    }

    private IEnumerator WaitToDestroy()
    {
        yield return new WaitForSeconds(DestroyTime);
        Destroy(gameObject);
    }
}
