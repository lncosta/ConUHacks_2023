using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] public GameObject target;
    [SerializeField] public Vector3 positionFromTarget; 
    // Start is called before the first frame update
    void Start()
    {
        positionFromTarget = new Vector3(0, 0, 0); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.transform.position + positionFromTarget; 
        transform.rotation = target.transform.rotation;
        
    }
}
