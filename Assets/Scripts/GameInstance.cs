public class GameInstance : Singleton<GameInstance>
{
    protected GameInstance () { }

    public Player MainPlayer;

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
        // Every time the game starts up, we init a new player since we aren't saving anything.
        MainPlayer.InitializePlayer();
    }
}
