using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public Rigidbody2D  rigidbody2D;
	[Header("目前的水平fangxiang")]
	public float horizontalDirection;//这个数值会在 -1 到 1之间, 代表左右.

	const string HORIZONTAL = "Horizontal";


    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }



    public bool JumpKey
    {
        get
        {
            return Input.GetKeyDown(KeyCode.Space);
        }

    }

    public float yForce;
    private void Update()
    {
    if (JumpKey)
        {
            Debug.Log("123");
            rigidbody2D.AddForce(Vector2.up * yForce);   //微妙　。。
            
  

        }
 }
  private Vector2 speedX = new Vector2(6, 0);



    float AddSpeed =0f;
    void FixedUpdate()

    {
        Debug.Log(AddSpeed);
        float horizontalDirection = Input.GetAxis("Horizontal");

        rigidbody2D.MovePosition(rigidbody2D.position + speedX * horizontalDirection * Time.deltaTime * Mathf.Clamp(AddSpeed/10, 0.50F, 1.5F));

        if (horizontalDirection!=0)

        {
            AddSpeed += 0.25f;

        }
        else { AddSpeed = 0f; }
     }
    
}