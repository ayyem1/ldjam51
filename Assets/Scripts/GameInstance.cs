using UnityEngine.SceneManagement;

public class GameInstance : Singleton<GameInstance>
{
    protected GameInstance () { }

    public Player MainPlayer;

    public Entity SelectedEntity { get; set; }
    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
        // Every time the game starts up, we init a new player since we aren't saving anything.
        MainPlayer.InitializePlayer();
    }

    public void StartBattle(Entity selectedEntity)
    {
        SelectedEntity = selectedEntity;
        SceneManager.LoadScene("BattleScene");
    }
}
