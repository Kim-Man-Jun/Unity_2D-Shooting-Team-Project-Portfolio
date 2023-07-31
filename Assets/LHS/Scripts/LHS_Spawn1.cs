using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//다섯 간격으로 발사하고 싶음
public class LHS_Spawn1 : MonoBehaviour
{
    //몬스터 생성 x 값
    public float ss = -2; //시작
    public float es = 2; //끝

    public float StartTime = 1; //시작
    public float SpawnTime = 10; //스폰 끝내는 시감

    [Header("단계별 몬스터")]
    public GameObject[] monster;

    private void Awake()
    {
        
    }

    void Start()
    {
        Invoke("Monster1", SpawnTime);
        
        GameObject player = GameObject.FindGameObjectWithTag("Player");

    }

    void Update()
    {
 
    }
    
    void Monster1()
    {
        //x 값 랜덤
        float x = Random.Range(ss, es);
        //x 값 랜덤값 y값 자기 자신 값
        Vector2 r = new Vector2(x, transform.position.y);
        
        for(int i = 0; i < 2; i ++)
        {
            //몬스터 생성
            Instantiate(monster[0],new Vector2(ss + i, transform.position.y), Quaternion.identity);
        }
    }
}
