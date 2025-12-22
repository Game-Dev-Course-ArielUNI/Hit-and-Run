using UnityEngine;
using UnityEngine.UI;

public enum OpeningState { Intro, ThrowTutorial, RunTutorial, Win }

public class GameFlowManager : MonoBehaviour
{
    public static GameFlowManager Instance;

    [Header("State")]
    [SerializeField] private OpeningState state = OpeningState.Intro;

    [Header("UI Panels")]
    public GameObject introPanel;
    public GameObject throwHintPanel;
    public GameObject runHintPanel;
    public GameObject winPanel;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        SetState(OpeningState.Intro);
    }

    public void SetState(OpeningState newState)
    {
        state = newState;

        // Turn all panels off
        if (introPanel) introPanel.SetActive(false);
        if (throwHintPanel) throwHintPanel.SetActive(false);
        if (runHintPanel) runHintPanel.SetActive(false);
        if (winPanel) winPanel.SetActive(false);

        switch (state)
        {
            case OpeningState.Intro:
                if (introPanel) introPanel.SetActive(true);
                break;

            case OpeningState.ThrowTutorial:
                if (throwHintPanel) throwHintPanel.SetActive(true);
                break;

            case OpeningState.RunTutorial:
                if (runHintPanel) runHintPanel.SetActive(true);
                break;

            case OpeningState.Win:
                if (winPanel) winPanel.SetActive(true);
                break;
        }
    }

    // Called by UI button
    public void OnIntroContinue()
    {
        SetState(OpeningState.ThrowTutorial);
    }

    // Called by ThrowTutorial logic when first throw is done
    public void OnThrowTutorialFinished()
    {
        SetState(OpeningState.RunTutorial);
    }

    // Called by FinishLine trigger
    public void OnRunFinished()
    {
        SetState(OpeningState.Win);
    }

    public OpeningState GetState()
    {
        return state;
    }
}
