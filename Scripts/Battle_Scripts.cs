using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle_Scripts : MonoBehaviour
{
    public GameObject battleUI;

    public SliderScript sliderSC;
    
    // Start is called before the first frame update
    void Start()
    {
        battleUI.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (sliderSC.isFinished)
        {
            battleUI.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        battleUI.SetActive(true);
        sliderSC.Reset();
        Debug.Log("Hit");
    }
}
