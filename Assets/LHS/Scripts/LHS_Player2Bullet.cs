using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LHS_Player2Bullet : MonoBehaviour
{
    //플레이어 위치에서 길이만큼 발사
    //닿으면 다시 나한테 돌아오기 Raycast Linecast 사용?
    //각도 설정은?

    // 다시 돌아올 타겟
    public Transform target;
    // 이동 속도
    public float speed = 5f;
    // 얘는 왜?
    public float returnSpeedMultiplier = 2f;
    // 돌아옴
    public static bool isReturning = false;
    //간격 위치 저장
    private Vector3 initialPosition;

    public float moveDistance = 5f; //이동할 거리

    private void Start()
    {
        //내 원래 위치 저장
        initialPosition = transform.position;

        MoveRandomDirection();
    }

    void MoveRandomDirection()
    {
        //랜덤한 방향을 생성
        Vector3 randomDrection = Random.insideUnitSphere.normalized;
        //randomDrection.y = 0f; //y축 이동하지 않도록 설정(수평이동?)

        Vector3 targetPosition = transform.position + randomDrection * moveDistance;

        //목표위치로 이동
        transform.position = targetPosition;
    }
    
    private void Update()
    {
        //내 위치에서 랜덤한 방향으로 () 길이만큼 갔다가 다시 온다.
        if(isReturning)
        {
            float step = speed * Time.deltaTime;

            //나보다 3거리에 있는 범위에서 랜덤으로 간다면?
            float x = 1;
            float y = -1;
            Vector3 dir = new Vector3(x, y, 0);
            
            //내위치에서 랜덤한 방향으로 () 거리만큼


            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }

        /*if (!isReturning)
        {
            // Lerp 또는 Smooth Damp를 사용하여 대상으로 이동
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            //transform.position = Vector3.Lerp(transform.position, target.position, 1);

            // 목표에 도달했는지 확인
            if (transform.position == target.position)
            {
                isReturning = true;
            }
        }

        else
        {
            // 속도를 높여 초기 위치
            float step = speed * returnSpeedMultiplier * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, initialPosition, step);

            if (transform.position == initialPosition)
            {
                // 다시 설정
                isReturning = false;
            }
        }*/
    }
}
