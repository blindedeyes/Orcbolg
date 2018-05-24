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

    // Use this for initialization
    void Start()
    {
        myTransform = GetComponent<Transform>();
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
        Vector3 direction = Vector3.zero;
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
            myTransform.position += (direction * moveSpeed * Time.deltaTime);
        } 

    }
}
