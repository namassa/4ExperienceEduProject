using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// knotidm@gmail.com dsiemienik@gmail.com
// 05.07.17
// moving monster into direction

public class MoveCommand : Monster, ICommand
{
    public Monster monster;
    public void ExecuteCommand()
    {
        monster.MoveTo(direction, collision);
    }
}
