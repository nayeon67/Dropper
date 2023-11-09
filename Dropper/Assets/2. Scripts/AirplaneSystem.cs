using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject[] airPlanes;
    [SerializeField]
    private Transform[] targetPos;
    void Awake()
    {
        //비행기 목표 위치 설정
        for(int i = 0; i < airPlanes.Length; i++)
        {
            Airplane airplaneScript = airPlanes[i].GetComponent<Airplane>();
            airplaneScript.TargetPos = targetPos[i].position;
        }
    }

    public IEnumerator AirplaneCoroutine(int start, int end, float delay = 0.0f)
    {
        for(int i = start; i < end; i++)
        {
            if(i >= airPlanes.Length)
            {
                break;
            }
            SoundManager.Instance.PlaySFX("Airplane");
            airPlanes[i].SetActive(true);
            yield return new WaitForSeconds(delay);
        }

        yield break;
    }
}
