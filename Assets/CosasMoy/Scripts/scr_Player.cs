﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Player : MonoBehaviour {

    [HideInInspector]
    public GameObject LastCheckPoint;

    public bool Death;

    public static int Deaths = 0;

	// Use this for initialization
	void Start () {
        Death = false;
        
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Restart") &&LastCheckPoint!=null )
        {
            foreach(SCR_Atributable obj in FindObjectsOfType<SCR_Atributable>())
            {
                obj.ResetObject();
            }
            transform.position = LastCheckPoint.transform.position;
            transform.rotation = Quaternion.identity;
            if (Death)
            {
                GetComponent<scr_Gun>().enabled = true;
                GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
                Death = false;
                scr_UI.UI.GameOver.SetActive(false);
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KillZone") && !Death)
        {
            GetComponent<scr_Gun>().enabled = false;
            GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
            Death = true;
            Deaths++;
            scr_UI.UI.GameOver.SetActive(true);
        }
        if (other.CompareTag("ChekPoint"))
        {
            LastCheckPoint = other.gameObject;
        }
        if (other.gameObject.CompareTag("Atributable"))
        {
            if (other.gameObject.GetComponent<SCR_Atributable>().atributo == SCR_Atributable.ATRIBUTO.Rebotable && other.transform.position.y<transform.position.y)
                gameObject.SendMessage("Jump", 18f);
        }
    }

}
