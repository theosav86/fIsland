using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterT : MonoBehaviour
{
    #region VARIABLES

    public Camera characterCamera;

    public Enums.Role activeRole;

    public Color playerColor;

    public int totalActions = 3;

    //public bool canMoveDiagonal = false;

    public int movementRange = 1;

    public GameObject startingTile;


    #endregion

    public virtual void Start()
    {
        characterCamera = GetComponent<Camera>();
    }
}
