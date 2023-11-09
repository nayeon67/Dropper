using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    private static ObstacleManager instance;
    public static ObstacleManager Instance
    {
        get
        {
            if(instance == null)
            {
                return null;
            }

            return instance;
        }
    }
    //몇번째 장애물인지
    private int count  = 0;
    public int Count
    {
        get 
        {
            return count;
        }
        set
        {
            count = value;
        }
    }
    private AirplaneSystem airplaneSystem;

    private void Awake() 
    {
        if (Instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start() 
    {

    }
   
   public void StartObstacleSystem()
   {
        airplaneSystem = FindObjectOfType<AirplaneSystem>();
        if(count == 0)
        {
            StartCoroutine(airplaneSystem.AirplaneCoroutine(0, 2));
        }

        else if(count == 1)
        {
            StartCoroutine(airplaneSystem.AirplaneCoroutine(2, 5, 0.5f));
        }

        else if(count == 2)
        {
            StartCoroutine(airplaneSystem.AirplaneCoroutine(5, 8));
        }


        count++;
   }
}
