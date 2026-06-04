using UnityEngine;
using UnityEngine.UI; // UI 기능을 사용하려면 추가해야한다

namespace Study_ProgressBar
{


    public class Study_ProgressBar : MonoBehaviour
    {

        // 직렬화 된 필드, 에디터에서 참조할수 있다.
        // C# 스크립트의 private (비공개) 변수나 프로퍼티를 유니티 에디터 인스펙터 창에 노출시켜,
        // 에디터상에서 직접 값을 변경하거나 게임 오브젝트 등의 컴포넌트를 할당할 수 있게 해준다

        // private 멤버변수 선언 앞에 [SeriallizeField] 키워드를 붙인다
        // 프로퍼티의 경우에 선언 앞에 [field: SerializeField] 를 붙인다 
        [field: SerializeField] public Image progressBarA { get; private set; }

        [field: SerializeField] public Image progressBarB { get; private set; }

        [field: SerializeField] public Image progressBarC { get; private set; }
        [field: SerializeField] public Image progressBarD { get; private set; }

        [field: SerializeField] public int MaxNumber { get; set; } = 100;
        [field: SerializeField] public int SumAmount { get; set; } = 1;
        private int currentNumber = 0;

        private Image[] progressBars;

        private void Start()
        {
            progressBars = new Image[]
            {progressBarA, progressBarB, progressBarC, progressBarD, };
        }

        private void Update()
        {
            UpdateProgressBar();
        }

        

        private void UpdateProgressBar()
        {   if (currentNumber >= MaxNumber) currentNumber = 0;

            currentNumber += SumAmount;
            float fillAmount = (float)currentNumber / MaxNumber;
            // int/ int 연산 시에는 앞에 float 를 붙여줘서 백분율 형태로 표현되도록 해야 한다

            // Image 배열을 돌면서 Image의 FillAmount 를 수정해 준다.

            for (int i = 0; i < progressBars.Length; ++i)
            {
                progressBars[i].fillAmount = fillAmount;
            }

            // 위의 for문은 아래와 똑같다. 
            // progresBarA.fillAmount = fillAmount
            // progresBarB.fillAmount = fillAmount
            // progresBarC.fillAmount = fillAmount
            // progresBarD.fillAmount = fillAmount

        }
    }

}