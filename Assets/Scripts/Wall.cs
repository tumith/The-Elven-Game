using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [Header("Hole Location Settings")]
    public int HoleHorizontalLoc;
    public bool jumpRequired;
    public bool crouchRequired;

    private GameController gc;
    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.FindGameObjectWithTag("Game Controller").GetComponent<GameController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!gc) return;
        if (transform.position.z > 10) Destroy(gameObject);
        transform.position += new Vector3(0, 0, gc.wallSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerScript player = other.GetComponent<PlayerScript>();

            if (crouchRequired && !player.crouching) gc.GameOver();
            else if (jumpRequired && !player.jumping) gc.GameOver();
            else if (HoleHorizontalLoc != player.horizontalPos) gc.GameOver();
        }
    }
}
