using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileT : MonoBehaviour
{
    #region VARIABLES

    public string tileName;

    public Character characterStart;

    public Vector3 floodRotation = new Vector3(0f, 0f, -180f);

    public Vector3 shoreUpRotation = new Vector3(0f, 0f, 0f);

    public Vector3 floodPosition = new Vector3(0f, -0.5f, 0f);

    public Vector3 abyssPosition = new Vector3(0f, -10f, 0f);

    public bool isFlooding;

    public List<TileT> neighboursAdj;
    public List<TileT> neighboursDiag;

    #endregion

    public void FlipTile(bool isFlooding)
    {
        if(isFlooding)
        {
            transform.localPosition -= floodPosition;
            transform.localRotation = Quaternion.Euler(floodRotation);
        }
        else
        {
            transform.rotation = Quaternion.Euler(shoreUpRotation);
        }
    }

    public void Abyss()
    {
        Debug.Log("Tile " + tileName + "is gone forever!");

        transform.position = abyssPosition;

        Destroy(gameObject);
    }    

    public virtual void DetectNeighbours()
    {
        
    }

}
