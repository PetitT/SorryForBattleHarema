using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class CatPool : MonoBehaviour
{
    public static CatPool instance;

    public GameObject cat;
    public int baseNumberOfCats;
    public Transform backLeft, frontRight;

    private List<GameObject> catList = new List<GameObject>();

    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        else
            instance = this;
    }

    private void Start()
    {
        InstantiateCats();
    }

    private void InstantiateCats()
    {
        for (int i = 0; i < baseNumberOfCats; i++)
        {
            GameObject newCat = Instantiate(cat, GetNewPosition(), transform.rotation);
            //newCat.SetActive(false);
            catList.Add(newCat);
        }
    }

    private Vector3 GetNewPosition()
    {
        float XPos = UnityEngine.Random.Range(backLeft.position.x, frontRight.position.x);
        float ZPos = UnityEngine.Random.Range(backLeft.position.z, frontRight.position.z);
        float YPos = backLeft.position.y;
        Vector3 position = new Vector3(XPos, YPos, ZPos);
        return position;
    }

    public GameObject GetCat(Vector3 spawnPosition)
    {
        GameObject kitty = catList.Where(x => !x.activeSelf).FirstOrDefault();
        if (!kitty)
        {
            kitty = Instantiate(cat);
            catList.Add(kitty);
        }
        kitty.transform.position = spawnPosition;
        kitty.SetActive(true);
        return kitty;
    }
}
