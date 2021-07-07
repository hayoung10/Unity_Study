using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public float speed = 8f; // 이동 속력

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()

    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        playerRigidbody.velocity = newVelocity;
    }

    public void Die()
    {
        gameObject.SetActive(false); // 비활성화

        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();
    }
}
