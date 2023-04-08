using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 10.0f;
    public float playerRotationSpeed = 100.0f;
    [SerializeField] CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the horizontal and vertical axis using arrow keys
        // The value is in the range -1 to 1
        // Make it move 10 meters per second instead of 10 meters per frame
        float translation = Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime;
        float rotation = Input.GetAxis("Horizontal") * playerRotationSpeed * Time.deltaTime;

        // Move translation along the object´s z-axis
        transform.Translate(0, 0, translation);
        //controller.Move(new Vector3(0, -0.01f, 0));

        // Rotate around our y-axis
        transform.Rotate(0, rotation, 0);

    }
}
