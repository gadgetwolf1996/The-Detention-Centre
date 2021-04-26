using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperateDoor : MonoBehaviour
{
    Vector3 closedpositionr;
    Vector3 openpositionr;
    Vector3 closedpositionl;
    Vector3 openpositionl;
    
    float speed = 1.0f;
    bool nearby = false;

    public GameObject rightdoor;
    public GameObject leftdoor;


    // Start is called before the first frame update
    void Start()
    {
        closedpositionl = leftdoor.transform.position;
        closedpositionr = rightdoor.transform.position;
        if(this.transform.rotation.y != 0.0f){
            openpositionr = rightdoor.transform.position + new Vector3(0,0,-2);
            openpositionl = leftdoor.transform.position + new Vector3(0,0,2);
        }
        
        if(this.transform.rotation.y == 0.0f){
            openpositionr = rightdoor.transform.position + new Vector3(2,0,0);
            openpositionl = leftdoor.transform.position + new Vector3(-2,0,0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch(nearby)
        {
            case true:
                rightdoor.transform.position = openpositionr;
                leftdoor.transform.position = openpositionl;
                break;
            case false:
                rightdoor.transform.position = closedpositionr;
                leftdoor.transform.position = closedpositionl;
                break;
            default:
                break;
        }   
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") nearby = true;
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "Player") nearby = false;
    }
}
