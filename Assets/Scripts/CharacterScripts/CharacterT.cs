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
    private bool isActivePlayer = false;

    public int totalActions = 3;
    private int actionsLeft = 3;

    //public bool canMoveDiagonal = false;

    public int movementRange = 1;

    public TileT currentTile;

    private GameControllerK gameController;

    #endregion

    private void Start()
    {
        characterCamera = GetComponentInChildren<Camera>();
        gameController = GameControllerK.GetInstance();
    }

    public void OnCollisionEnter(Collision other)
    {
        if (isActivePlayer)
        {
            TileT tileTouched = other.gameObject.GetComponent<TileT>();
            Debug.Log("ELA TO COLLISION!!! sto " + tileTouched.tileName);
            if (tileTouched != null && tileTouched != currentTile)
            {
                Debug.Log("peos" + currentTile.tileName);
                currentTile = tileTouched;
                ActionMade(tileTouched);
            }
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
        
    }

    private void endTurn()
    {
        //TODO na pairnw to reference to gameControllerK apo tin kalsi tou gia na min einai static
        gameController.PlayerTurnEnded(this);
        actionsLeft = 3;
    }

    public void SetCurrentTile(TileT tileToSet)
    {
        currentTile = tileToSet;
        Debug.Log("currentTile: "+currentTile);
    }

    public void SetActive()
    {
        GetComponent<PlayerControllerT>().enabled = true;
        GetComponentInChildren<Camera>().enabled = true;
        GetComponentInChildren<MouseLookT>().enabled = true;
        isActivePlayer = true;
    }
    public void SetInactive()
    {
        GetComponent<PlayerControllerT>().enabled = false;
        GetComponentInChildren<Camera>().enabled = false;
        GetComponentInChildren<MouseLookT>().enabled = false;
        isActivePlayer = false;
    }
}
