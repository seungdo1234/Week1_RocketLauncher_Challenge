﻿using UnityEditor;
using UnityEngine;

public class AlertSystem : MonoBehaviour
{
    // fov가 45라면 45도 각도안에 있는 aesteriod를 인식할 수 있음.
    [SerializeField] private float fov = 45f;
    // radius가 10이라면 반지름 10 범위에서 aesteriod들을 인식할 수 있음.
    [SerializeField] private float radius = 10f;
    private float alertThreshold;

    private Animator animator;
    private static readonly int blinking = Animator.StringToHash("isBlinking");

    public Transform aestreiod;

    private void Start()
    {
        animator = GetComponent<Animator>();
        // FOV를 라디안으로 변환하고 코사인 값을 계산
        alertThreshold = Mathf.Cos(fov / 2 * Mathf.Deg2Rad);
    }

    private void Update()
    {
        CheckAlert();
    }

    private void CheckAlert()
    {
        // 주변 반경의 소행성들을 확인하고 이를 감지하여 Alert를 발생시킴(isBlinking -> true)
        Vector2 dir = aestreiod.position - transform.position;

        if (dir.magnitude <= radius)
        {
            float dot = Vector2.Dot(dir.normalized, transform.up);
            // float theta = Mathf.Acos(dot);
            // float degree = Mathf.Rad2Deg * theta;
            //
            // // 시야각 판별
            // if (degree <= fov / 2f)
            //     animator.SetBool(blinking, true);
            // else
            // {
            //     animator.SetBool(blinking, false);
            // }
            if (dot >= alertThreshold)
            {
                animator.SetBool(blinking, true);
            }
            else
            {
                animator.SetBool(blinking, false);
            }
        }


    }
    
}