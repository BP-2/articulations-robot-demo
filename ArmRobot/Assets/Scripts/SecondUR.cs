using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondUR : MonoBehaviour
{
    public GameObject Menu;

    public GameObject UR;

    private bool active = false;

    RobotController robotController;

    PincherController pincherController;

    public GameObject hand;

    public bool on;

    void Start()
    {
        robotController = UR.GetComponent<RobotController>();
        pincherController = hand.GetComponent<PincherController>();
    }

    public void createNDestroy()
    {
        if (!active)
        {
            Menu.SetActive(true);
            UR.SetActive(true);
            active = true;
            return;
        }
        Menu.SetActive(false);
        UR.SetActive(false);
        active = false;
    }

    void OnTriggerEnter(Collider c)
    {
        if (on)
        {
            startCube();
            return;
        }
        createNDestroy();
    }

    public void startCube()
    {
        StartCoroutine(MoveCube());
    }

    private IEnumerator MoveCube()
    {
        while (on)
        {
            RotationDirection positive = RotationDirection.Positive;
            RotationDirection negative = RotationDirection.Negative;
            double startTime = .4;

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

            startTime = .0002;
            while (startTime > 0)
            {
                robotController.RotateJoint(1, positive);
                startTime -= Time.deltaTime;
                yield return null;
            }
            startTime = 3;
            while (startTime > 0)
            {
                pincherController.gripState = GripState.Closing;
                startTime -= Time.deltaTime;
                yield return null;
            }
            startTime = 1.2;
            while (startTime > 0)
            {
                robotController.RotateJoint(1, negative);
                startTime -= Time.deltaTime;
                yield return null;
            }
            startTime = .6;
            while (startTime > 0)
            {
                robotController.RotateJoint(2, positive);
                startTime -= Time.deltaTime;
                yield return null;
            }
            startTime = .4;
            while (startTime > 0)
            {
                robotController.RotateJoint(3, positive);
                startTime -= Time.deltaTime;
                yield return null;
            }
            startTime = 1.3;
            while (startTime > 0)
            {
                pincherController.gripState = GripState.Opening;
                startTime -= Time.deltaTime;
                yield return null;
            }
            startTime = 1.2;
            while (startTime > 0)
            {
                robotController.RotateJoint(1, positive);
                startTime -= Time.deltaTime;
                yield return null;
            }
            on = false;
        }
        on = true;
    }
}
