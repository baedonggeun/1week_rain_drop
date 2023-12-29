using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class potion : MonoBehaviour
{
    int type;
    float size;
    int score;


    // Start is called before the first frame update
    void Start()
    {
        size = 0.6f;
        score = -3;

        float x = Random.Range(-2.7f, 2.7f); //입력된 두 값 사이의 임의의 범위의 숫자 생성
        float y = Random.Range(3f, 5f);

        //객체를 생성하면 기본적으로 붙어있는 default component
        //게임 오브젝트(객체)의 position, rotate, scale, parent-child 상태를 저장하기 위해 사용
        //위의 4개가 transform의 프로퍼티
        transform.position = new Vector3(x, y, 0); 
        
        transform.localScale = new Vector3(size, size, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //다른 콜라이더가 해당 콜라이더(이 스크립트를 가진 객체)의 공간에 들어오면 트리거가 발동되어 호출되는 함수
    //2D물리를 담당하기 때문에 OnCollisionEnter2D 처럼 뒤에 2D가 붙음
    //충돌 이벤트가 발생했을 때의 동작을 정의하기 위해 함수 내부 코드 작성
    void OnCollisionEnter2D(Collision2D coll) //콜라이더를 가진 객체 coll을 매개변수로 받음
    {
        if (coll.gameObject.tag == "ground")
        {
            //Debug.Log("ground!");
            //생성된 객체를 없애는 함수
            Destroy(gameObject); 
        }

        if (coll.gameObject.tag == "teemo")
        {
            Destroy(gameObject);
            GameManager.I.AddScore(score);
        }
    }
}
