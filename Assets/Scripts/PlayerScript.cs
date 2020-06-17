using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Movement Settings")]
    public float sideMovement = .5f;
    public float jumpForce = 200f;
    public float crouchScale = .5f;

    [Header("Internal Attributes")]
    public int horizontalPos = 1;
    public bool jumping = false;
    public bool crouching = false;
    public float crouchTimer = 0f;

    private Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButtonDown("MoveRight") && horizontalPos < 2) MoveRight();
        if (Input.GetButtonDown("MoveLeft") && horizontalPos > 0) MoveLeft();
        if (Input.GetButtonDown("MoveUp") && !jumping && !crouching) Jump();
        if (Input.GetButtonDown("MoveDown") && !crouching) Crouch();
        else if (Input.GetButtonUp("MoveDown") && crouching) UnCrouch();
    }

    // Tékka hvenær hoppið er búið
    private void OnCollisionEnter(Collision collision)
    {
        if (jumping && collision.gameObject.tag == "Ground") jumping = false;
    }

    private void MoveRight()
    {
        horizontalPos++;
        transform.position += new Vector3(-sideMovement, 0, 0);
    }
    private void MoveLeft()
    {
        horizontalPos--;
        transform.position += new Vector3(sideMovement, 0, 0);
    }
    private void Jump()
    {
        jumping = true;
        rb.AddForce(new Vector3(0, jumpForce, 0));
    }
    private void Crouch()
    {
        crouching = true;
        transform.localScale = new Vector3(1, crouchScale, 1);
    }
    private void UnCrouch()
    {
        crouching = false;
        transform.localScale = new Vector3(1, 1, 1);
    }

}
