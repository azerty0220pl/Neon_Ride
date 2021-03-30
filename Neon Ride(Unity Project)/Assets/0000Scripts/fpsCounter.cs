/*
 * FPS counter
 * NEON RIDE
 * 
 * By: Szymon Kokot
 * Last Modification: 24/03/21
 * 
 * Shows fps
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fpsCounter : MonoBehaviour
{
    public Text fpsText;
    void Update()
    {
        fpsText.text = "" + (int)(1f / Time.unscaledDeltaTime);
    }
}
