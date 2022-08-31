using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public Slider slider;
    public bool isForward;
    public float speed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = 0;
        isForward = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isForward)
        {
            if (slider.value < slider.maxValue)
            {
                slider.value += speed;
            }
            else
            {
                isForward = !isForward;
            }
        }
        else
        {
            if (slider.value > slider.minValue)
            {
                slider.value -= speed;
            }
            else
            {
                isForward = !isForward;
            }
        }
    }
}
