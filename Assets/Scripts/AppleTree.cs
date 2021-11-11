using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [SerializeField] private GameObject applePrefab;
    [SerializeField] private float secondBetweenAppleDrops = 1f;

    [SerializeField] private float speed = 1f;
    [SerializeField] private float leftAndRightEdge = 10f;
    [SerializeField] private float chanceTochangeDirections = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DropApple", 2);
    }
    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondBetweenAppleDrops);
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        if (pos.x < -leftAndRightEdge)
            speed = Mathf.Abs(speed);
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
    }

    private void FixedUpdate()
    {
        if(Random.value < chanceTochangeDirections)
        {
            speed *= -1;
        }
    }
}
