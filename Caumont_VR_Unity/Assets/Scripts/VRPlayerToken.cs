using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRPlayerToken : MonoBehaviour
{
    public Transform headTransform;
    private Transform tokenTransform;
    // Start is called before the first frame update
    void Start()
    {
          tokenTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float storedHeight = tokenTransform.position.y;
        float storedXrotation = tokenTransform.eulerAngles.x;
        float storedZrotation = tokenTransform.eulerAngles.z;
        tokenTransform.position = new Vector3(headTransform.position.x, storedHeight, headTransform.position.z);
        tokenTransform.eulerAngles = new Vector3(storedXrotation,headTransform.eulerAngles.y,storedZrotation);
    }
}
