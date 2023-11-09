using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //플레이어 이동 속도
    private float speed;
    //플레이어 회전 속도
    private float rotSpeed;
    //키보드의 horizontal 값을 저장할 변수0
    private float h;
    //키보드의 vertical 값을 저장할 변수
    private float v;
    //마우스 좌우 회전 값을 저장할 변수
    private float mouse_X;
    //처음 시작 위치
    private Vector3 originPos;
    //처음 회전 값
    private Quaternion originQua;
    void Start()
    {
        speed = 40;
        rotSpeed = 250;
        originPos = transform.position;
        originQua = transform.rotation;
    }


    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = 45;
        }
        else
        {
            speed = 40;
        }

        Move();
        if(Input.GetMouseButton(0))
        {
            Rotate();
        }
        
    }

    private void Move() 
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, -6, v);

        transform.Translate(dir * speed * Time.deltaTime);
    }

    private void Rotate()
    {
        mouse_X = Input.GetAxis("Mouse X") * rotSpeed * Time.deltaTime;
        transform.Rotate(0f, mouse_X, 0f);
    }

    private void OnTriggerEnter(Collider other) 
    {  
        if(other.tag == "StartPoint")
        {
           ObstacleManager.Instance.StartObstacleSystem();
        }

        if(other.tag == "Obstacle")
        {
            SoundManager.Instance.PlaySFX("Bump");
            GameManager.Instance.GameOver();
        }

        if(other.tag == "Ending")
        {
            SoundManager.Instance.PlaySFX("FallInWater");
            GameManager.Instance.GameClear();
        }
    }

    public void Die()
    {
        transform.position = originPos;
        transform.rotation = originQua;
    }
}
