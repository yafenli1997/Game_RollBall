using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    public GameObject Prefab;

    public string TargetTag;

    public GameObject Target;

    public int MakeLimit = 6;

    public double MakeRate = 2.0f;

    private float _lastMake = 0;

    private int _madeCount = 0;

    // Start is called before the first frame update
    private void Start()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(TargetTag);
        Target = targets[Random.Range(0, targets.Length)];
    }

    // Update is called once per frame
    private void Update()
    {
        if (Target == null) { return; }

        //when factory is done making (i.e. reached it's limit)
        if (_madeCount >= MakeLimit)
        {
            Destroy(gameObject);
        }

        //instantiate Agent
        _lastMake += Time.deltaTime; //_lastMake = _lastMake + Time.deltaTime;
        if (_lastMake > MakeRate)
        {
            //Debug.Log("Make");
            _lastMake = 0; //reset time counter

            GameObject go = Instantiate(Prefab, this.transform.position, Quaternion.identity);
            MobileUnit mu = go.GetComponent<MobileUnit>();
            mu.Target = Target;

            _madeCount++;
        }
    }
}