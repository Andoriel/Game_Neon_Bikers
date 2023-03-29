using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movPlayer : MonoBehaviour
{
    private CharacterController character;

    private Vector3 moveDirection;
    private Vector3 inputs;

    private float rot;
    private float finalSpeed;

    public float speed;
    public float gravity;
    public float rotSpeed;
    public bool slow;

    void Start()
    {
        character = GetComponent<CharacterController>();
    }


    void Update()
    {
        Move();
    }


    void Move()
    {
        finalSpeed = speed * (slow ? 0.5f : 1);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveDirection = Vector3.forward * finalSpeed;
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            moveDirection = Vector3.zero;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveDirection = Vector3.forward * -finalSpeed;
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            moveDirection = Vector3.zero;
        }

        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);

        moveDirection.y -= gravity * Time.deltaTime;
        moveDirection = transform.TransformDirection(moveDirection);

        character.Move(moveDirection * Time.deltaTime);

    }
}

