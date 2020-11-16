

public class Enums
{
    public enum GameState { PLAYER_TURN, ISLAND_TURN };

    //public GameState gameState { get; set; }

    public enum Role { PILOT, ENGINEER, EXPLORER, NAVIGATOR, MESSENGER, DIVER }

    //public Role characterRole { get; set; }

    public enum LayoutName { CROSS }

    //public LayoutName layoutName { get; set; }

    public enum Tiles { GOLD_GATE, BRONZE_GATE, SILVER_GATE, IRON_GATE, COPPER_GATE, FOOLS_LANDING, RANDOM_TILE }
}