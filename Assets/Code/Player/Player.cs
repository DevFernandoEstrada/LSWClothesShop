public class Player : BasePlayer
{
    public static Player Instance;

    public new void Awake()
    {
        base.Awake();

        Instance = this;
    }
}
