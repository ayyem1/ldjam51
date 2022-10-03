using System;
using UnityEngine;

public class TurnSystem : MonoBehaviour
{
    public static TurnSystem Instance {get; private set;}
    public event EventHandler OnTurnChanged;
    private int turnNumber = 1;
    private bool isPlayerTurn = true;
    [SerializeField] Timer timer;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There's more than one TurnSystem! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;

        timer.OnTimerStop.RemoveListener(NextTurn);
        timer.OnTimerStop.AddListener(NextTurn);
    }

    private void OnDestroy()
    {
        timer.OnTimerStop.RemoveListener(NextTurn);
    }
    public void NextTurn()
    {
        turnNumber++;
        isPlayerTurn = !isPlayerTurn;
        timer.StopTimer();
        if (isPlayerTurn)
        {
            GameInstance.Instance.MainPlayer.ResetMana();
            GameManager.Instance.DeckController.RefreshPlayerHand();
            GameInstance.Instance.MainPlayer.ModifyDefense(-GameInstance.Instance.MainPlayer.CurrentDefense);
            timer.gameObject.SetActive(true);
            timer.SetTimer();
        }
        else
        {
            timer.gameObject.SetActive(false);
            GameInstance.Instance.MainPlayer.ResetBuffs();
        }

        OnTurnChanged?.Invoke(this, EventArgs.Empty);
    }

    public int GetTurnNumber()
    {
        return turnNumber;
    }

    public bool IsPlayerTurn()
    {
        return isPlayerTurn;
    }

}
