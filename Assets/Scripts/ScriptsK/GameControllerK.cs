using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerK : MonoBehaviour//Singleton<GameController>
{
    public Enums.GameState gameState = Enums.GameState.PLAYER_TURN;
    private bool isSwitcingPlayer = false;
    public Enums.Role characterTurn = Enums.Role.MESSENGER;

    public Enums.LayoutName currentLayout = Enums.LayoutName.CROSS;

    [Header("Terrain Tiles")]
    [Tooltip("Insert the tile prefabs here")]
    public List<TileT> allTiles;

    [Header("Terrain Layouts")]
    [Tooltip("Various Terrain Layouts")]
    public Transform[] crossLayout;

    [Header("All Characters")]
    [Tooltip("Insert Characters prefabs here")]
    public List<Transform> allPlayableCharacters_pf;

    private List<TileT> currentBoardTiles;

    public List<Transform> currentGameCharacters_pf;
    public static List<CharacterT> currentGameCharacters = new List<CharacterT>();

    private int playingCharacterIndex;

    private CharacterT currentCharacter;
    private CharacterT previousCharacter;

    [Tooltip("How many players will join")]
    public int playerCount = 6;

    private static GameControllerK instance;
    public static GameControllerK GetInstance(){
        return instance;
    }
    private void Awake()
    {
        instance = this;
    }



    private void Start()
    {
        GenerateBoard(Enums.LayoutName.CROSS);

        SpawnCharacters(playerCount);

        currentCharacter.SetActive();
    }

    private void SpawnCharacters(int numOfPlayers)
    {
        //Set List with current game's playing characters
        if (numOfPlayers == 0)
        {
            numOfPlayers = Random.Range(2, 7);
        }
        Debug.Log("numberof players: " + numOfPlayers);
        currentGameCharacters_pf = ShuffleList(allPlayableCharacters_pf).GetRange(0, numOfPlayers);

        //Get Character scripts adn instantiate
        for (int i = 0; i < currentGameCharacters_pf.Count; i++)
        {
            TileT tileToSpawnChar = GetTileByName(currentGameCharacters_pf[i].GetComponent<CharacterT>().startingTile);
            currentGameCharacters_pf[i] = Instantiate(currentGameCharacters_pf[i], tileToSpawnChar.currentPosition, Quaternion.identity);

            currentGameCharacters.Add(currentGameCharacters_pf[i].GetComponent<CharacterT>());
            currentGameCharacters[i].currentTile = tileToSpawnChar;
            currentGameCharacters[i].SetInactive();
        }


        //Begin playing with first player:
        currentCharacter = currentGameCharacters[0];
        //currentCharacter.SetActive();
        playingCharacterIndex = 0;//currentGameCharacters.IndexOf(currentCharacter);
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

    internal void  PlayerTurnEnded(CharacterT character)
    {
        //character.SetInactive();
        previousCharacter = currentCharacter;
        NextPlayer();
    }

    private void NextPlayer()
    {
        CharacterT previousCharacter = currentCharacter;

        //playingCharacterIndex = (playingCharacterIndex + 1) % playerCount;
        playingCharacterIndex++;
        if (playingCharacterIndex == playerCount)
            playingCharacterIndex = 0;
        //playingCharacterIndex %= playerCount; //So that always stays in the Lists limits. Rotates through list.
       currentCharacter = currentGameCharacters[playingCharacterIndex];
        
        /*apopeira na kanw transition tin kamera
        Vector3 previousCameraPos = previousCharacter.GetComponentInChildren<Camera>().transform.position;
        Vector3 currentCameraPos = currentCharacter.GetComponentInChildren<Camera>().transform.position;
        isSwitcingPlayer = true;

        while (isSwitcingPlayer)
        {
            previousCharacter.GetComponentInChildren<Camera>().transform.position = Vector3.Lerp(previousCameraPos, currentCameraPos, Time.deltaTime);
            if (previousCharacter.GetComponentInChildren<Camera>().transform.position == currentCameraPos)
                isSwitcingPlayer = false;
        }
        */
        previousCharacter.SetInactive();
        //previousCharacter.GetComponentInChildren<Camera>().transform.position = previousCameraPos;
        currentCharacter.SetActive();
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
        foreach (CharacterT checkChar in currentGameCharacters)
        {
            if (checkChar.activeRole== nameToFind)
                return checkChar;
        }

        return null;
    }

    #endregion
}
