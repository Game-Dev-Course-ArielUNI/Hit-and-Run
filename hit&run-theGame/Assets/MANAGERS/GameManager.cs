using UnityEngine;

public enum GamePhase { Throw, PileBreak, Run, RoundEnd }

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("References")]
    public PlayerState playerState;
    public TurnManager turnManager;
    public ScoreManager scoreManager;
    public PileController pileController;

    public GamePhase phase;

    public int pendingRoundScore = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartTurn();
    }

    public void StartTurn()
    {
        pendingRoundScore = 0;
        phase = GamePhase.Throw;

        turnManager.PrepareNextPlayer();
        playerState.SetState(PlayerStateEnum.Throwing);
    }

    public void OnPlayerThrowFinished()
    {
        phase = GamePhase.PileBreak;
    }

    public void OnPileHit(int fallen)
    {
        pendingRoundScore = fallen;
        phase = GamePhase.Run;

        playerState.SetState(PlayerStateEnum.Running);
        Debug.Log("OnPileHit called, phase = " + phase);
    }

    public void OnPlayerReachedFinishLine()
    {
        scoreManager.AddPointsToThrowingTeam(pendingRoundScore);

        // Stop movement ONLY HERE
        playerState.SetState(PlayerStateEnum.Finished);

        // Optionally stop time if you want to freeze everything
        Time.timeScale = 0f;

        Debug.Log("Player reached the finish line — GAME STOPPED.");
    }

    public void OnEnemyBallHitPlayer()
    {
        scoreManager.AddPointsToEnemyTeam(pendingRoundScore);
        EndRound();
    }

    private void EndRound()
    {
        phase = GamePhase.RoundEnd;
        turnManager.AdvanceTurn();
        StartTurn();
    }
}
