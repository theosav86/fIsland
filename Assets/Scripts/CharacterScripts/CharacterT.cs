using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterT : MonoBehaviour
{
    #region VARIABLES

    [HideInInspector]
    public Camera characterCamera;

    public Enums.Role activeRole;

    public Enums.Tiles startingTile;

    public Color playerColor;

    public int totalActions = 3;
    private int actionsLeft = 3;

    //public bool canMoveDiagonal = false;

    public int movementRange = 1;

    public TileT currentTile;


    #endregion

    private void Start()
    {
        characterCamera = GetComponentInChildren<Camera>();
    }

    public void OnCollisionEnter(Collision other)
    {
        Debug.Log("ELA TO COLLISION!!!");
        TileT tileTouched = other.gameObject.GetComponent<TileT>();
        if (tileTouched!=null && tileTouched != currentTile)
        {
            currentTile = tileTouched;
            ActionMade(tileTouched);
            Debug.Log("peos"+currentTile.tileName);

        }
    }

    public void ActionMade(TileT source)
    {
        if (actionsLeft == 1)
        {
            endTurn();
            return;
        }
        actionsLeft--;
        Debug.Log("Action Made! Left: ");
        
    }

    private void endTurn()
    {
        GameControllerK.PlayerTurnEnded(this);
        actionsLeft = 3;
    }

    public void SetCurrentTile(TileT tileToSet)
    {
        currentTile = tileToSet;
        Debug.Log("currentTile: "+currentTile);
    }
}
