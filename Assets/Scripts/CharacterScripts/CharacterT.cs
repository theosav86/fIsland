using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterT : MonoBehaviour
{
    #region VARIABLES

    public Camera characterCamera;

    public Enums.Role activeRole;

    public Enums.Tiles startingTile;

    public Color playerColor;

    public int totalActions = 3;

    //public bool canMoveDiagonal = false;

    public int movementRange = 1;


    #endregion

    public virtual void Start()
    {
        characterCamera = GetComponent<Camera>();
    }
}
