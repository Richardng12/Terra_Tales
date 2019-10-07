﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float cameraDistOffset = 10;
    private Camera mainCamera;
    public Transform player;

    // Use this for initialization
    void Start()
    {
        // Gets the component of this gameobject
        mainCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // Centers the camera to the player
        Vector3 playerInfo = player.transform.position;
        mainCamera.transform.position = new Vector3(playerInfo.x, playerInfo.y, playerInfo.z - cameraDistOffset);
    }
}
