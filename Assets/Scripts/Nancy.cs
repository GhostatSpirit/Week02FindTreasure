﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Nancy : MonoBehaviour {
    public Text UIText;
    public Transform player;
    public Transform door;

    public float inboundDistance = 4.5f;
    public float outboundDistance = 12f;
    // Use this for initialization
    string defaultText;
    bool inbound;
    bool hasOpen;
	void Start () {
        defaultText = UIText.GetComponent<TextController>().defaultText;
        inbound = false;
        hasOpen = false;
	}
	
	// Update is called once per frame
	void Update () {
        float distance = (player.position - transform.position).magnitude;
        Debug.Log(distance);
	    if(distance < inboundDistance) {
            if (!inbound) {
                UIText.text = "Nancy Lee: OK, I've hacked the locked door for you.\nFollow the red darts back then go south at the black dart!\n";
                inbound = true;
                if (!hasOpen) {
                    hasOpen = true;
                    door.GetComponent<DoorController>().isOpen = true;
                }
                
            }
        } else if (inbound && distance > outboundDistance) {
            UIText.text = defaultText;
            inbound = false;
        }
	}
}
