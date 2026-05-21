using UnityEngine;
using UnityEngine.InputSystem;

namespace Study.PrimitiveAndVector
{
    // ! 주의 사항: 현재는 2D 프로젝터를 진행하지만, 배울때는 3D를 배운다
    //              2D Vector는 3D Vector의 하위개념이라 Vector3 만 사용하면 2D도 자동적으로 사용 가능하다

    // #Vector
    // 3차원 공간에서 위치, 방향(or 크기)를 나타내는 사용되는 구조체
    // 마치, 지도에서 특정 지점의 자료를 표시하거나, 어떤 방향으로 어떤 속도만큼 이동하는지를 표현하는데에 사용된다
    // Vector는 게임 엔진의 모든 3D 계산의 기본이 되며,GameObject의 위치, 이동 방향, 속도, 힘 작용 반작용 등을 표현하는데 필수적으로 사용된다.
    // 벡터는 방향과 크기가 결합된 
    
    public class Study_Vector : MonoBehaviour
    {

        public void Update()
        {
            Vector(); 
        }

        public void Vector()
        {
            //Vector의 합연산 

            // Vector3 끼리의 합연산은 가능, 
            // 단일 값과의 합연산은 불가능
            // - 의미: 방향을 변환시키고자 할때

            // Vector 와 Vector 끼리의 곱셈은 불가능
            // 단일값과는 곱연산은 가능하다
            // 길이를 변환시키고자 할때

            if (Keyboard.current.qKey.wasPressedThisFrame)
            {
                transform.position += Vector3.one;
            }

            if (Keyboard.current.wKey.wasPressedThisFrame)
            {
                Vector3 angle = new Vector3(0, 0, 30);
                transform.rotation *= Quaternion.Euler(angle);
            }

            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                Vector3 applyVector = Vector3.one + Vector3.one;
                transform.localScale += Vector3.one;
            }

        }



    }

}