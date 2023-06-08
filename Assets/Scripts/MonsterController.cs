using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    private Transform throwPoint;
    public GameObject fireBallPrefab;
    private float timer = 0f;
    private float timeBetweenThrows = 3f;
    // Start is called before the first frame update
    void Start()
    {
        throwPoint = transform;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeBetweenThrows)
        {
            timer = 0f;
            Instantiate(fireBallPrefab, throwPoint.position, throwPoint.rotation);
        }
    }
}
