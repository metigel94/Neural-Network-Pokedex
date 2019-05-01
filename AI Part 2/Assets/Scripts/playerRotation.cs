using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class playerRotation : MonoBehaviour
{

    public string mouseXInputName, mouseYInputName;
    public float mouseSensitivity = 10;
    private float xAxisClamp = 0.0f;

    public Transform playerBody;
    // Start is called before the first frame update
    void Start()
    {
        LockCursor();
        mouseXInputName = "Mouse X";
        mouseYInputName = "Mouse Y";
    }

    // Update is called once per frame
    void Update()
    {
        CameraRotation();
    }

    private void LockCursor(){
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void CameraRotation(){
        float mouseX = Input.GetAxis(mouseXInputName) * mouseSensitivity*Time.deltaTime;
        float mouseY = Input.GetAxis(mouseYInputName) * mouseSensitivity*Time.deltaTime;

        xAxisClamp += mouseY;

        if(xAxisClamp > 90.0f){
            xAxisClamp = 90.0f;
            mouseY = 0;
            ClampxAxisRotationToValue(270.0f);
        }
        else if(xAxisClamp < -90.0f){
            xAxisClamp = -90.0f;
            mouseY = 0;
            ClampxAxisRotationToValue(90.0f);
        }


        transform.Rotate(Vector3.left * mouseY);
        playerBody.Rotate(Vector3.up*mouseX);
    }
    private void ClampxAxisRotationToValue(float value){
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }
}
