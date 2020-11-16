using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour//Singleton<GameController>
{
    public Enums.GameState gameState = Enums.GameState.PLAYER_TURN;

    public Enums.Role characterTurn = Enums.Role.MESSENGER;

    [Range(1, 6)]
    [Tooltip("How many players will join")]
    public int playerCount = 6;

    [SerializeField]
    public List<CharacterT> characters;

    private void Start()
    { 

        RandomizeListT.Instance.GenerateBoard(RandomizeListT.Instance.currentLayout);

        SpawnCharacters();

    }


    private void SpawnCharacters()
    {
        for(int i = 0; i < RandomizeListT.Instance.tiles.Count; i++)
        {
            for(int j = 0; j < characters.Count; j++)
            {
                if (RandomizeListT.Instance.tiles[i].tileName == characters[j].startingTile)
                {
                   // CharacterT characterToSpawn = Instantiate(characters[j], RandomizeListT.Instance.tiles[i].transform.position, Quaternion.identity);
                   // characterToSpawn.characterCamera.enabled = false;
                   // characters.RemoveAt(j);
                }
            }       

        }

        characters[Random.Range(0, characters.Count)].characterCamera.enabled = true;
    }
    

    //Returns four random heroes to play.
    private void SelectRandomCharacter()
    {
       //characters
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
