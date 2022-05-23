using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonUI : MonoBehaviour
{
    public GameObject robot;

    RobotController robotController;

    public double timeSet;

    public int joint;

    double startTime = 1;

    public bool on = true;

    void Start()
    {
        robotController = robot.GetComponent<RobotController>();
    }

    /**
    public void onButtonClick()
    {
        robotController = robot.GetComponent<RobotController>();

        robotController.RotateJoint(1, RotationDirection.Positive);
        StartCoroutine(Move());
    } **/
    void OnTriggerEnter(Collider c)
    {
        RotationDirection direction = RotationDirection.Positive;
        if (c.gameObject.tag == "leftCont")
        {
            direction = RotationDirection.Negative;
        }
        robotController = robot.GetComponent<RobotController>();
        StartCoroutine(Move(direction));
    }

    void Update()
    {
        ///StartCoroutine(MoveCube());
        /**
        robotController.RotateJoint(1, RotationDirection.Positive);
        robotController.RotateJoint(0, RotationDirection.Positive);
        robotController.RotateJoint(2, RotationDirection.Positive); **/
    }

    private IEnumerator Move(RotationDirection direction)
    {
        double timeLeft = timeSet;
        while (timeLeft > 0)
        {
            robotController.RotateJoint (joint, direction);
            timeLeft -= Time.deltaTime;
            yield return null;
        }
    }
    public void startCube(){
        StartCoroutine(MoveCube());
    }
    private IEnumerator MoveCube()
    {
        on = true;
        while (on)
        {
            RotationDirection positive = RotationDirection.Positive;
            RotationDirection negative = RotationDirection.Negative;
            startTime = .4;

            while (startTime > 0)
            {
                robotController.RotateJoint(1, positive);
                startTime -= Time.deltaTime;
                yield return null;
            }
            startTime = .3;
            while (startTime > 0)
            {
                robotController.RotateJoint(2, negative);
                startTime -= Time.deltaTime;
                yield return null;
            }
            startTime = .775;
            while (startTime > 0)
            {
                robotController.RotateJoint(3, negative);
                startTime -= Time.deltaTime;
                yield return null;
            }
            
            startTime = .2;
            while (startTime > 0)
            {
                robotController.RotateJoint(1, positive);
                startTime -= Time.deltaTime;
                yield return null;
            }
            
            on = false;
        }
    }
}
