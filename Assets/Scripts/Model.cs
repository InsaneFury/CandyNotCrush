using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model
{
    public int [,] grid;

    public void SetGrid(int [,] _grid)
    {
        grid = _grid;
    }

    public int[,] GetGrid()
    {
        return grid;
    }

    
}
