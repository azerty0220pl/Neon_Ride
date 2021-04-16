/*
 * Ads Manager
 * NEON RIDE
 * 
 * By: Szymon Kokot
 * Last Modification: 08/04/21
 * 
 * Banner ad always showing, show skipable ad
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class adsMan : MonoBehaviour
{
    private void Start()
    {
        if (PlayerPrefs.GetInt("premium") == 0)
        {
            Advertisement.Initialize("4066191", false);
            StartCoroutine(ShowBannerWhenReady());
        }
    }

    IEnumerator ShowBannerWhenReady()
    {
        while (!Advertisement.IsReady("banner"))
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show("banner");
    }

    public void showAd()
    {
        if (Advertisement.IsReady("video") && PlayerPrefs.GetInt("premium") == 0)
            Advertisement.Show("video");
    }
}
