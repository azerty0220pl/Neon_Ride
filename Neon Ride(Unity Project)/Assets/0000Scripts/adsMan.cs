using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class adsMan : MonoBehaviour
{
    private void Start()
    {
        Advertisement.Initialize("4066191", true);

        if (PlayerPrefs.GetInt("premium") == 0)
        {
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
        if (Advertisement.IsReady("video"))
            Advertisement.Show("video");
    }
}
