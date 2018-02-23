using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;



public class Control : MonoBehaviour
{

    Vector3 tempPos, tempRot;
    float speed = 2f;
    float zed = 3.72f;
    public float xMin = -3.95f;
    public float xMax = 3.6f;
    public float yMin = -2.75f;
    public float yMax = 2.4f;
    public float tilt = 10f;
    public float yRotation = 0.0F;
    public float xRotation = 0.0F;
    float xThrow, yThrow;


    // Use this for initialization
    void Start()
    {

    }

    void smoothRotateX()
    {
        if (yThrow == 0 && (transform.localEulerAngles.x >= 1 || transform.localEulerAngles.x <= -1))
        {   //-5 31

            if (yRotation >= -30.0f && yRotation <= 0.0f)
                yRotation += 1f;
            else if (yRotation <= 30.0f)
                yRotation -= 1f;
        }
        else if (yThrow == 0)
        {
            yRotation = 0f;
        }
        yRotation += -yThrow * tilt * Time.deltaTime * 10;
        yRotation = Mathf.Clamp(yRotation, -30.0f, 30.0f);
    }


    // Update is called once per frame
    void Update()
    {

        tempPos = transform.localPosition;
        /*   INPUT   */
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        //print(xThrow);
        print(yThrow);
        //print("X: "+tempPos.x);

        //print("Y: "+tempPos.y);

        /*  MOVEMENT FOR UP AND DOWN  */
        tempPos.x += xThrow * speed * Time.deltaTime;
        tempPos.y += yThrow * speed * Time.deltaTime;
        tempPos = new Vector3(
             Mathf.Clamp(tempPos.x, xMin, xMax),
             Mathf.Clamp(tempPos.y, yMin, yMax),
             transform.localPosition.z
             );



        yRotation = Mathf.Clamp(yRotation, -30.0f, 30.0f);
        xRotation = Mathf.Clamp(xRotation, -18.0f, 20.0f);
        /*  FOR ROTATION  */
        smoothRotateX();

        if (xThrow == 0 && (transform.localEulerAngles.z >= 1 || transform.localEulerAngles.z <= -1))
        {   //-5 31

            if (xRotation >= -20.0f && xRotation <= 0.0f)
                xRotation += 1f;
            else if (xRotation <= 20.0f)
                xRotation -= 1f;
        }
        else if (xThrow == 0)
        {
            xRotation = 0f;
        }
        xRotation += -xThrow * tilt * Time.deltaTime * 10;
        xRotation = Mathf.Clamp(xRotation, -18.0f, 20.0f);


        //print(yRotation);
        transform.localEulerAngles = new Vector3(
            Mathf.Clamp(yRotation, -30.0f, 30.0f),
            0,
            Mathf.Clamp(xRotation, -20.0f, 20.0f)
            );



        //apply movement
        if(transform.localEulerAngles.z >= 4 || transform.localEulerAngles.z <= -4 || transform.localEulerAngles.x >= 4 || transform.localEulerAngles.x <= -4 )
            transform.localPosition = tempPos;

    }
}
