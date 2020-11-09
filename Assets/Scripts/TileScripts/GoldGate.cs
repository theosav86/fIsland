using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldGate : TileT
{

    public override void Start()
    {
        
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            DetectNeighbours();
        }
    }

    public override void DetectNeighbours()
    {
        
        for (int i = 0; i < neighbourDetectors.Length; i++)
        {
            if (neighbourDetectors[i].detectedTile != null)
            {
                neighbours.Add(neighbourDetectors[i].detectedTile);
            }
        }
    }
}
