using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    #region Inspector Variables
    public float moveSpeed = 1.0f;
    public Animator myAnimator;
    public SpriteRenderer mySpriteRenderer;
    #endregion
    //for later

    Transform myTransform;

    private int aniMovingHash;
    private Rigidbody2D myRBody;
    // Use this for initialization
    void Start()
    {
        myTransform = GetComponent<Transform>();
        myRBody = GetComponent<Rigidbody2D>();
        //cache the animation hashes
        aniMovingHash = Animator.StringToHash("Moving");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 direction = Vector2.zero;
        bool moved = ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.D)));
        if (Input.GetKey(KeyCode.W)) //up
        {
            direction.y += 1;
        }
        if (Input.GetKey(KeyCode.S)) //down
        {
            direction.y -= 1;
        }
        if (Input.GetKey(KeyCode.A)) //left
        {
            mySpriteRenderer.flipX = false;
            direction.x -= 1;
        }
        if (Input.GetKey(KeyCode.D)) //right
        {
            mySpriteRenderer.flipX = true;
            direction.x += 1;
        }
        myAnimator.SetBool(aniMovingHash, moved);
        if (moved)
        {
            direction.Normalize();
            myRBody.velocity = (direction * moveSpeed);

        }
        else
            myRBody.velocity = Vector2.zero;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("ENTER");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //Debug.Log("STAY");
    }

}
