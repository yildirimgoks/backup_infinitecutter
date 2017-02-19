using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour
{

    public GameObject Player;
    public Controller Controller;
    private float _speed;
    private Vector2 _playerVelocity;

    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                _speed = Controller.startingSpeed;
                _playerVelocity = new Vector2(0, _speed);
                Player.GetComponent<Rigidbody2D>().velocity = _playerVelocity;
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }
}