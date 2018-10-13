using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
	public Transform[] startingPositions;
	public GameObject[] rooms;
	int Xmove = 19;
	int Ymove = 10;
	public float maxX;
	public float minX;
	//public float maxY;
	public float minY;
	private int direction;
	private bool stop;
	private float time;
	public float starttime = 0.25f;  //cd


	public LayerMask _room;
	void Start()
	{
		int randstartingPos = Random.Range(0, startingPositions.Length);
		transform.position = startingPositions[randstartingPos].position;
		Instantiate(rooms[0], transform.transform.position, Quaternion.identity);

		direction = Random.Range(1, 6);

	}

	private void Update()
	{
		if (time <= 0 && !stop)
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

				int rand = Random.Range(1, rooms.Length);
				Instantiate(rooms[rand], transform.position, Quaternion.identity);


				direction = Random.Range(1, 6);
				if (direction == 3)
				{
					direction = 2;
				}
					else if (direction == 4)
			{
				direction = 5;
			}
			else {
				direction = 5;
			}
			}
		

		}
		else if (direction == 3 || direction == 4) //left
		{
			if (transform.position.x > minX)
			{
				Vector2 newPos = new Vector2(transform.position.x - Xmove, transform.position.y);
				transform.position = newPos;
				int rand = Random.Range(1, rooms.Length);
				Instantiate(rooms[rand], transform.position, Quaternion.identity);

				direction = Random.Range(3, 6);
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
			 Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, _room);　　　　//　目標のCollider２D　ComponentのSIZEのサイズを確認しなくてはならない。０．００００１の場合BUGが出る。
			 Debug.Log(roomDetection);　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　// このBugをさがすのに時間掛かっちゃた。　
				 if (roomDetection.GetComponent<WallType>().Type != 1 && roomDetection.GetComponent<WallType>().Type != 3)
				 {
				 	Debug.Log("123");
					roomDetection.GetComponent<WallType>().RoomDestruction();

					int randbottomRoom = Random.Range(1, 4);
					if (randbottomRoom == 2)
					{
						randbottomRoom = 1;
					}
					Instantiate(rooms[randbottomRoom], transform.position, Quaternion.identity);
				 }

				Vector2 newPos = new Vector2(transform.position.x, transform.position.y - Ymove);
				transform.position = newPos;

				int rand = Random.Range(2, 4);
				Instantiate(rooms[rand], transform.position, Quaternion.identity);
				direction = Random.Range(1, 6);
			}
			else
			{
				stop = true;
			}
		}

	}
}
