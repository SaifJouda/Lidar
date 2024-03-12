using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideMove : MonoBehaviour
{
    public Slider uiSlider;

    public GameObject scanner;
    public GameObject wall;
    public GameObject camera;

    private void Start()
    {
        // Add a listener to the UI Slider's value change event
        uiSlider.onValueChanged.AddListener(MoveObject);
    }

    private void MoveObject(float sliderValue)
    {
        // Calculate the target position based on the slider value
        float targetX = Mathf.Lerp(-5f, 5f, sliderValue); // Adjust the range as needed

        // Calculate the new position using Lerp
        Vector3 newPosition = new Vector3(targetX, transform.position.y, transform.position.z);

        // Update the object's position
        wall.transform.position = new Vector3(10+sliderValue*100,0,0);
        camera.transform.position = new Vector3(((wall.transform.position.x-10)/2),0,-16-sliderValue*66);
    }
}
