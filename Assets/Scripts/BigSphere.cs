using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigSphere : MonoBehaviour
{

    private SphereCollider sphereCollider;
    [Header("Boundary Settings")]
    public float maxBallSpeed = 30f; // 限制小球最大速度
    public float wallThickness = 0.2f; // 内壁厚度

    // Start is called before the first frame update
    void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();

        if (!sphereCollider || !sphereCollider.isTrigger)
        {
            Debug.LogError("SphereBoundary: 需要在 SphereCollider 上勾选 'IsTrigger'!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void HandleBallReflections()
    {
        float sphereRadius = sphereCollider.radius * transform.lossyScale.x; // 计算真实世界坐标下的大球半径

        Collider[] colliders = Physics.OverlapSphere(transform.position, sphereRadius);
        
        foreach (Collider collider in colliders)
        {
            if (!collider.CompareTag("Ball")) continue;

            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if (rb == null) continue;

            Vector3 toCenter = transform.position - collider.transform.position;
            float distance = toCenter.magnitude;

            if (distance >= sphereRadius - wallThickness) // 当小球接触到内壁
            {
                Vector3 normal = toCenter.normalized;
                rb.velocity = Vector3.Reflect(rb.velocity, normal).normalized * Mathf.Min(rb.velocity.magnitude, maxBallSpeed);
                SmallBall smallBall = rb.gameObject.GetComponent<SmallBall>();
                smallBall.addNum();
                // 防止小球穿透大球边界
                collider.transform.position = transform.position - normal * (sphereRadius - wallThickness - 0.01f);
            }
            
        }
    }
    void FixedUpdate()
    {
        // 处理小球边界反弹
        HandleBallReflections();
       
    }

}
