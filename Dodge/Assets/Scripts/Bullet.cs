using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody bulletRigidbody;

    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>(); // Rigidbody 컴포넌트를 가져옴
        bulletRigidbody.velocity = transform.forward * speed; // 초당 speed만큼 앞쪽으로 이동

        Destroy(gameObject, 3f); // 3초 뒤에 자신의 게임오브젝트 파괴
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();

            if(playerController != null) 
            {
                playerController.Die();
            }
        }
    }
}
