using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldGate : TileT
{

    public void Start()
    {
        DetectNeighbours();
    }

    private void Update()
    {
    }

    public override void DetectNeighbours()
    {
        base.DetectNeighbours();
    }
}
