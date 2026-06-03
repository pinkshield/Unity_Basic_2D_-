using UnityEngine;

namespace Study.PrimitiveAndVector
{


    public class StudyLerp : MonoBehaviour       
    {
        

        public float speed = 1.0f;
        public float goalTime = 2.0f;
        public Vector3 goalPosition;
              

        private float currentTime = 0.0f;
        private Vector3 startPosition;
        private Vector3 resultPosition;
        private void Start()
        {
            startPosition = transform.position;
            goalPosition = transform.position + goalPosition;
        }

        private void Update()
        {
            // startPosition 에서 goalPosition 까지 보간을 이용해 움직이는 코드를 작성해봅시다
            if (true)
            {
                currentTime += Time.deltaTime;
                
                float progress = currentTime / goalTime;
                Vector3 currentPosition = startPosition + (goalPosition - startPosition) * progress;

                transform.position = currentPosition;
            }

            if (currentTime > goalTime)
            {
                
                currentTime = 0.0f;

                Vector3 temp = startPosition;
                startPosition = goalPosition;
                goalPosition = temp;
            }
            
        }

        private void MovingPlatform()
        {
            
            
            resultPosition = startPosition + (goalPosition - startPosition) * goalTime;
        }
    }
}