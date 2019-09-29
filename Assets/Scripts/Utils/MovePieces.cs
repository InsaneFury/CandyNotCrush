using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePieces : MonoBehaviour
{
    public static MovePieces instance;
    Controller game;

    NodePiece moving;
    Point newIndex;
    Vector2 mouseStart;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        game = GetComponent<Controller>();
    }

    void Update()
    {
        if(moving != null)
        {
#if UNITY_EDITOR
            Vector2 dir = ((Vector2)Input.mousePosition - mouseStart);
#endif
#if UNITY_ANDROID && !UNITY_EDITOR
            Touch touch;
            touch = Input.GetTouch(0);
            Vector2 dir = ((Vector2)touch.position - mouseStart);
#endif
            Vector2 nDir = dir.normalized;
            Vector2 aDir = new Vector2(Mathf.Abs(dir.x), Mathf.Abs(dir.y));

            newIndex = Point.Clone(moving.index);
            Point add = Point.Zero;
            if (dir.magnitude > 32) //If our mouse is 32 pixels away from the starting point of the mouse
            {
                //make add either (1, 0) | (-1, 0) | (0, 1) | (0, -1) depending on the direction of the mouse point
                if (aDir.x > aDir.y)
                    add = (new Point((nDir.x > 0) ? 1 : -1, 0));
                else if(aDir.y > aDir.x)
                    add = (new Point(0, (nDir.y > 0) ? -1 : 1));
            }
            newIndex.Add(add);

            Vector2 pos = game.getPositionFromPoint(moving.index);
            if (!newIndex.Equals(moving.index))
                pos += Point.Mult(new Point(add.x, -add.y), 16).ToVector();
            moving.MovePositionTo(pos);
        }
    }

    public void MovePiece(NodePiece piece)
    {
        if (moving != null) return;
        moving = piece;
#if UNITY_EDITOR
        mouseStart = Input.mousePosition;
#endif

#if UNITY_ANDROID && !UNITY_EDITOR
        Touch touch = Input.GetTouch(0);
        mouseStart = touch.position;
#endif
    }

    public void DropPiece()
    {
        if (moving == null) return;
        Debug.Log("Dropped");
        if (!newIndex.Equals(moving.index))
            game.FlipPieces(moving.index, newIndex, true);
        else
            game.ResetPiece(moving);
        moving = null;
    }
}
