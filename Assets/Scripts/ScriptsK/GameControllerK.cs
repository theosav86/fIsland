using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerK : MonoBehaviour//Singleton<GameController>
{
    public Enums.GameState gameState = Enums.GameState.PLAYER_TURN;

    public Enums.Role characterTurn = Enums.Role.MESSENGER;

    public Enums.LayoutName currentLayout = Enums.LayoutName.CROSS;

    [Header("Terrain Tiles")]
    [Tooltip("Insert the tile prefabs here")]
    [SerializeField]
    public List<TileT> allTiles;

    [Header("Terrain Layouts")]
    [Tooltip("Various Terrain Layouts")]
    public Transform[] crossLayout;

    private List<TileT> currentBoardTiles;

    private static List<CharacterT> currentCharacters;
    private static int playingCharacterIndex;

    private static CharacterT currentCharacter;

    [Range(1, 6)]
    [Tooltip("How many players will join")]
    public static int playerCount = 6;

    [SerializeField]
    public List<CharacterT> allCharacters;

    

    private void Start()
    {
        LoadCharacters(playerCount);

        GenerateBoard(Enums.LayoutName.CROSS);

        SpawnCharacters();

    }

    private void LoadCharacters(int numOfPlayers)
    {
        if (numOfPlayers == 0)
        {
            numOfPlayers = Random.Range(2, allCharacters.Count);
        }
        currentCharacters = ShuffleList(allCharacters).GetRange(0, numOfPlayers);
        
    }

    private void SpawnCharacters()
    {
        for (int i=0; i<currentCharacters.Count; i++)// each (CharacterT charToSpawn in currentCharacters)
        {
            TileT tileToSpawnChar = GetTileByName(currentCharacters[i].startingTile);

            currentCharacters[i] = Instantiate(currentCharacters[i], tileToSpawnChar.currentPosition, Quaternion.identity);


            currentCharacters[i].currentTile = tileToSpawnChar;//SetCurrentTile(tileToSpawnChar);

            currentCharacters[i].GetComponent<PlayerControllerT>().enabled = false;
            currentCharacters[i].characterCamera.enabled = false;
            //charToSpawn.GetComponent<MouseLookT>().enabled = false;
        }

        currentCharacter = currentCharacters[0];
        currentCharacter.characterCamera.enabled = true;
        currentCharacter.GetComponent<PlayerControllerT>().enabled = true;
        //currentCharacter.GetComponent<MouseLookT>().enabled = true;
        playingCharacterIndex = 0;//currentCharacters.IndexOf(currentCharacter);
        /*currentCharacters[0].characterCamera.enabled = true;
        currentCharacters[0].GetComponent<PlayerControllerT>().enabled = true;
        startingCharacter = currentCharacters[0];*/
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


    public void GenerateBoard(Enums.LayoutName layoutToPlay)
    {
        currentBoardTiles = ShuffleList(allTiles);

        if (layoutToPlay == Enums.LayoutName.CROSS)
        {
            for (int i = 0; i < crossLayout.Length; i++)
            {  
                Instantiate(currentBoardTiles[i], crossLayout[i].position, Quaternion.identity);
                currentBoardTiles[i].currentPosition = crossLayout[i].position;
            }

            Debug.Log("Cross Layout Set Up");
        }
    }

    internal static void PlayerTurnEnded(CharacterT character)
    {
        character.GetComponent<Camera>().enabled = false;
        NextPlayer();
    }

    private static void NextPlayer()
    {
        //playingCharacterIndex = (playingCharacterIndex + 1) % playerCount;
        playingCharacterIndex++;
        playingCharacterIndex %= playerCount; //So that always stays in the Lists limits. Rotates through list.
        currentCharacter = currentCharacters[playingCharacterIndex];
        currentCharacter.GetComponent<Camera>().enabled = true;
    }

    public TileT GetTileByName(Enums.Tiles nameToFind)
    {
        foreach (TileT checkTile in currentBoardTiles)
        {
            if (checkTile.tileName == nameToFind)
                return checkTile;
        }

        return null;
    }

    public CharacterT GetCharByName(Enums.Role nameToFind)
    {
        foreach (CharacterT checkChar in currentCharacters)
        {
            if (checkChar.activeRole== nameToFind)
                return checkChar;
        }

        return null;
    }

    #endregion
}
