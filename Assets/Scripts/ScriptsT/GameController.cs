using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour//Singleton<GameController>
{
    public Enums.GameState gameState = Enums.GameState.PLAYER_TURN;

    public Enums.Role characterTurn = Enums.Role.MESSENGER;

    public Enums.LayoutName currentLayout = Enums.LayoutName.CROSS;

    [Header("Terrain Tiles")]
    [Tooltip("Insert the tile prefabs here")]
    [SerializeField]
    public List<GameObject> tiles;

    [Header("Terrain Layouts")]
    [Tooltip("Various Terrain Layouts")]
    public Transform[] crossLayout;

    private List<GameObject> randomBoard;

    private List<TileT> playBoard;

    private List<CharacterT> playCharacters;

    private CharacterT startingCharacter;

    [Range(1, 6)]
    [Tooltip("How many players will join")]
    public int playerCount = 6;

    [SerializeField]
    public List<CharacterT> characters;

    private void Start()
    {
        playCharacters = new List<CharacterT>();

        randomBoard = new List<GameObject>(ShuffleList(tiles));
        
        playBoard = new List<TileT>(GenerateBoard(currentLayout));

        SpawnCharacters();

    }


    private void SpawnCharacters()
    {
        for (int j = 0; j < characters.Count; j++)
        {
            TileT tileToSpawnChar = GetTileByName(characters[j].startingTile);
            CharacterT characterToSpawn = Instantiate(characters[j], tileToSpawnChar.currentPosition, Quaternion.identity);
            //characterToSpawn.characterCamera.enabled = false;
            playCharacters.Add(characterToSpawn);


        }
        //by kmell[
        //}
        //]bykmell
        int playCharacterIndex = Random.Range(0, characters.Count);
        playCharacters[playCharacterIndex].characterCamera.enabled = true;
        startingCharacter = playCharacters[playCharacterIndex];
    }
    

    //Returns four random heroes to play.
    private void SelectRandomCharacter()
    {
       //allCharacters
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


    #region GAME SETUP FUNCTIONS

    //Takes a List<GameObject> and returns it with randomized elements
    public static List<T> ShuffleList<T>(List<T> inputList)
    {
        //Create a temporary list so we do not mess the original one
        List<T> tempTileList = new List<T>(inputList);

        //This is the List to return
        List<T> outputList = new List<T>();

        //While tempList has elements in it
        while (tempTileList.Count > 0)
        {
            //Select a random number between 0 and tempList size (size being reduced each iteration due to RemoveAt(index);)
            int index = Random.Range(0, tempTileList.Count);

            //Add the random element to the output list
            outputList.Add(tempTileList[index]);

            //remove that element from the tempList
            tempTileList.RemoveAt(index);
        }

        //Return the randomized list
        return outputList;
    }


    public List<TileT> GenerateBoard(Enums.LayoutName layoutToPlay)
    {
        List<TileT> tempList = new List<TileT>();

        if (layoutToPlay == Enums.LayoutName.CROSS)
        {
            for (int i = 0; i < crossLayout.Length; i++)
            {  
                Instantiate(randomBoard[i], crossLayout[i].position, Quaternion.identity);
                //by kmell{
                randomBoard[i].GetComponent<TileT>().currentPosition = crossLayout[i].position;
                //}
                tempList.Add(randomBoard[i].GetComponent<TileT>());
            }

            Debug.Log("Cross Layout Set Up");
        }

        return tempList;
    }

    //by kmell[
    //Returns the tile with the desired Name
    public TileT GetTileByName(Enums.Tiles nameToFind)
    {
        foreach (TileT checkTile in playBoard)
        {
            if (checkTile.tileName == nameToFind)
                return checkTile;
        }

        return null;
    }
    //]
    #endregion
}
