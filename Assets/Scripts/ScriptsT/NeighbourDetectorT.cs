using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeighbourDetectorT : MonoBehaviour
{
    public bool hasNeighbour = false;

    public TileT detectedTile;

    private void OnTriggerEnter(Collider other)
    {
        TileT neighbourTile = other.GetComponentInParent<TileT>();


        if(neighbourTile != null)
        {
            hasNeighbour = true;
           // Debug.Log("I HAVE A NEIGHBOUR");

            detectedTile = neighbourTile;
        }
    }
}
