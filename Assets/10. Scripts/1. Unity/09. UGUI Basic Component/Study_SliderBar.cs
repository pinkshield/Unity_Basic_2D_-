using UnityEngine;
using UnityEngine.UI;
using TMPro;



namespace Study_SliderBar
{
    public class Study_SliderBar : MonoBehaviour
    {
        private Slider[] Sliders { get; set; }
        // privae 프로퍼티는 나만 접근하고 수정할수 있는 필드이다
        [field: SerializeField] TMP_Text[] sliderTexts { get; set; }
        // 직접 할당 하기 위한 방식 

        private void Awake()
        {
            Sliders = GetComponentsInChildren<Slider>();

        }

        private void Update()
        {
            //UpdateSliderText();
        }

        private void UpdateSliderText()
        {
            // 모든 슬라이더의 value 들을 표현한다

            for (int i = 0; i < sliderTexts.Length; ++i)
            {
                // 인덱스에 알맞는 슬라이더 객체를 가져온다
                Slider targetSlider = Sliders[i];
                // 인덱스에 알맞는 TMP_Text 객체를 가져온다
                TMP_Text targetText = sliderTexts[i];

                // targetText에 targetSlider 의 value 를 넣어준다 
                // 직접 할당 (수동적으로 대입) 
                //targetText.text = targetSlider.value.ToString();

                // 함수로 할당 (TMP 내부의 기능으로 작동) 더 효율적이다 
                //targetText.SetText(targetSlider.value.ToString("F2"));

                // "F2" 는 소숫점 자리 두자리까지 표기 하는 표현법 (Floats)

                

                // 이것 또한 수동적으로 대입하는 법
                string text = $"{targetSlider.value:F2}";

                targetText.SetText(text);
            }

        }

        
        // 매순간 바꾸는 것이 아니라, 수치가 변경 될때만 Update를 하는 법
        public void OnChangedValue(float value)
        {
            Debug.Log(value);
            UpdateSliderText();
        }

    }

}
