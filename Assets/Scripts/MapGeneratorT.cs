using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneratorT : MonoBehaviour
{
    public enum LayoutNames { CROSS }

    public LayoutNames currentLayout = LayoutNames.CROSS;

    [Header("Terrain Tiles")]
    [Tooltip("Insert the tile prefabs here")]
    [SerializeField]
    public List<GameObject> tiles;

    [Header("Terrain Layouts")]
    [Tooltip("Various Terrain Layouts")]
    public Transform[] crossLayout;

    // Start is called before the first frame update
    void Start()
    {
        List<GameObject> randomBoard = new List<GameObject>(RandomizeBoard(tiles));

        Debug.Log(randomBoard.Count);

        if (currentLayout == LayoutNames.CROSS)
        {
            for (int i = 0; i < crossLayout.Length; i++)
            {
                Instantiate(randomBoard[i], crossLayout[i].position, Quaternion.identity);
            }            
            
            Debug.Log("Cross Layout Set Up");
        }        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Takes a List<GameObject> and returns it with randomized elements
    private List<GameObject> RandomizeBoard(List<GameObject> tileList)
    {
        //Create a temporary list so we do not mess the original one
        List<GameObject> tempTileList = new List<GameObject>(tileList);

        //This is the List to return
        List<GameObject> outputList = new List<GameObject>();

        //While tempList has elements in it
        while(tempTileList.Count > 0)
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
    
}
