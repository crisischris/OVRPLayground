﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMenuManager : MonoBehaviour {

    public SteamVR_LoadLevel loadLevel;
    public List <GameObject> objectList;
    public List<GameObject> objectPrebabList;
    public GameObject clone;

    public int currentObject = 0;

	// Use this for initialization
	void Start () {
        foreach(Transform child in transform)
        {
            objectList.Add(child.gameObject);
            
        }
		
	}

    public void MenuLeft()
    {
        objectList[currentObject].SetActive(false);
        currentObject--;
        if (currentObject < 0)
        {
            currentObject = objectList.Count - 1;
        }
        objectList[currentObject].SetActive(true);

    }

    public void MenuRight()
    {
        objectList[currentObject].SetActive(false);
        currentObject++;
        if (currentObject > objectList.Count-1)
        {
            currentObject = 0;
        }
        objectList[currentObject].SetActive(true);

    }

    public void SpawnCurrentObject()
    {
        clone = Instantiate(objectPrebabList[currentObject], objectList[currentObject].transform.position, objectList[currentObject].transform.rotation);
        clone.AddComponent<BoxCollider>();
        clone.AddComponent<Rigidbody>();
        Rigidbody rb = clone.GetComponent<Rigidbody>();

        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

       // loadLevel.Trigger();
    }





// Update is called once per frame
void Update () {
		
	}
}