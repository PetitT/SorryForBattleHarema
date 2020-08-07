using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class playVideo : MonoBehaviour
{
    public Elevator elevator;
    public VideoPlayer videoPlayer;
    public GameObject cache1;
    public GameObject cache2;

    private void Awake()
    {
        elevator.onElevatorFinish += ElevatorFinishHandler;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
            StartCoroutine(PlayVid());
    }

    private void ElevatorFinishHandler()
    {
        StartCoroutine("PlayVid");
    }

    private IEnumerator PlayVid()
    {
        yield return new WaitForSeconds(2);
        cache1.SetActive(false);
        cache2.SetActive(false);
        videoPlayer.Play();
        yield return new WaitForSeconds((float)videoPlayer.clip.length + 1);
        cache2.SetActive(true);
    }
}
