using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonUI : MonoBehaviour
{
    public GameObject robot;

    RobotController robotController;

    public double timeSet;
    public int joint;
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
        if(c.gameObject.tag == "leftCont"){
            direction = RotationDirection.Negative;
        }
        robotController = robot.GetComponent<RobotController>();
        StartCoroutine(Move(direction));
    }

    void Update()
    {
        /**
        robotController.RotateJoint(1, RotationDirection.Positive);
        robotController.RotateJoint(0, RotationDirection.Positive);
        robotController.RotateJoint(2, RotationDirection.Positive); **/
    }

    private IEnumerator Move(RotationDirection direction)
    {
        double timeLeft = timeSet;
        while (timeLeft>0)
        {
            robotController.RotateJoint(joint, direction);
            timeLeft-= Time.deltaTime;
            yield return null;
        }
    }
}
