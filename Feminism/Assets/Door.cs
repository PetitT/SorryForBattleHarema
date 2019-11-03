using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            StartCoroutine("PlayAnim");
    }

    private IEnumerator PlayAnim()
    {
        anim.SetTrigger("Open");
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
