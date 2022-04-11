using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Hero_Ctrl : MonoBehaviour
{
    float m_speed = 10.0f;
    float m_JumpForce = 5.0f;
    bool m_Jump = false;

    //https://blog.naver.com/dusdkel/222532923128
    static private readonly KeyCode[] keyCodes = System.Enum.GetValues(typeof(KeyCode)).Cast<KeyCode>().Where(k => ((int)k < (int)KeyCode.Mouse0)).ToArray();
 
    static public KeyCode? GetCurrentKey()
    {
        for (int i = 0; i < keyCodes.Length; i++)
        {
            if (Input.GetKey(keyCodes[i]))
            {
                return keyCodes[i];
            }
        }
        return null;
    }

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            switch (GetCurrentKey())
            {
                case KeyCode.LeftArrow :
                    Debug.Log("왼쪽 화살표 클릭");
                    this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
                    transform.position += Vector3.left * m_speed * Time.deltaTime;
                    
                    //transform.Translate(new Vector3(Speed * Time.deltatime,0,0));
                    break;
                    
                case KeyCode.RightArrow :
                    Debug.Log("오른쪽 화살표 클릭");
                    this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
                    transform.position += Vector3.right * m_speed * Time.deltaTime;
                    
                    //transform.Translate(new Vector3(-Speed * Time.deltatime,0,0));
                    break;
                    
                case KeyCode.UpArrow :
                    Debug.Log("위쪽 화살표 클릭");
                    //if(Uprope = false)
                    //    break;
                    transform.position += Vector3.up * m_speed * Time.deltaTime;
                    //transform.Translate(new Vector3(0,Speed * Time.deltatime,0));
                    break;
                    
                case KeyCode.DownArrow :
                    Debug.Log("아래쪽 화살표 클릭");
                    //if(Downrope = false)
                    //    break;
                    transform.position += Vector3.down * Time.deltaTime;
                    //transform.Translate(new Vector3(0,-Speed * Time.deltatime,0));
                    break;

                case KeyCode.LeftControl:
                    Debug.Log("컨트롤 클릭");
                    //if(transform.position.y > 10.0f  ) //점프 제한 조건 : 일정 높이 이상 점프 불가
                    //    break;
                    if(m_Jump != true)
                    {
                        Rigidbody2D rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
                        GetComponent<Rigidbody2D>().AddForce(Vector3.up * m_JumpForce * Time.deltaTime);
                        //점프 구현하기 https://angliss.tistory.com/292?category=861686

                        m_Jump = true;
                    }
                    break;
                    
                default :
                    //state(idle);
                    break;
                    
                    //추가해야 할것 : 바닥에 캐릭터가 닿기 전에 이동 제한(예 : 점프시 재 점프등)
            }
        }      
    }
    private void OnCollisionEnter2D (Collision2D collision)
    {
        m_Jump = false;
    }
}
