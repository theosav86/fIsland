

public class Enums
{
    public enum GameState { PLAYER_TURN, ISLAND_TURN };

    //public GameState gameState { get; set; }

    public enum Role { PILOT, ENGINEER, EXPLORER, NAVIGATOR, MESSENGER, DIVER, NONE }

    //public Role characterRole { get; set; }

    public enum LayoutName { CROSS }

    //public LayoutName layoutName { get; set; }

    public enum Tiles { GOLD_GATE, BRONZE_GATE, SILVER_GATE, IRON_GATE, COPPER_GATE, FOOLS_LANDING,
                        TIDAL_PALACE, CORAL_PALACE, CAVE_OF_EMBER, CAVE_OF_SHADOWS, TEMPLE_OF_THE_MOON, TEMPLE_OF_THE_SUN, HOWLING_GARDEN, WHISPERING_GARDEN,
                        MISTY_MARSH, OBSERVATORY, CRIMSON_FOREST, BREAKERS_BRIDGE, TWILIGHT_HOLLOW, DUNES_OF_DECEPTION, LOST_LAGOON, PHANTOM_ROCK, WATCHTOWER, CLIFFS_OF_ABANDON, RANDOM_TILE }
}