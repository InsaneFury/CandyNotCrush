using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model
{
    public int[] fills;
    public Node[,] board;

    public List<NodePiece> update;
    public List<FlippedPieces> flipped;
    public List<NodePiece> dead;
    public List<KilledPiece> killed;
}
