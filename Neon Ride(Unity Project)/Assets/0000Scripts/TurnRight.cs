/*
 * Turn Right
 * NEON RIDE
 * 
 * By: Szymon Kokot
 * Last modification: 07/04/21
 * 
 * "Turn", more precisely rotate the tunel to Right
 */
using UnityEngine;
using UnityEngine.EventSystems;

public class TurnRight : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
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
        if (Input.GetKey(KeyCode.D))
        {
            tunel.transform.Rotate(-rotSpeed, 0, 0, Space.World);
        }

        if (isPressed)
            tunel.transform.Rotate(-rotSpeed, 0, 0, Space.World);
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
