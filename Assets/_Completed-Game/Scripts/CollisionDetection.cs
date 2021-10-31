using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public string CollisionTag = "Agent";
    private MobileUnit _mobileUnit;

    // Start is called before the first frame update
    private void Start()
    {
        //Debug.Log("CollisionDetection.Start()");
        _mobileUnit = transform.parent.GetComponent<MobileUnit>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("OnTriggerEnter()");
        if (!_mobileUnit._reachedTarget) { return; }
        GameObject go = other.gameObject;
        if (go.tag != CollisionTag) { return; }
        _mobileUnit.StartConfigure(go);
    }
}