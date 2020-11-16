using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour//Singleton<GameController>
{
    public Enums.GameState gameState = Enums.GameState.PLAYER_TURN;

    public Enums.Role characterTurn = Enums.Role.MESSENGER;

    [Range(1, 4)]
    [Tooltip("How many players will join")]
    public int playerCount = 4;

    [SerializeField]
    public List<GameObject> characters;

    private void Start()
    {
        RandomizeListT.Instance.GenerateBoard(RandomizeListT.Instance.currentLayout);
    }

    

    //Returns four random heroes to play.
    private void SelectRandomCharacter()
    {
        //List<CharacterT> tempList;
    }

    //Which Character's turn is now
    public void PlayersTurn(Enums.Role playerRole)
    {

    }

    //Sets the number of players
    public void SetNumberOfPlayers(int newPlayerCount)
    {
        playerCount = newPlayerCount;
    }
}
