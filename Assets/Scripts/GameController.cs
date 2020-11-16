using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour//Singleton<GameController>
{
    public IEnums.GameState gameState = IEnums.GameState.PLAYER_TURN;

    public IEnums.Role characterTurn = IEnums.Role.MESSENGER;

    [Range(1, 4)]
    [Tooltip("How many players will join")]
    public int playerCount = 4;

    [SerializeField]
    public List<GameObject> characters;

    private void Start()
    {
        MapGeneratorT.Instance.GenerateBoard(MapGeneratorT.Instance.currentLayout);

        //SelectRandomCharacter();
        //SelectRandomCharacter();
        //SelectRandomCharacter();
        //SelectRandomCharacter();
    }

    

    //Returns four random heroes to play.
    private void SelectRandomCharacter()
    {
        //List<CharacterT> tempList;
    }

    //Which Character's turn is now
    public void PlayersTurn(IEnums.Role playerRole)
    {

    }

    //Sets the number of players
    public void SetNumberOfPlayers(int newPlayerCount)
    {
        playerCount = newPlayerCount;
    }
}
