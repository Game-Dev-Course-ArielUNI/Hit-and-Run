hit & run


המשחק מבוסס על משחק ילדות אמיתי בו הילדים מתחלקים לשתי קבוצות ומתחרים אחד בשני. כל ילד משתי הקבוצות נעמד מול כל שחקני היריבה כאשר מולם נמצאת ערימה של חפצים,על השחקן לזרוק את הכדור לעבר הערימה ולנסות להפיל כמה שיותר ואז לרוץ לנקודת הסיום כדי להרוויח את הנקודות כאשר כל שחקני היריבה רודפים אחריו.

click here to play the game:https://yousef-masarwa97.itch.io/hitrun


<img width="1536" height="1024" alt="image" src="https://github.com/user-attachments/assets/946f85c4-2ac8-4566-a2c1-d53029c937bf" />
<img width="1536" height="1024" alt="image" src="https://github.com/user-attachments/assets/6532f4dc-d284-4213-a45a-30f7e207a6ae" />
<img width="1536" height="1024" alt="image" src="https://github.com/user-attachments/assets/ce2fc606-7cd0-4adf-9439-54bd37589169" />


לרכיבים הרשמיים לחצו כאן:
https://github.com/Game-Dev-Course-ArielUNI/Hit-and-Run/wiki#hit--run

---


```mermaid

 classDiagram
    class GameManager {
        -string state
        -int roundScore
        +StartRound()
        +StartThrow()
        +StartRun()
        +EndRound()
    }

    class TurnManager {
        -int playerIndex
        -List<Player> teamA
        -List<Player> teamB
        +NextPlayer()
        +IsGameOver()
    }

    class ScoreManager {
        -int teamA_score
        -int teamB_score
        +AddPointsToTeamA()
        +AddPointsToTeamB()
    }

    class PileController {
        -List<PileObject> pileObjects
        -int fallenCount
        +OnBallHit()
        +CountFallen()
    }

    class PlayerState {
        -string currentState
        +SetState()
        +IsRunning()
    }

    class PlayerThrow {
        +Aim()
        +ThrowBall()
    }

    class PlayerRun {
        +RunForward()
        +DetectFinishLine()
    }

    class PlayerDodge {
        +Jump()
        +MoveLeft()
        +MoveRight()
    }

    class BallPhysics {
        -float force
        +ApplyForce()
        +Reset()
    }

    class BallHitDetector {
        +OnHitPile()
        +OnHitRunner()
    }

    class EnemyTeamManager {
        -List<EnemyAI> enemies
        +SendEnemyToBall()
        +SelectThrower()
    }

    class EnemyBallPickup {
        +PickupBall()
    }

    class EnemyThrow {
        +AimAtPlayer()
        +ThrowBall()
    }

    %% RELATIONSHIPS
    GameManager --> TurnManager
    GameManager --> ScoreManager
    GameManager --> PileController
    GameManager --> PlayerState

    PlayerState --> PlayerThrow
    PlayerState --> PlayerRun
    PlayerState --> PlayerDodge

    PlayerThrow --> BallPhysics
    BallPhysics --> BallHitDetector

    BallHitDetector --> EnemyTeamManager

    EnemyTeamManager --> EnemyBallPickup
    EnemyTeamManager --> EnemyThrow

    PileController --> PileObject
```
