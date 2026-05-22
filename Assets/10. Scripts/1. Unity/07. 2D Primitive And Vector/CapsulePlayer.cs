using UnityEngine;
using UnityEngine.InputSystem;

namespace Study.PrimitiveAndVector
{
    public class CapsulePlayer_ : MonoBehaviour
    {
        // 캡슐 플레이어
        // 1. 화살표(좌,우)를 이용한 이동 및 표현
        // 2. Space버튼 이용한 점프
        // 3. Platform이라는 지형 위에서 움직여야 합니다.

        public enum State
        {
            Idle = 0,   // 대기 상태
            Left,       // 왼쪽으로 가는 상태
            Right       // 오른쪽으로 가는 상태
        }

        public GameObject[] SunGlasses;
        private State currentState = State.Idle;
        public float speed = 2.0f;

        private Rigidbody2D rBody;
        private Collider2D col;
        

        private void Awake()
        {
            rBody = GetComponent<Rigidbody2D>();
            col = GetComponent<Collider2D>();
        }

        private void FixedUpdate()
        {
            if (Keyboard.current.leftArrowKey.isPressed)
            {
                SetSunGlassState(State.Left);
                Move(Vector3.left);
            }
            else if (Keyboard.current.rightArrowKey.isPressed)
            {
                SetSunGlassState(State.Right);
                Move(Vector3.right);
            }
            else
            {
                SetSunGlassState(State.Idle);
            }

            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                Jump();
            }

            
        }

        private void SetSunGlassState(State state)
        {
            if (currentState == state) return;
            // 상태가 전환될때만 아래 로직이 실행되도록
            // 예외처리를 합니다.

            SunGlasses[(int)currentState].SetActive(false);
            SunGlasses[(int)state].SetActive(true);
            currentState = state;
        }

        private void Move(Vector3 dir)
        {
            //transform.Translate(dir * speed * Time.deltaTime);
            //transform.position += (dir * (speed * Time.deltaTime));
            // Vector3             Vector3 * (float: distance)

            // 이번 프레임에 움직일 벡터의 크기 : 이번 프레임 이동량
            Vector3 moveVector = dir * (speed * Time.fixedDeltaTime);

            // 내 위치와 이동량을 더해줍니다
            rBody.MovePosition(transform.position + moveVector);
        }



        private void Jump()
        {

        }

        [Header("Settings")]
        public float gravity = -9.81f; // 현실세계 중력 가속도
        public float jumpPower = 8.0f;
        public int maxJumpCount = 2;

        private float verticalVelocity = 0.0f;
        private bool isGrounded = false;

        private void ApplyGravity()
        {
            const float groundStickSpeed = -2.0f;

            if (isGrounded && verticalVelocity <= 0)
            {
                verticalVelocity += groundStickSpeed;
            }
            else; 
            
        }
    }        
}