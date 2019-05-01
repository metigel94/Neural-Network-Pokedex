using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    Vector3 horizontalMove = new Vector3 (1, 0, 0);
    Vector3 verticalMove = new Vector3(0, 0, 1);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Vertical")){
    this.gameObject.transform.Translate(Input.GetAxis("Vertical")*Vector3.forward*6*Time.deltaTime);
    }
        if (Input.GetButton("Horizontal")){
    this.gameObject.transform.Translate(Input.GetAxis("Horizontal")*Vector3.right*6*Time.deltaTime);
    }
    }
}
