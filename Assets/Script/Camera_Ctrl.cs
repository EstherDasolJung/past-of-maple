using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Ctrl : MonoBehaviour
{
    public GameObject m_MapObj;
    public GameObject m_PlayerObj;
    Vector3 cameraPosition = new Vector3(0, 0, -10);
    
    [HideInInspector] public Vector3 MapMin = Vector3.zero;
    [HideInInspector] public Vector3 MapMax = Vector3.zero;
    
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
        
        //--LimitMoveCam 카메라가 지형 밖으로 나가지 못하게 막기
        Vector3 a_MapHalfSize = Vector3.zero;
        
        a_MapHalfSize.x = m_MapObj.transform.localScale.x/2.0f;
        a_MapHalfSize.y = m_MapObj.transform.localScale.y/2.0f;
        a_MapHalfSize.z = m_MapObj.transform.localScale.z/2.0f;
        
        //좌측하단 *전체지형의 꼭지점 구하기*
        MapMin.x = m_MapObj.transform.position.x - a_MapHalfSize.x;
        MapMin.y = m_MapObj.transform.position.y - a_MapHalfSize.y;
        MapMin.z = m_MapObj.transform.position.z - a_MapHalfSize.z;
        
        //우측상단 *전체지형의 꼭지점 구하기*
        MapMax.x = m_MapObj.transform.position.x + a_MapHalfSize.x;
        MapMax.y = m_MapObj.transform.position.y + a_MapHalfSize.y;
        MapMax.z = m_MapObj.transform.position.z + a_MapHalfSize.z;
        //--LimitMoveCam 카메라가 지형 밖으로 나가지 못하게 막기
    }

    // Update is called once per frame
    void Update()
    {
        //--LimitMoveCam 카메라가 지형 밖으로 나가지 못하게 막기
        
        
        //--LimitMoveCam 카메라가 지형 밖으로 나가지 못하게 막기
    }
    
    void FixedUpdate()
    {
    	transform.position = Vector3.Lerp(transform.position, playerTransform.position + cameraPosition, 
                                  Time.deltaTime * cameraMoveSpeed);
    }
}
