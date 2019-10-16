using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    //Array for all back and foregrounds to be parallaxed
    public Transform[] backgrounds;
    //Camera movement ratio
    private float[] parallaxRatio;
    //Controls how smooth paralax will be. Must be above 0
    public float parallaxValue = 1f;

    //Reference to camera
    private Transform playerCamera;
    //Stores previous camera position
    private Vector3 previousCamPos;

    void Awake ()
    {
        //Set camera referece
        playerCamera = Camera.main.transform;
    }


    // Start is called before the first frame update
    void Start()
    {
        //Get previosu camera position
        previousCamPos = playerCamera.position;

        //Loop through all backgrounds we want to shift
        parallaxRatio = new float[backgrounds.Length];
        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxRatio[i] = backgrounds[i].position.z * -1;
        }
         
    }

    // Update is called once per frame
    void Update()
    {
        //Loop through backgrounds
        for (int i = 0; i < backgrounds.Length; i++)
        {
            //Calculate and set offset
            float parallax = (previousCamPos.x - playerCamera.position.x) * parallaxRatio[i];
            float backgroundTargetPosition = backgrounds[i].position.x + parallax;

            //Create target position
            Vector3 backgroundNewPosition = new Vector3(backgroundTargetPosition, backgrounds[i].position.y, backgrounds[i].position.z);

            //Fade between current and new position
            backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundNewPosition, parallaxValue * Time.deltaTime);
        }

        //Set previousCamPos
        previousCamPos = playerCamera.position;
        
    }
}
