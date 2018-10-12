using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour {
    public Transform[] startingPositions;
    public GameObject[] rooms;
    int Xmove = 19;
    int Ymove = 10;

    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    private int direction;
    private bool stop;
    private float time;
    public float starttime = 0.25f;  //cd
	void Start () {
        int randstartingPos = Random.Range(0, startingPositions.Length);
        transform.position = startingPositions[randstartingPos].position;
        Instantiate(rooms[0], transform.transform.position, Quaternion.identity);

        direction = Random.Range(1, 6);

	}

    private void Update()
    {
        if (time <= 0&&!stop)
        {
            Move();
            time = starttime;
        }
        else
        {
            time -= Time.deltaTime;
        }
    }

    void Move()
    {
        if (direction == 1 || direction == 2)  // right
        {
            if (transform.position.x < maxX)
            {
                Vector2 newPos = new Vector2(transform.position.x + Xmove, transform.position.y);
                transform.position = newPos;
            }
            else
            {
                direction = 5;
            }
           
        }
    else if (direction == 3 || direction == 4) //left
        {
            if (transform.position.x < minX)
            {
                Vector2 newPos = new Vector2(transform.position.x - Xmove, transform.position.y);
                transform.position = newPos;
            }
            else
            {
                direction = 5;
            }

        }
        else if (direction == 5) //down
        {
            if (transform.position.y > minY)
            {
                Vector2 newPos = new Vector2(transform.position.x, transform.position.y - Ymove);
                transform.position = newPos;
            }
            else
            {
                stop = true;
            }
        }
        Instantiate(rooms[0], transform.position, Quaternion.identity);
        direction = Random.Range(1, 6);    }
}
