using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;

public class PlayServices : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
        signin();
    }

    void signin()
    {
        Social.localUser.Authenticate(success => { });
    }

    #region Achievments
    public void unlockAchievement(string id)
    {
        Social.ReportProgress(id, 100, success => { });
    }

    public void incrementachievement(string id,int stepstoinc)
    {
        PlayGamesPlatform.Instance.IncrementAchievement(id, stepstoinc, success => { });
    }

    public void showachievements()
    {
        Social.ShowAchievementsUI();
    }
    #endregion /Achievements


    #region Leaderboard
    public void AddScoreToLeaderboard(string leaderboard,long score)
    {
        Social.ReportScore(score, leaderboard, success => { });
    }
    public void showleaderboard()
    {
        Social.ShowLeaderboardUI();
    }
    #endregion /Leaderboard
}
