using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Transform top;
    public float speed;
    private bool isMoving = false;
    private float YTarget;
    private Vector3 destination;
    private GameObject player;

    public event Action onElevatorFinish;

    private void Start()
    {
        YTarget = top.position.y;
        destination = new Vector3(transform.position.x, YTarget, transform.position.z);
    }

    private void Update()
    {
        if (isMoving)
            if (transform.position.y >= destination.y - 0.1f)
            {
                isMoving = false;
                transform.DetachChildren();
                player.GetComponent<CharacterController>().enabled = true;
                onElevatorFinish?.Invoke();
            }

        if (isMoving)
        {
            transform.position = Vector3.Lerp(transform.position, destination, speed * Time.deltaTime);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isMoving = true;
            player = other.gameObject;
            other.transform.parent = gameObject.transform;
            other.GetComponent<CharacterController>().enabled = false;
        }
    }

}
