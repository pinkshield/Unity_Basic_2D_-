using UnityEngine;  

public class Study_Physics : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        StudyPhysics();
    }

    public Transform rayTransform; 

    // Update is called once per frame
    private void StudyPhysics()
    {
        // Physics2D 주요 함수들
        // Cast: 특정 모형을 발사 하는 것
        //
        // Overlap: 특정 모형을 중심으로 영역 내를 감지하는 것 (덮어씌워 보는것)
        //

        // 모형
        // - Ray(광선), Circle (원) Box(사각형)
        Vector3 startPoint = rayTransform.position;
        Vector3 direction = Vector3.right;
        RaycastHit2D hit = Physics2D.Raycast(startPoint, direction);
        
            
    }

    private void OnDrawGizmos()
    {
        Vector3 startPoint = rayTransform.position;
        Vector3 direction = Vector3.right;
        RaycastHit2D hit = Physics2D.Raycast(startPoint, direction);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(startPoint, startPoint + direction + (startPoint * 100));

        if (hit.collider != null)
        {
            Debug.Log($"{hit.collider.name}에 적중");
        }
    }
}
