using UnityEngine;

public enum PlayerStateEnum { Idle, Throwing, Running, Finished, Hit }

public class PlayerState : MonoBehaviour
{
    public PlayerStateEnum state;

    public void SetState(PlayerStateEnum newState)
    {
        state = newState;
    }
}
