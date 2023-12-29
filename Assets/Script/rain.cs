using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rain : MonoBehaviour
{
    int type;
    float size;
    int score;


    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(-2.7f, 2.7f);
        float y = Random.Range(3f, 5f);
        transform.position = new Vector3(x, y, 0);

        type = Random.Range(1, 4); //1 이상 4 미만의 범위에서 임의의 숫자를 생성하는 명령어

        switch (type)
        {
            case 1:
                size = 1.3f;
                score = 1;

                //참고 : https://docs.unity3d.com/kr/2021.3/Manual/UIE-Transitioning-From-UGUI.html
                //참고 : https://codeposting.tistory.com/entry/Unity-%EC%9C%A0%EB%8B%88%ED%8B%B0-%EC%BB%A8%ED%8F%AC%EB%84%8C%ED%8A%B8-%EC%B0%BE%EA%B8%B0-GetComponent-%EC%84%B1%EB%8A%A5-gameobject
                //계층 구조에서 component를 찾는 헬퍼 함수
                //<>의 값은 해당 component를 가지고 있는 객체
                //()배열로 반환 <- color의 경우 4개의 값을 가지기 때문에 배열로 값을 가져옴
                //.color <>에 적힌 객체 내부에 있는 component 중 color 를 가져옴
                //객체 spriteRenderer에 포함된 color component 를 new Color로 수정하는 코드
                GetComponent<SpriteRenderer>().color = new Color(100 / 255f, 100 / 255f, 255 / 255f, 255 / 255f);
                break;
            case 2:
                size = 1.0f;
                score = 2;
                GetComponent<SpriteRenderer>().color = new Color(130 / 255f, 130 / 255f, 255 / 255f, 255 / 255f);
                break;
            case 3:
                size = 0.6f;
                score = 3;
                GetComponent<SpriteRenderer>().color = new Color(160 / 255f, 160 / 255f, 255 / 255f, 255 / 255f);
                break;
        }

        transform.localScale = new Vector3(size, size, 0);
        //GetComponent<SpriteRenderer>().color = new Color(100 / 255f, 100 / 255f, 255 / 255f, 255 / 255f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "ground")
        {
            //Debug.Log("ground!");
            Destroy(gameObject);
        }

        if(coll.gameObject.tag == "teemo")
        {
            Destroy(gameObject);
            GameManager.I.AddScore(score);
        }
    }

}


