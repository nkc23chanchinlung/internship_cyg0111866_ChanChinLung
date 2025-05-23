using UnityEngine;

public class LeadController : MonoBehaviour
{
    [SerializeField]Transform homepos;
    Quaternion targetRotation;
    [SerializeField] Transform Playerpos;
    [SerializeField] float distance = 5f; // 目標までの距離

    private Quaternion fixedRotationOffset = Quaternion.Euler(90, 0, 90);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Playerpos = UnityEngine.GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=Playerpos.position+transform.forward * distance + Playerpos.up * distance;

        Vector3 direction = (homepos.position - transform.position).normalized;
        

        // 目標方向に基づいた回転を計算
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            targetRotation = Quaternion.Slerp(transform.rotation, lookRotation * fixedRotationOffset, Time.deltaTime * 2f);
            transform.rotation = targetRotation;
        }

        
    }
}