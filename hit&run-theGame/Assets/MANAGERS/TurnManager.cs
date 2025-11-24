using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public int currentPlayerIndex = 0;
    public int playersPerTeam = 3;

    public bool isTeamATurn = true;

    public void PrepareNextPlayer()
    {
        Debug.Log($"TURN: {(isTeamATurn ? "TEAM A" : "TEAM B")} Player {currentPlayerIndex + 1}");
    }

    public void AdvanceTurn()
    {
        currentPlayerIndex++;

        if (currentPlayerIndex >= playersPerTeam)
        {
            currentPlayerIndex = 0;
            isTeamATurn = !isTeamATurn;
        }
    }
}
