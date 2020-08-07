using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Transform top;
    public float speed;
    private bool hasMoved = false;
    private float YTarget;
    private Vector3 destination;
    private GameObject player;

    public event Action onElevatorFinish;

    private void Start()
    {
        YTarget = top.position.y;
        destination = new Vector3(transform.position.x, YTarget, transform.position.z);
    }

    //private void Update()
    //{
    //    if (isMoving)
    //        if (transform.position.y >= destination.y - 0.1f)
    //        {
    //            isMoving = false;
    //            transform.DetachChildren();
    //            player.GetComponent<CharacterController>().enabled = true;
    //            onElevatorFinish?.Invoke();
    //            Destroy(this);
    //        }

    //    if (isMoving)
    //    {
    //        transform.position = Vector3.Lerp(transform.position, destination, speed * Time.deltaTime);
    //    }
    //}

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        isMoving = true;
    //        player = other.gameObject;
    //        other.transform.parent = gameObject.transform;
    //        other.GetComponent<CharacterController>().enabled = false;
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (!hasMoved)
        {
            if (other.CompareTag("Player"))
            {
                StartCoroutine(GoUp(other.gameObject));
                hasMoved = true;
            }
        }
    }

    private IEnumerator GoUp(GameObject player)
    {
        player.transform.parent = gameObject.transform;
        player.GetComponent<CharacterController>().enabled = false;

        while (transform.position.y < destination.y - 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, destination, speed * Time.deltaTime);
            yield return null;
        }

        player.transform.parent = null;
        player.GetComponent<CharacterController>().enabled = true;
        onElevatorFinish?.Invoke();
    }
}
