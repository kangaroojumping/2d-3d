using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : Tile
{

    public override void Start()
    {
        base.Start();
        color = Color.green; //doesnt update properly, need to fix - for now hardoding default as green
    }


    void Update()
    {
        
    }
}
