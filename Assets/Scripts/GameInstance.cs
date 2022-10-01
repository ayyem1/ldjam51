public class GameInstance : Singleton<GameInstance>
{
    protected GameInstance () { }

    public Player MainPlayer { get; set; }

    public void Awake()
    {
        // Every time the game starts up, we init a new player since we aren't saving anything.
        MainPlayer.InitializePlayer();
    }

}
