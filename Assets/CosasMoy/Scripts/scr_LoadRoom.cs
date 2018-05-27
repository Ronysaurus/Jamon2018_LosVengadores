﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_LoadRoom : MonoBehaviour {

    public GameObject LastRoom;
    public GameObject NextRoom;

    public scr_Door CloseDoor;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CloseDoor.Closed = true;
            Destroy(LastRoom);
            NextRoom.SetActive(true);
            Destroy(gameObject);
        }
    }
}
