using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterT : MonoBehaviour
{
    #region VARIABLES


    public IEnums.Role activeRole;

    public Color playerColor;

    public int totalActions = 3;

    //public bool canMoveDiagonal = false;

    public int movementRange = 1;

    public TileT startingTile;

    #endregion
}
