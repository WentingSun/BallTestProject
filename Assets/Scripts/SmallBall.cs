using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBall : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] int num;
    [SerializeField] int maxNum = 5;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void ApplyRandomForce() // 让 Editor 脚本调用
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }

        Vector3 randomForce = Random.insideUnitSphere * 10f; // 随机方向的力
        rb.AddForce(randomForce, ForceMode.Impulse);

        Debug.Log($"Applied force: {randomForce}");

    }

    public void addNum()
    {
        num++;
        Debug.Log("addNum");
        if (num >= maxNum)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball")) // 确保 Block 有正确的 Tag
        {
            // Debug.Log("小球撞到了方块，方块消失！");
            Destroy(collision.gameObject); // 销毁方块
        }
        Debug.Log(collision.gameObject.tag);
    }

    void Update()
    {
        // float speed = rb.velocity.magnitude;
        // Debug.Log("当前小球速度：" + speed);
    }




}
