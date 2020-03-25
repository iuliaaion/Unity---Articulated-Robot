using System;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    GameObject Cat;
    GameObject head, body, LUpperArm, LLowerArm, RUpperArm, RLowerArm, LUpperLeg, LLowerLeg, RUpperLeg, RLowerLeg;
    GameObject RElbow, RShoulder;
    GameObject LElbow, LShoulder;
    GameObject RButt, RKnee;
    GameObject LButt, LKnee;
    bool limbAnimatonForward;

    public float movementSpeed { get; set; }

    public float rotationSpeed { get { return movementSpeed * 30; } }

    // Start is called before the first frame update
    void Start()
    {
        Cat = GameObject.Find("Cat");
        head = GameObject.Find("head");
        body = GameObject.Find("body");

        RUpperArm = GameObject.Find("RUpperArm");
        RLowerArm = GameObject.Find("RLowerArm");
        LUpperArm = GameObject.Find("LUpperArm");
        LLowerArm = GameObject.Find("LLowerArm");

        LUpperLeg = GameObject.Find("LUpperLeg");
        LLowerLeg = GameObject.Find("LLowerLeg");
        RUpperLeg = GameObject.Find("RUpperLeg");
        RLowerLeg = GameObject.Find("RLowerLeg");

        LElbow = GameObject.Find("LElbow");
        LShoulder = GameObject.Find("LShoulder");

        RElbow = GameObject.Find("RElbow");
        RShoulder = GameObject.Find("RShoulder");

        LButt = GameObject.Find("LButt");
        LKnee = GameObject.Find("LKnee");

        RButt = GameObject.Find("RButt");
        RKnee = GameObject.Find("RKnee");

        movementSpeed = 5;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            MoveForward();
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            MoveBackward();
        }
    }

    /* animates the limbs of the robot */
    void AnimateLimbs()
    {
        if(LUpperLeg.transform.rotation.x > 0)
        {
            if(!limbAnimatonForward)
            {
                LLowerLeg.transform.RotateAround(LKnee.transform.position, Vector3.left, rotationSpeed * 3 * Time.deltaTime);
                LLowerArm.transform.RotateAround(LElbow.transform.position, Vector3.right, rotationSpeed * 3 * Time.deltaTime);
            }
            else
            {
                LLowerLeg.transform.RotateAround(LKnee.transform.position, Vector3.right, rotationSpeed * 2.7811f * Time.deltaTime);
                LLowerArm.transform.RotateAround(LElbow.transform.position, Vector3.left, rotationSpeed * 2.7813f * Time.deltaTime);
            }
        }

        if(RUpperLeg.transform.rotation.x > 0)
        {
            if(limbAnimatonForward)
            {
                RLowerLeg.transform.RotateAround(RKnee.transform.position, Vector3.left, rotationSpeed * 3 * Time.deltaTime);
                RLowerArm.transform.RotateAround(RElbow.transform.position, Vector3.right, rotationSpeed * 3 * Time.deltaTime);
            }
            else
            {
                RLowerLeg.transform.RotateAround(RKnee.transform.position, Vector3.right, rotationSpeed * 2.7811f * Time.deltaTime);
                RLowerArm.transform.RotateAround(RElbow.transform.position, Vector3.left, rotationSpeed * 3 * Time.deltaTime);
            }
        }

        Debug.Log(LUpperArm.transform.rotation);
        if(Math.Abs(LUpperArm.transform.rotation.x) > 0.25f)
        {
            limbAnimatonForward = !limbAnimatonForward;
        }

        if(limbAnimatonForward)
        {
            LUpperArm.transform.RotateAround(LShoulder.transform.position, Vector3.left, rotationSpeed * Time.deltaTime);
            RUpperArm.transform.RotateAround(RShoulder.transform.position, Vector3.right, rotationSpeed * Time.deltaTime);

            LUpperLeg.transform.RotateAround(LButt.transform.position, Vector3.right, rotationSpeed * Time.deltaTime);
            RUpperLeg.transform.RotateAround(RButt.transform.position, Vector3.left, rotationSpeed * Time.deltaTime);
        }
        else
        {
            LUpperArm.transform.RotateAround(LShoulder.transform.position, Vector3.right, rotationSpeed * Time.deltaTime);
            RUpperArm.transform.RotateAround(RShoulder.transform.position, Vector3.left, rotationSpeed * Time.deltaTime);

            LUpperLeg.transform.RotateAround(LButt.transform.position, Vector3.left, rotationSpeed * Time.deltaTime);
            RUpperLeg.transform.RotateAround(RButt.transform.position, Vector3.right, rotationSpeed * Time.deltaTime);
        }
    }

    void MoveForward()
    {
        Cat.transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        AnimateLimbs();
    }

    void MoveBackward()
    {
        Cat.transform.Translate(Vector3.back * movementSpeed * Time.deltaTime);
        AnimateLimbs();
    }
}
