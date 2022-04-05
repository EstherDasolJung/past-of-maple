using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_Ctrl : MonoBehaviour
{
    KeyCode key;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(key) //아 스위치문 쓰고싶다...
        {
            case KeyCode.RightArrow:
                Debug.Log("오른쪽 화살표 입력");
                break;
        }
    }
}
