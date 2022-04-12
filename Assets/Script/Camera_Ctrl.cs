using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Ctrl : MonoBehaviour
{
    public GameObject m_MapObj;
    public GameObject m_PlayerObj;
    Vector3 cameraPosition = new Vector3(0, 0, -10);
    
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = m_PlayerObj.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void FixedUpdate()
    {
    	transform.position = Vector3.Lerp(transform.position, playerTransform.position + cameraPosition, 
                                  Time.deltaTime * cameraMoveSpeed);
    }
}
