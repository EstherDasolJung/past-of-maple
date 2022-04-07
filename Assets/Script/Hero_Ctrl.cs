using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_Ctrl : MonoBehaviour
{
    //https://blog.naver.com/dusdkel/222532923128
    static private readonly KeyCode[] keyCodes = System.Enum.GetValues(typeof(KeyCode))
        .Cast<KeyCode>().Where(k => ((int)k < (int)KeyCode.Mouse0)).ToArray();
 
    static public KeyCode? GetCurrentKeyDown()
    {
        for (int i = 0; i < keyCodes.Length; i++)
        {
            if (Input.GetKeyDown(keyCodes[i]))
            {
                return keyCodes[i];
            }
        }
        return null;
    }

    Vector2 HeroPoint = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        HeroPoint = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            switch (GetKey.GetCurrentKeyDown())
            {
                case KeyCode.LeftArrow :
                    Debug.Log("왼쪽 화살표 클릭");
                    HeroPoint.x -= 1.0f * Time.deltaTime;
                    break;
                    
                case KeyCode.RightArrow :
                    Debug.Log("오른쪽 화살표 클릭");
                    HeroPoint.x += 1.0f * Time.deltaTime;
                    break;
                    
                case KeyCode.UpArrow :
                    Debug.Log("위쪽 화살표 클릭");
                    FloorUp();
                    break;
                    
                case KeyCode.DownArrow :
                    Debug.Log("아래쪽 화살표 클릭");
                    FloorDown();
                    break;
                    
                case KeyCode.LeftControl || KeyCode.RightControl :
                    Debug.Log("컨트롤 클릭");
                    Jump();
                    break;
                    
                default :
                    //state(idle);
                    break;
            }
        }
        
        /*
        if(Input.GetKey(KeyCode.LeftArrow))
            KeyBoardMove(1);
        else if(Input.GetKey(KeyCode.RightArrow))
            KeyBoardMove(2);
        else if(Input.GetKey(KeyCode.UpArrow))
            KeyBoardMove(3);
        else if(Input.GetKey(KeyCode.DownArrow))
            KeyBoardMove(4);
        else if(Input.GetKey(KeyCode.LeftControl))
            KeyBoardMove(5);
        else if (Input.GetKey(KeyCode.RightControl))
            KeyBoardMove(5);        
        */
    }
    /*
    void KeyBoardMove(int key)
    {
        switch(key)
        {
            case 1:
                Debug.Log("왼쪽 화살표 클릭");
                HeroPoint.x -= 1.0f * Time.deltaTime;
                break;
                
            case 2:
                Debug.Log("오른쪽 화살표 클릭");
                HeroPoint.x += 1.0f * Time.deltaTime;
                break;
                
            case 3:
                Debug.Log("위쪽 화살표 클릭");
                FloorUp();
                break;
                
            case 4:
                Debug.Log("아래쪽 화살표 클릭");
                FloorDown();
                break;
            
            case 5:
                Debug.Log("컨트롤 클릭");
                Jump();
                break;
                
            default:
                //state(idle);
                break;
            
        }
    }
    */
    void FloorUp()
    {
        //if(Uprope = false)
        //    return;

        HeroPoint.y += 1.0f * Time.deltaTime;
    }
    
    void FloorDown()
    {
        //if(Downrope = false)
        //    return;

        HeroPoint.y -= 1.0f * Time.deltaTime;
    }
    
    void Jump()
    {
        if(transform.position.y > 10.0f)
            return;
            
        //점프 구현하기 https://angliss.tistory.com/292?category=861686
    }
}
