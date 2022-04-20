using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    Animator anim;
    public float moveSpeed = 5.0f;
    float vSpeed;
    float hSpeed;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        vSpeed = Input.GetAxis("Vertical");
        hSpeed = Input.GetAxis("Horizontal");

        anim.SetFloat("vSpeed", vSpeed);
        anim.SetFloat("hSpeed", hSpeed);

        Vector2 moveVec = new Vector2(hSpeed, vSpeed);
        anim.SetBool("bMove", moveVec.sqrMagnitude < 0.01f);

        transform.Translate(new Vector2(hSpeed, vSpeed) * moveSpeed * Time.deltaTime);
    }
}
