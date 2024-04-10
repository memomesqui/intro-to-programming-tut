using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauch : MonoBehaviour
    public GameObject projectilePrefab;
    public Transform launchPoint;
public float shootTime = 0.3f;
public float shootCount;
{
    // Start is called before the first frame update
    void Start()
    {
        shootCount = shootTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))(&& shootCount = )
        {
            instant(projectile)Prefab.launchPoint.position, Quaternion.identity);
    shootCount = shootTime
        }
        shootCount -= shootTime.deltaTime;
    }
}
