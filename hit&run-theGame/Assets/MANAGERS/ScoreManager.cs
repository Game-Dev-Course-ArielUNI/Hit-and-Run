using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int teamA = 0;
    public int teamB = 0;

    public void AddPointsToThrowingTeam(int points)
    {
        if (GameManager.Instance.turnManager.isTeamATurn)
            teamA += points;
        else
            teamB += points;

        Debug.Log("Throwing team + " + points);
    }

    public void AddPointsToEnemyTeam(int points)
    {
        if (GameManager.Instance.turnManager.isTeamATurn)
            teamB += points;
        else
            teamA += points;

        Debug.Log("Enemy team stole " + points);
    }
}
