using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    public float speed;
    private int score;
    public Text textScore;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        setScore();
    }

	void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pick up"))
            other.gameObject.SetActive(false);
        score++;
        setScore();
    }


    void setScore()
    {
        textScore.text = "Your score is " + score;
    }
}
