using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.UI;
using System;

namespace BizzyBeeGames.WordGame
{
    public class AdMobRewardAD : MonoBehaviour
    {

        private BannerView banneView;

        private RewardBasedVideoAd rewardedVideo;

        public string androidRewardedID;

        // Use this for initialization
        void Start()
        {
            MobileAds.Initialize(androidRewardedID);
            rewardedVideo = RewardBasedVideoAd.Instance;
            rewardedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
            rewardedVideo.OnAdClosed += HandleRewardBasedVideoClosed;
            RequestRewardVideo();
        }

        public void ShowRewardedVideo()
        {
            if (rewardedVideo.IsLoaded())
            {
                rewardedVideo.Show();
            }
        }

        public void RequestRewardVideo()
        {
            rewardedVideo.LoadAd(CreateNewRequest(), androidRewardedID);
        }

        public AdRequest CreateNewRequest()
        {
            return new AdRequest.Builder().Build();
        }

        private void HandleRewardBasedVideoRewarded(object sender, Reward args)
        {
            double amount = args.Amount;
            GameManager.Instance.AddHint();
        }

        public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
        {
            RequestRewardVideo();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
