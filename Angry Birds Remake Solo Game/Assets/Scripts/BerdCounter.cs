using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BerdCounter : MonoBehaviour
{
    TextMeshProUGUI birdCounterText;
    Slingshot slingShotScript;
    // Start is called before the first frame update
    void Start()
    {
        birdCounterText = GetComponent<TextMeshProUGUI>();
        slingShotScript = FindObjectOfType<Slingshot>();
    }

    // Update is called once per frame
    void Update()
    {
        birdCounterText.text = slingShotScript.GetBirds().ToString();
    }
}
