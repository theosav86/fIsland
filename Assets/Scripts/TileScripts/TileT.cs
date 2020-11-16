using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileT : MonoBehaviour
{
    #region VARIABLES

    public string tileName;

    //public GameObject characterStart;

    public Material[] validationMaterials;

    [HideInInspector]
    public Renderer tileRenderer;

    public bool isValid;

    public bool isFlooded;

    public bool isLost;

    public List<TileT> neighboursAdj;

    public List<TileT> neighboursDiag;

    public Vector3 floodRotation = new Vector3(0f, 0f, -180f);

    public Vector3 shoreUpRotation = new Vector3(0f, 0f, 0f);

    public Vector3 floodPosition = new Vector3(0f, -0.5f, 0f);

    public Vector3 abyssPosition = new Vector3(0f, -10f, 0f);

    #endregion

    public virtual void Start()
    {
        tileRenderer = GetComponent<Renderer>();

        /*if(characterStart != null)
        {
            Debug.Log("Spawning player");
            Instantiate(characterStart, transform.position, Quaternion.identity);
        }*/
    }

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

    public virtual void OnMouseOver()
    {
        if(isValid)
        {
            //tileRenderer.material = validationMaterials[0];
        }
        else
        {
            //tileRenderer.material = validationMaterials[1];
        }
    }

    public virtual void OnMouseUp()
    {
        //tell the game controller to move the proper character to this tile.
    }
}
