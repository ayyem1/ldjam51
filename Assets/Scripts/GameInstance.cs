using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInstance : Singleton<GameInstance>
{
    protected GameInstance () { }

    public Player MainPlayer;

    public Entity SelectedEntity { get; set; }

    // Note: We don't support duplicate interactions. If we want to allow for that, we need to create UUIDs for each instance of the interaction.
    public Dictionary<string, Interactible.State> StatesPerInteraction = new Dictionary<string, Interactible.State>();

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Reset();
    }

    public void Reset()
    {
        // Add Ann to UnlockedInteractions.
        MainPlayer.InitializePlayer();
        StatesPerInteraction.Clear();
        SelectedEntity = null;
    }

    public void StartBattle(Entity selectedEntity)
    {
        SelectedEntity = selectedEntity;
        SceneManager.LoadScene("BattleScene");
    }

    public void InitializeStateInteraction(Interactible interactible)
    {
        if (!StatesPerInteraction.ContainsKey(interactible.referenceInteraction.name))
        {
            StatesPerInteraction.Add(interactible.referenceInteraction.name, Interactible.State.NotUnlocked);
        }
    }

    public void SetInteractionToUnlocked(string interactionName)
    {
        if (StatesPerInteraction.ContainsKey(interactionName) && StatesPerInteraction[interactionName] == Interactible.State.NotUnlocked)
        {
            StatesPerInteraction[interactionName] = Interactible.State.Unlocked;
        }
        else
        {
            Debug.Log("Failed to unlock interaction.");
        }
    }

    public void SetInteractionToStarted(string interactionName)
    {
        if (StatesPerInteraction.ContainsKey(interactionName) && StatesPerInteraction[interactionName] == Interactible.State.Unlocked)
        {
            StatesPerInteraction[interactionName] = Interactible.State.Started;
        }
        else
        {
            Debug.Log("Failed to start interaction.");
        }
    }

    public void SetInteractionToCompleted(string interactionName)
    {
        if (StatesPerInteraction.ContainsKey(interactionName) && StatesPerInteraction[interactionName] == Interactible.State.Started)
        {
            StatesPerInteraction[interactionName] = Interactible.State.Completed;
        }
        else
        {
            Debug.Log("Failed to complete interaction.");
        }
    }
}
