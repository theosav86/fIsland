using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoolsLanding : TileT
{
    // Start is called before the first frame update
    public override void Start()
    {
        //DetectNeighbours();

        FlipTile(true);
    }

    // Update is called once per frame
    void Update()
    {
        
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
