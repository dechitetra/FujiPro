using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private readonly float MAX_SPEED = 5.0f;
    private bool _IsGround = true;
    public float _Acceleration;
    public float _JumpSpeed;
    public Rigidbody2D rd;
    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        // 方向の取得
        float vectol = Input.GetAxisRaw("Horizontal");
        this.rd.AddForce(new Vector2(vectol * _Acceleration, 0));

        float xVelocity = this.rd.velocity.x;
        if(xVelocity > MAX_SPEED)
        {
            this.rd.velocity = new Vector2(MAX_SPEED, this.rd.velocity.y);
        }
        else if(xVelocity < (MAX_SPEED * -1))
        {
            this.rd.velocity = new Vector2((MAX_SPEED * -1), this.rd.velocity.y);
        }
        //Debug.Log(string.Format("velocity{0}",this.rd.velocity.x));
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && _IsGround)
        {
            this.rd.AddForce(new Vector2(0, _JumpSpeed));
            _IsGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground") 
        {
			_IsGround = true;
		}
        Debug.Log("何かが  判定に入りました");
    }
}