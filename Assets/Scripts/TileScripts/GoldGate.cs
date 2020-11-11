using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldGate : TileT
{

    public void Start()
    {
        FlipTile(true);
    }

    private void Update()
    {
    }

    public override void DetectNeighbours()
    {
    }
}
