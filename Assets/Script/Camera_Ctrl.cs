using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Ctrl : MonoBehaviour
{
    public GameObject m_MapObj;
    public GameObject m_PlayerObj;
    Vector3 cameraPosition = new Vector3(0, 0, -10);
    
    [HideInInspector] public Vector3 GroundMin = Vector3.zero;
    [HideInInspector] public Vector3 GroundMax = Vector3.zero;
    
    float m_LmtBdLeft = 0.0f;
    float m_LmtBdRight = 0.0f;
    float m_LmtBdTop = 0.0f;
    float m_LmtBdBottom = 0.0f;
    
    Vector3 m_ScMin = new Vector3(0.0f,0.0f,0.0f); //ScreenViewPort 좌측하단
    [HideInInspector] public Vector3 m_CamWMin = Vector3.zero;
    Vector3 m_ScMax = new Vector3(1.0f,1.0f,1.0f); //ScreenViewPort 우측하단
    [HideInInspector] public Vector3 m_CamWMax = Vector3.zero;
    Vector3 m_ScWdHalf = Vector3.zero;
    
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
