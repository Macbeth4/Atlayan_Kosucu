  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class reklam : MonoBehaviour
{
    private BannerView bannerView;
    private InterstitialAd Interstitial;
    

    void Start()
    {
        MobileAds.Initialize(InitStatus => { });
        this.RequestBanner();
        this.RequestInterstitial();
    }

    public async void reklamgosterAsync()
    {
        SceneManager.LoadScene("ins");
        await Task.Delay(100);
        this.Interstitial.Show();

    }


    void RequestBanner()
    {

        string reklamID = "ca-app-pub-3940256099942544/6300978111";

        this.bannerView = new BannerView(reklamID, AdSize.Banner, AdPosition.Bottom);
        AdRequest request = new AdRequest.Builder().Build();

        this.bannerView.LoadAd(request);
    }

    void RequestInterstitial()
    {

        string reklamID = "ca-app-pub-3940256099942544/1033173712";

        this.Interstitial = new InterstitialAd(reklamID);
        AdRequest request = new AdRequest.Builder().Build();
        this.Interstitial.LoadAd(request);
    }
}