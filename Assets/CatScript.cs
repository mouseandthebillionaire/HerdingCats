﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatScript : MonoBehaviour {

    public KeyCode catKey;   
    private bool catKeyDown;
    private NavMeshAgent agent;
    
    // Start is called before the first frame update
    void Start() {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update() {

        if (Input.anyKeyDown) {
            if (Input.GetKey(catKey)) catKeyDown = true;
            else catKeyDown = false;
        }


        if (Input.GetMouseButtonDown(0) && catKeyDown){
            Debug.Log("Both");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
            RaycastHit hit;
                
            if (Physics.Raycast(ray, out hit)) {
                if (hit.collider.tag == "Ground") { 
                    agent.SetDestination(hit.point);
                }
            }
        }
    }
}
