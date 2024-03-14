using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuto : MiniGame
{
    public override void StartMiniGame(int difficulty)
    {
        LevelUp();
    }

    public override void TouchedTarget(int id)
    {
        
    }
}
