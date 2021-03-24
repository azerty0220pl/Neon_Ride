﻿/*
 * Inside Material Change
 * NEON RIDE
 * 
 * By: Szymon Kokot
 * Last Modification: 24/03/21
 * 
 * Changes Inside color
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideMaterialChanger : MonoBehaviour
{
    public Material inside;

    public void changeColor(Color color)
    {
        inside.color = color;
    }
}
