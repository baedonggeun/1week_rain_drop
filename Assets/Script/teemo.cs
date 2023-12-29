using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rtan : MonoBehaviour
{
    float direction = 0.1f;
    float toward = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //마우스 클릭을 입력으로 받는 명령어
        if(Input.GetMouseButtonDown(0))
        {
            toward *= -1;
            direction *= -1;
        }

        // Debug.Log(transform.position.x);// <- x좌표를 log로 보여줌


        if (transform.position.x > 2.2f)
        {
            toward = -1.0f;
            direction = -0.1f;
        }
        else if(transform.position.x < -2.2f)
        {
            toward = 1.0f;
            direction = 0.1f;
        }

        transform.position += new Vector3(direction, 0, 0);
        transform.localScale = new Vector3(toward, 1f, 1f);
    }
}
