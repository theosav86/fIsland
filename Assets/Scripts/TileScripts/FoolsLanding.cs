using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoolsLanding : TileT
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        //FlipTile(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void DetectNeighbours()
    {
    }

    public override void OnMouseOver()
    {
        base.OnMouseOver();
    }
}
