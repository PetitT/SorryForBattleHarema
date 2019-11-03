using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMeowScript : MonoBehaviour
{
    public List<AudioClip> meowSounds;
    public AudioSource audioSource;

    private void Start()
    {
        StartCoroutine("PlayNewSound");
    }

    private IEnumerator PlayNewSound()
    {
        int randomNumber = Random.Range(0, meowSounds.Count);
        audioSource.PlayOneShot(meowSounds[randomNumber]);
        yield return new WaitForSeconds(meowSounds[randomNumber].length);
        StartCoroutine("PlayNewSound");
    }
}
