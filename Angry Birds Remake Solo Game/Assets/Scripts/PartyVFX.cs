using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyVFX : MonoBehaviour
{
    [SerializeField] GameObject sFX;
    [SerializeField] GameObject sFX2;
    [SerializeField] GameObject sFX3;
    [SerializeField] GameObject sFX4;

    [SerializeField] Vector3 sFXPositionLeft;
    [SerializeField] Vector3 sFXPositionRight;

    [SerializeField] float delayInSeconds = 3f;
    [SerializeField] float durationOfExplosion = 5f;

    // Start is called before the first frame update
    void Start()
    {
        createWinEffect();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void createWinEffect()
    {
        StartCoroutine(waitToCreate());
    }

    private IEnumerator waitToCreate()
    {
        yield return new WaitForSeconds(delayInSeconds);
        GameObject createEffect = Instantiate(sFX, sFXPositionLeft, transform.rotation);
        GameObject createEffect2 = Instantiate(sFX, sFXPositionRight, transform.rotation);
        Destroy(createEffect, durationOfExplosion);
        Destroy(createEffect2, durationOfExplosion);

        yield return new WaitForSeconds(delayInSeconds);
        GameObject createEffect3 = Instantiate(sFX2, sFXPositionLeft, transform.rotation);
        GameObject createEffect4 = Instantiate(sFX2, sFXPositionRight, transform.rotation);
        Destroy(createEffect3, durationOfExplosion);
        Destroy(createEffect4, durationOfExplosion);

        yield return new WaitForSeconds(delayInSeconds);
        GameObject createEffect5 = Instantiate(sFX3, sFXPositionLeft, transform.rotation);
        GameObject createEffect6 = Instantiate(sFX3, sFXPositionRight, transform.rotation);
        Destroy(createEffect5, durationOfExplosion);
        Destroy(createEffect6, durationOfExplosion);

        yield return new WaitForSeconds(delayInSeconds);
        GameObject createEffect7 = Instantiate(sFX4, sFXPositionLeft, transform.rotation);
        GameObject createEffect8 = Instantiate(sFX4, sFXPositionRight, transform.rotation);
        Destroy(createEffect7, durationOfExplosion);
        Destroy(createEffect8, durationOfExplosion);


    }
}
