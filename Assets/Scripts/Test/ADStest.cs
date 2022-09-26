using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class ADStest : MonoBehaviour
{
    private string _gameID = "4932455";
    private string _placementID = "Rewarded_Android";
    private bool _testMode = true;

    private void Start()
    {
        Advertisement.Initialize(_gameID, _testMode);

        StartCoroutine(ShowBannerAdsAsync());
    }

    private IEnumerator ShowBannerAdsAsync()
    {
        while (!Advertisement.IsReady(_placementID))
        {
            yield return new WaitForSeconds(0.5f);
        }

        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Load(_placementID);
        Advertisement.Banner.Show(_placementID);
    }
}
