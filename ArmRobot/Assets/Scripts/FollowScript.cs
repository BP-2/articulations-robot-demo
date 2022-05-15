using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    [SerializeField]
    public GameObject person;
    private Vector3 offset = new Vector3(0,0,.7f);
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(person.transform.position.x+offset.x,person.transform.position.y+offset.y,person.transform.position.z+offset.z);
    }
}
