using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane : MonoBehaviour
{
    //원래 위치
    private Vector3 originPos;
    //목표 위치
    private Vector3 targetPos;
    public Vector3 TargetPos
    {
        get
        {
            return targetPos;
        }
        set
        {
            targetPos = value;
        }
    }
    //이동 속도
    private float speed = 200;
    //이동가능한지
    private bool canMove;
    public bool CanMove
    {
        get
        {
            return canMove;
        }
        set
        {
            canMove = value;
        }
    }
    private void Start()
    {
        this.gameObject.SetActive(false);

        originPos = transform.position;   
        Invoke("Return", 3f);

    }
    
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, TargetPos, speed * Time.deltaTime);
    }

    private void Return()
    {
        transform.position = originPos;
        this.gameObject.SetActive(false);
        CanMove = false;
    }
}
