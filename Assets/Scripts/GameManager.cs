using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject smallBallPrefabs;
    // Start is called before the first frame update
    [SerializeField] Transform BigBall;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GenerateSmallBall()
    {
        Vector3 spawnPosition = BigBall.position;
        GameObject newBall = Instantiate(smallBallPrefabs, spawnPosition, Quaternion.identity);
        SmallBall smallBall =newBall.GetComponent<SmallBall>();
        smallBall.ApplyRandomForce();
    }

}
