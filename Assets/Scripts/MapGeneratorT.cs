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
        if(currentLayout == LayoutNames.CROSS)
        {
            for(int i = 0; i < crossLayout.Length; i++)
            {
                int tileToSpawn = Random.Range(0, tiles.Count);

                if(tiles[tileToSpawn] != null)
                {
                    Instantiate(tiles[tileToSpawn], crossLayout[i].position, Quaternion.identity);
                    tiles.RemoveAt(tileToSpawn);
                }
                else
                {
                    i -= 1;
                }
                
            }

            Debug.Log("Cross Layout Set Up");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
