using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPCamera : MonoBehaviour
{
    [SerializeField] private float MinViewDistance = 25f; 
    public float sensivity = 100f;
    
    private float xRotation = 0f;
    [SerializeField] Transform player;
    private Vector3 offset;
    


    private void Awake()
    {
    
        Cursor.lockState = CursorLockMode.Locked;
       

    }

    // Update is called once per frame
    void Update()
    {
        Look();

      
    }

    private void Look()
    {

        float mouseX = Input.GetAxis("Mouse X") * sensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, MinViewDistance);
        
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        
        player.Rotate(Vector3.up * mouseX);
        
        
    }

    
   
}
