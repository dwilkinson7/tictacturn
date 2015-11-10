﻿using UnityEngine;
using System.Collections;

public class RightClick : MonoBehaviour
{

    private Camera mainCam;
    // Use this for initialization
    public void OnClick()
    {
        mainCam = FindObjectOfType<Camera>();

        if (mainCam.GetComponent<GameScript>().state.Equals("stand"))
            mainCam.GetComponent<GameScript>().state = "right";
    }
}
