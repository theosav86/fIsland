using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    public IEnums.GameState gameState = IEnums.GameState.PLAYER_TURN;

    public IEnums.Role characterTurn = IEnums.Role.MESSENGER;
}
