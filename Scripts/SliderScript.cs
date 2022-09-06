using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public Slider slider;
    public GameObject hitImg; // Image to display when we hit the hitzoom
    public GameObject missImg; // Image to display when we miss the hit zoom
    public float speed = 0.5f; // Speed of the handle
    public Transform hitZoom; // Determine the position of the hit zoom
    public bool isFinished; // Global bool to tell whether the event has finished

    private bool isForward; // Used for judging which side the handle goes
    private float minHit; // Min value of hit zoom
    private float maxHit; // Max value of hit zoom
    private bool stopMoving; // Stop the handle movement
    
 
    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    // Reset all vars for next event
    public void Reset()
    {
        slider.value = 0;
        isForward = true;
        isFinished = false;
        stopMoving = false;
        hitImg.SetActive(false);
        missImg.SetActive(false);
        float randomPosX = Random.Range(0, 480f); // 480 is the width of the slider
        minHit = randomPosX >= 60 ? ((randomPosX - 60f) / 480) : (randomPosX / 480);
        maxHit = randomPosX <= 292 ? ((randomPosX + 60f) / 480) : (randomPosX / 480);
        hitZoom.localPosition = new Vector2(randomPosX - 240f, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Slider Moving Part
        if (isForward && !stopMoving)
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
        else if(!stopMoving)
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

        // Hit Pending Part
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Min: " + minHit + "/n Max: " + maxHit);
            stopMoving = true;

            if (slider.normalizedValue >= minHit && slider.normalizedValue <= maxHit)
            {
                Debug.Log("Hit!");
                hitImg.SetActive(true);
            }
            else
            {
                Debug.Log("Missed!");
                missImg.SetActive(true);
            }
            StartCoroutine(CountDown(3));
        }

    }

    // Coroutine for displaying hit/miss image
    private IEnumerator CountDown(int duration)
    {
        yield return new WaitForSeconds(duration);
        isFinished = true;
    }
    
}
