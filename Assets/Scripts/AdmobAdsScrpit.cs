using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdmobAdsScrpit : MonoBehaviour
{

    private BannerView adBanner;
    private static InterstitialAd adFullScreen;
    private static string idApp, idBanner,idFullScreen;

    // Start is called before the first frame update
    void Start()
    {
        idApp = "";//"ca-app-pub-3940256099942544~3347511713";
        idBanner = "";//"ca-app-pub-3940256099942544/6300978111";
        idFullScreen = "";//"ca-app-pub-3940256099942544/1033173712";

        MobileAds.Initialize(idApp);
        RequestBannerAd();
        //RequestFullScreenAD();
    }

    public void RequestBannerAd() {
        adBanner = new BannerView(idBanner,AdSize.Banner,AdPosition.Bottom);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.adBanner.LoadAd(request);
    }

    public static void RequestFullScreenAD() {
        adFullScreen = new InterstitialAd(idFullScreen);

        AdRequest request = new AdRequest.Builder().Build();

        adFullScreen.LoadAd(request);

        if (adFullScreen.IsLoaded()) {
            adFullScreen.Show();
        }
    }
}
