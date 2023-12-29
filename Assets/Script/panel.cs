using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //unity project 에서 버튼에 쥐어줄 함수
    //
    public void retry()
    {
        //싱글톤된 GameManager 인 I 내부의 retry 함수 호출
        GameManager.I.retry(); 
    }
}
