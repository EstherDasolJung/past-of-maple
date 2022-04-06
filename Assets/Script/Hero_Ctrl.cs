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
        if(Input.GetKey(KeyCode.LeftArrow))
            KeyBoardMove(1);
        else if(Input.GetKey(KeyCode.RightArrow))
            KeyBoardMove(2);
        else if(Input.GetKey(KeyCode.UpArrow))
            KeyBoardMove(3);
        else if(Input.GetKey(KeyCode.DownArrow))
            KeyBoardMove(4);
        else if(Input.GetKey(KeyCode.Ctrl))
            KeyBoardMove(5);
            
        switch(key) //아 스위치문 쓰고싶다...
        {
            case KeyCode.RightArrow:
                Debug.Log("오른쪽 화살표 입력");
                break;
        }
    }
    
    void KeyBoardMove(int key)
    {
        switch(key)
        {
            case 1:
                transform.position.x -= 1.0f * Time.deltaTime;
                break;
                
            case 2:
                transform.position.x += 1.0f * Time.deltaTime;
                break;
                
            case 3:
                FloorUp();
                break;
                
            case 4:
                FloorDown();
                break;
            
            case 5:
                Jump();
                break;
                
            default:
                state(idle);
                break;
            
        }
    }
    
    void FloorUp()
    {
        if(Uprope = false)
            return;
        
        transform.position.y += 1.0f * Time.deltaTime;
    }
    
    void FloorDown()
    {
        if(Downrope = false)
            return;
        
        transform.position.y -= 1.0f * Time.deltaTime;
    }
    
    void Jump()
    {
        if(transform.position.y > 10.0f)
            return;
            
        //점프 구현하기 *https://angliss.tistory.com/292?category=861686
    }
}
