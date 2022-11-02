using System;
using System.Collections;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private Action onLeaveScreen;
    private int width;
    private Vector3 TargetPosition;

    private Vector3 NonRoundedCurrentPosition;
    private float speed;
    private bool start = false;
    public Tile PrevTile;

    public void Initialise(Action onLeaveScreen, int width, float speed, Tile prevTile) {
        this.onLeaveScreen = onLeaveScreen;
        this.width = width;
        this.speed = speed;
        TargetPosition = new Vector3(-width, transform.position.y, transform.position.z);
        NonRoundedCurrentPosition = transform.position;
        this.PrevTile = prevTile;
    }

    public void Reset()
    {
        NonRoundedCurrentPosition = transform.position;
    }


    public void Start()
    {
        start = true;
    }

    public float PrevTileRightX() => PrevTile.transform.position.x + (width);

    void Update()
    {
        if (!start)
        {
            return;
        }
        if (transform.position == TargetPosition)
        {
            onLeaveScreen();
            Reset();
        }

        float step = speed * Time.deltaTime;
        NonRoundedCurrentPosition = Vector3.MoveTowards(NonRoundedCurrentPosition, TargetPosition, step);

        transform.position = new Vector3(Mathf.RoundToInt(NonRoundedCurrentPosition.x), transform.position.y, transform.position.z);

        if (PrevTile != null ){
            float newX = PrevTileRightX();

            float diffBetweenPrev = transform.position.x - newX;
            if (diffBetweenPrev >= 1 && diffBetweenPrev <= width)
            {
                // out of line so reposition
                transform.position = new Vector3(newX, transform.position.y, transform.position.z);
            }

        }
       
       
    }
}
