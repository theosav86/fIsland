

public class IEnums
{
    public enum GameState { PLAYER_TURN, ISLAND_TURN };

    public GameState gameState { get; set; }

    public enum Role { PILOT, ENGINEER, EXPLORER, NAVIGATOR, MESSENGER, DIVER }

    public Role characterRole { get; set; }

}
