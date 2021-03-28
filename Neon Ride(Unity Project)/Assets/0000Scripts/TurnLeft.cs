﻿/*
 * Turn Left
 * NEON RIDE
 * 
 * By: Szymon Kokot
 * Last modification: 28/03/21
 * 
 * "Turn", more precisely rotate the tunel to left
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TurnLeft : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float rotSpeed;
    public GameObject tunel;
    bool isPressed;

    void OnEnable()
    {
        isPressed = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            tunel.transform.Rotate(rotSpeed * Time.deltaTime * 100, 0, 0, Space.World);
        }

        if (isPressed)
            tunel.transform.Rotate(rotSpeed * Time.deltaTime * 100, 0, 0, Space.World);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }
}
