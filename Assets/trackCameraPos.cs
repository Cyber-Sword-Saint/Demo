using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackCameraPos : MonoBehaviour
{
    Camera mainCamera;
    // Start is called before the first frame update
    private void Start()
    {
        mainCamera = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        this.transform.localPosition = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, this.transform.position.z);
    }
}
