using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatBehaviour : MonoBehaviour
{
    public GameObject cat;
    public GameObject trex;
    public NavMeshAgent nav;
    public float timeBeforeNewPos;
    private float currentTimeBeforeNewPos;
    public float maxDistanceRadius;

    private void Start()
    {
        currentTimeBeforeNewPos = timeBeforeNewPos;
        SetNewDestination();
    }

    private void Update()
    {
        CheckState();
        NewPositionTimer();
    }

    private void NewPositionTimer()
    {
        currentTimeBeforeNewPos -= Time.deltaTime;
        if(currentTimeBeforeNewPos <= 0)
        {
            SetNewDestination();
            currentTimeBeforeNewPos = timeBeforeNewPos;
        }
    }

    private void SetNewDestination()
    {
        nav.SetDestination(RandomDestination());
    }

    private Vector3 RandomDestination()
    {
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * maxDistanceRadius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, maxDistanceRadius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }

    private void CheckState()
    {
        if (CheatCode.instance.catState == CatState.trex)
        {
            cat.SetActive(false);
            trex.SetActive(true);
        }
    }
}
