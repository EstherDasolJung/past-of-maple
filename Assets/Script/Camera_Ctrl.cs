using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Ctrl : MonoBehaviour
{
    public GameObject m_MapObj;
    public GameObject m_PlayerObj;
    Vector3 cameraPosition = new Vector3(0, 0, -10);
    Vector3 newPosition = Vector3.zero;


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

    float m_cameraMoveSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {        
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
        //--LimitMoveCam 카메라가 지형 밖으로 나가지 못하게 막기r
    }

    // Update is called once per frame
    void Update()
    {
        //--LimitMoveCam 카메라가 지형 밖으로 나가지 못하게 막기
        m_CamWMin = Camera.main.ViewportToWorldPoint(m_ScMin);//카메라 화면 좌측하단 코너의 월드좌표
        m_CamWMax = Camera.main.ViewportToWorldPoint(m_ScMax);//카메라 화면 우측상단 코너의 월드좌표

        m_ScWdHalf.x = (m_CamWMax.x - m_CamWMin.x) / 2.0f;
        m_ScWdHalf.z = (m_CamWMax.z - m_CamWMin.z) / 2.0f;

        m_LmtBdLeft = MapMin.x + 4.0f + m_ScWdHalf.x;
        m_LmtBdTop = MapMin.z + 4.0f + m_ScWdHalf.z;
        m_LmtBdRight = MapMax.x - 4.0f - m_ScWdHalf.x;
        m_LmtBdBottom = MapMin.z - 4.0f - m_ScWdHalf.z;

        if(m_LmtBdRight <= m_LmtBdLeft)
            newPosition.x = transform.position.x;
        else
        {
            if(newPosition.x < (float)m_LmtBdLeft)
                newPosition.x = (float)m_LmtBdLeft;
            
            if ((float)m_LmtBdRight < newPosition.x)
                newPosition.x = (float)m_LmtBdRight;
        }

        if (m_LmtBdRight <= m_LmtBdTop)
            newPosition.z = transform.position.z;
        else
        {
            if (newPosition.z < (float)m_LmtBdTop)
                newPosition.z = (float)m_LmtBdTop;

            if ((float)m_LmtBdBottom < newPosition.z)
                newPosition.z = (float)m_LmtBdBottom;
        }
        //--LimitMoveCam 카메라가 지형 밖으로 나가지 못하게 막기

        transform.position = newPosition;
    }
    
    void FixedUpdate()
    {
    	transform.position = Vector3.Lerp(transform.position, m_PlayerObj.transform.position + cameraPosition, 
                                  Time.deltaTime * m_cameraMoveSpeed);
    }
}
