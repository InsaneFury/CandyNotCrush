using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour
{
    int width = 0;
    int height = 0;

    Controller controller;

    private void Start()
    {
        controller = Controller.Get();
        width = controller.width;
        height = controller.height;
    }

    public void InstantiateBoard()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Node node = controller.getNodeAtPoint(new Point(x, y));

                int val = node.value;
                if (val <= 0) continue;
                GameObject p = Instantiate(controller.nodePiece, controller.gameBoard);
                NodePiece piece = p.GetComponent<NodePiece>();
                RectTransform rect = p.GetComponent<RectTransform>();
                rect.anchoredPosition = new Vector2(32 + (64 * x), -32 - (64 * y));
                piece.Initialize(val, new Point(x, y), controller.pieces[val - 1]);
                node.SetPiece(piece);
            }
        }
    }
}
