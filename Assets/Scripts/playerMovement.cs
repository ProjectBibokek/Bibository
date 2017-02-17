using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public bool facingRight = true;
    public int move;
    public float z;
    public float v;
    Animator NewAnimatorController;
    public int animationType; //1 - small obstacle, 2 - medium obstacle, 3 - large obstacle

    // Use this for initialization
    void Start()
    {

    }

    public void MoveWithButtons(int mov)
    {
        move = mov;
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        z = move * Time.deltaTime * v;
        if (move > 0.0 & v < 1.0f)
        {
            v = v + 0.01f;
            Debug.Log("shiet");
        }
        else if (v == 1.0f)
        {
            v = 3.0f;
            Debug.Log("wut");
        }
        else if (move == 0)
        {
            v = 0.1f;
            Debug.Log("arrr");
        }
        int transitionMove = Mathf.Abs(move);
        transform.Translate(0, 0, z);
        NewAnimatorController = GetComponent<Animator>();
        NewAnimatorController.SetFloat("Movement", transitionMove);
        if ((z < 0) && (facingRight))
        {
            Flip();
        }

        if ((z > 0) && (!facingRight))
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "MediumObstacle")
        {
            Animator NewAnimatorController;
            animationType = 2;
            NewAnimatorController = GetComponent<Animator>();
            NewAnimatorController.SetInteger("ObstacleTypeOnCollision", animationType);
            transform.Translate(0, 1, 1);
        }
    }
}

