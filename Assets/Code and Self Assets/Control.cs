using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;



public class Control : MonoBehaviour
{

    Vector3 tempPos, tempRot;
    float speed = 2f;
    float zed = 3.72f;
    public float xMin = -2f;
    public float xMax = 2.14f;
    public float yMin = -1.81f;
    public float yMax = 1.74f;
    public float tilt = 10f;
    public float yRotation = 0.0F;
    public float xRotation = 0.0F;
    float xThrow, yThrow;


    // Use this for initialization
    void Start()
    {

    }

    void checkInput()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
    }

    void assignUpDown()
    {
        tempPos.x += xThrow * speed * Time.deltaTime;
        tempPos.y += yThrow * speed * Time.deltaTime;
        tempPos = new Vector3(
             Mathf.Clamp(tempPos.x, xMin, xMax),
             Mathf.Clamp(tempPos.y, yMin, yMax),
             transform.localPosition.z
             );
    }

    void smoothRotateX()
    {   //the name is X because the rotation is different from the x and y axis for transform this is actually z
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

    void smoothRotateY()
    {   //the name is Y because the rotation is different from the x and y axis for transform this is actually x but input is from y
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
    }



    
    void debug()
    {
        print(xThrow);
        print(yThrow);
        print("X: "+tempPos.x);
        print("Y: "+tempPos.y);
    }

    // Update is called once per frame
    void Update()
    {
        tempPos = transform.localPosition;
        /*   INPUT   */
        checkInput();
        //debug();
        /*  MOVEMENT FOR UP AND DOWN  */
        assignUpDown();
        
        /*  FOR ROTATION  */
        smoothRotateX();
        smoothRotateY();

        /* Clamping x and y rotation values */
        yRotation = Mathf.Clamp(yRotation, -30.0f, 30.0f);
        xRotation = Mathf.Clamp(xRotation, -18.0f, 20.0f);

        /* Applying of rotation values */
        transform.localEulerAngles = new Vector3(
            yRotation,
            0,
            xRotation
            );

        /* apply movement - only apply transform when newposi is not less or more than 4*/
        if (transform.localEulerAngles.z >= 4 || transform.localEulerAngles.z <= -4 || transform.localEulerAngles.x >= 4 || transform.localEulerAngles.x <= -4)
        {
            transform.localPosition = tempPos;
        }

    }
    

}
