using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackerPositioning : MonoBehaviour
{
    public Transform VRCamera;
    public Transform radio;
    // Start is called before the first frame update
    void Start()
    {
        VRCamera.transform.localPosition = new Vector3(0, -1.36f, 0) + radio.transform.localPosition;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
