using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public float rotationSpeed = 5.0f;

    private Vector3 basePosition;
    private Vector3 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        
        //basePosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {



        // Get the mouse position in screen coordinates
        //mousePos = Input.mousePosition;

        // Convert the mouse position to world coordinates
        //mousePos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10.0f));

        // Calculate the direction from the base to the mouse position
        //Vector3 direction = mousePos - basePosition;

        // Calculate the angle between the direction and forward vector of the base
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate the gun towards the center/base
        //transform.rotation = Quaternion.LookRotation(basePosition - transform.position, Vector3.forward);
        /*
        if (angle > 0)
        {
            transform.Rotate(new Vector3(0, 0, angle * rotationSpeed) * Time.deltaTime);
        }
        */

        // Get the mouse position in screen coordinates
        mousePos = Input.mousePosition;

        // Convert the mouse position to world coordinates
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10.0f));

        // Get the direction from the base (parent) to the mouse position
        Vector3 direction = mousePos - transform.parent.position;

        // Calculate the angle in radians
        float angle = Mathf.Atan2(direction.y, direction.x);

        // Set the Z rotation of the gun only
        transform.localRotation = Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg - 90f);

        // Optional: Smooth rotation with Quaternion.Slerp
        //Quaternion targetRotation = Quaternion.Euler(0, 0, (angle-90f) * Mathf.Rad2Deg);
        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);


    }
}
