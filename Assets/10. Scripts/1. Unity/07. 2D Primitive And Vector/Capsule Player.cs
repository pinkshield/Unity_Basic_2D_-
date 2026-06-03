using UnityEngine;
using UnityEngine.InputSystem;

namespace Study.PrimitiveAndVector

{
    public class CapsulePlayer : MonoBehaviour
    {
        // 캡슐 플레이어
        // 1.화살표(좌,우) 를 이용한 이동 및 표현
        // 2.Space버튼 이용한 점프
        // 3. Platform 이라는 지형 위에 움직여야 한다.

        public enum State
        {
           Idle = 0, // 대기상태
           Left, // 왼쪽으로 가는 상태
           Right // 오른쪽으로 가는 상태
        }

        public GameObject[] SunGlasses;
        public State currentState = State.Idle;

        private Rigidbody2D rBody;
        private Collider2D col;

        private void Awake()
        {
            rBody = GetComponent<Rigidbody2D>();
            col = GetComponent<Collider2D>();
            
        }

        private void Update()
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

        }




        private void SetSunGlassState(State state)
        {
            if (currentState == state) return;
            // 상태가 전환될때만 아래 로직이 작동할수있도록 

            SunGlasses[(int)currentState].SetActive(false);
            SunGlasses[(int)state].SetActive(true);

            currentState = state;
        }

        public float speed = 2.0f;

        private void Move(Vector3 dir)
        {
            //transform.Translate(dir * speed * Time.deltaTime);
            Vector3 moveVector = dir * (speed * Time.deltaTime);
            rBody.MovePosition(moveVector);

        }


    }


}

