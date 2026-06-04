<<<<<<< Updated upstream
using System;
using System.Collections.Generic;
using UnityEngine; // 자료 구조사용하려면 해당 네임스페이스를 사용해야 합니다
=======
using UnityEngine;
using System;
using System.Collections.Generic; 

>>>>>>> Stashed changes

namespace Study_DataStructure
{
    public class Study_Dictionary : MonoBehaviour
    {
        private void Start()
        {
            StudyDictionary();
        }

        private void StudyDictionary()
        {
<<<<<<< Updated upstream
            // # Dictionary<TKey, TValue>는 '이름표가 붙은 사물함' 또는 '전화번호부'
            // - 키(Key)와 값(Value)의 쌍(Pair) : 각 사물함에는(Value)에는 고유한
            //  이름표(Key)가 붙어 있습니다. 이 이름표를 통해서 원하는 사물함의
            //  내용물을 아주 빨리 찾을 수 있습니다.
            // - 고유한 키 : 모든 이름표(Key)는 서로 달라야합니다. 같은 이름표를
            //  가진 사물함은 절대 있을 수 없습니다. 하지만 사물함의 내용물(Value)
            //  은 중복 될 수 있습니다.
            // - 빠른 검색 : 이름표만 알면 원하는 사물함을 거의 즉시 찾을 수 있습니다
            //  순서대로 찾아볼 필요도 없습니다.

            // 1. Dictionary의 생성 : 키와 값의 타입을 알려주기
            // string(이름)을 Key로, int(나이)를 Value로 하는 Dictionary를 만들어
            // 봅시다. 이름은 'studentAge'

            Dictionary<string, int> studentAge; // 선언
            studentAge = new Dictionary<string, int>(); // 생성

            Debug.Log($"1. Dictionary의 생성 : 키와 값의 타입을 알려주기");
            Debug.Log($"학생 정보 개수 : {studentAge.Count}");
            Debug.Log("");

            // 2. 데이터 추가 : .Add(Key, Value)
            // studentAge에 학생 정보를 추가해봅시다
            studentAge.Add("김철수", 20);
            studentAge.Add("이영희", 21);
            studentAge.Add("박민수", 22);

            Debug.Log($"2. 데이터 추가 : 학생 3명 추가 후");
            Debug.Log($"학생 정보 개수 : {studentAge.Count}"); //이제 3개됨
            Debug.Log("");

            // 같은 Key로 데이터를 추가해보면?
            // => 같은 이름표를 가진 다른 값을 추가해본다면?
            // studentAge.Add("김철수", 25);
            // ArgumentException 오류가 발생합니다. Key는 고유해야 합니다
            // Dictionary의 Key는 Hash입니다. 그래고 고유함이 보장되어야 합니다

            // 3. 데이터 접근 : Key를 사용하거나, .TryGetValue()
            // 이름표(Key)를 통해 나이(Value)를 찾아봅시다.
            Debug.Log($"3. 데이터 접근 : 특정 학생의 나이 찾아보기");
            Debug.Log($"김철수의 나이 : {studentAge["김철수"]}"); // "20"
            Debug.Log($"박민수의 나이 : {studentAge["박민수"]}"); // "22"
            Debug.Log("");

            // 없는 Key로 데이터에 접근하면?
            //Debug.Log($"최수지의 나이 : {studentAge["최수지"]}");
            // KeyNotFoundException 오류가 발생합니다.

            // 키가 있는지 안전하게 확인하고 싶을때 .TryGetValue()를 사용합니다
            Debug.Log($"3.1 키 존재 여부 확인");
            if(studentAge.TryGetValue("이영희", out int yhAge))
            {
                Debug.Log($"이영희의 나이 : {yhAge}");
            }

            if (studentAge.TryGetValue("최수지", out int sjAge))
            {
                Debug.Log($"최수지의 나이 : {yhAge}");
            }
            else
            {
                Debug.Log($"최수지 학생 정보가 없습니다");
            }
            Debug.Log("");

            // 그냥 키가 있는지 여부만 조회하고 싶을때는?
            // 3.2 키 존재 여부 확인 : .Contains()
            Debug.Log($"이영희 학생 정보가 있나요? {studentAge.ContainsKey("이영희")}");
            Debug.Log($"최수지 학생 정보가 있나요? {studentAge.ContainsKey("최수지")}");
            Debug.Log("");

            // 4. 데이터 수정 : Key를 사용하여 접근 후 수정
            Debug.Log($"4. 데이터 수정 : 김철수");
            studentAge["김철수"] = 30;
            Debug.Log($"수정된 김철수의 나이 : {studentAge["김철수"]}");
            Debug.Log("");

            // 5. 데이터 삭제 : .Remove(Key)
            // 특정 키에 해당하는 데이터 쌍(Pair)을 삭제합니다
            Debug.Log($"5. 이영희 데이터 삭제 후");
            studentAge.Remove("이영희");
            Debug.Log($"남은 학생 정보 개수 : {studentAge.Count}");
            Debug.Log("");

            // 6. 모든 데이터 확인 : 반복문
            // Pair를 확인하는 법
            Debug.Log($"6. 모든 학생 정보 확인하기");

            foreach(KeyValuePair<string, int> entry in studentAge)
            {
                Debug.Log($"이름 : {entry.Key}, 나이 : {entry.Value}");
            }
            Debug.Log("");

            // 모든 키만 따로 확인하는 방법은? : .Keys
            foreach (string name in studentAge.Keys)
            {
                Debug.Log($"이름 : {name}");
            }
            Debug.Log("");

            // 모든 벨류만 따로 확인하는 방법은? : .Values
            foreach (int age in studentAge.Values)
            {
                Debug.Log($"나이 : {age}");
            }
            Debug.Log("");

            // # 정리 : Dictionary<TKey, TValue>는 언제 사용할까?
            // - 고유한 식발자(Key)로 특정 데이터(Value)를 빠르게 찾아야 할 때
            //  : 사용자 ID로 사용자 정보를 찾거나, 상품 코드로 상품 상세 정보
            //   를 찾을 때 매우 효율적입니다.
            // - 설정 값이나 환경 변수 등을 관리 할 때
            //  : "DatabaseConnectionString : Server = ..."과 같이 이름과 값의
            //   쌍으로 데이터를 관리해야 할 떄
            // - 데이터의 존재 여부를 빠르게 확인해야 할 때
=======
            // # Dictionary<TKey, TValue> 는 이름표가 붙은 사물함 혹은 전화번호부
            // -키(Key) 와 값 (Value) 쌍(Pair) : 각 사물함에는 (Value) 에는 고유한
            // 이름표가 있다. 이 이름표를 통해 원하는 사물함의 내용물을 아주 빨리 찾을수 있다
            // 고유한 키: 모든 이름표(Key)는 서로 달라야 한다. 같은 이름표를 가진 사물함은
            // 절대 있을수 없다. 

            Dictionary<string, int> studentAge;
            studentAge = new Dictionary<string, int>();

            //1. Dictionary 생성
            Debug.Log($"1. Dictionary의 생성 : 키와 값의 타입 알려주기");
            Debug.Log($"학생정보 개수: {studentAge.Count} ");
            Debug.Log($"");


            //2 데이터 추가: .Add(Key, Value)

            studentAge.Add("로건", 23);
            studentAge.Add("미미", 25);
            studentAge.Add("아른", 26);

            Debug.Log($"2. 학생 세명 추가");
            Debug.Log($"학생정보 개수: {studentAge.Count} ");
            Debug.Log($"");

            // 같은 Key로 데이터를 추가한다면 

            Debug.Log($"데이터의 접근");
            Debug.Log($"로건의 나이 : {studentAge["로건"]}");
            Debug.Log($"미미의 나이 : {studentAge["미미"]}");
            Debug.Log($"아른의 나이 : {studentAge["아른"]}");

            // 없는 key로 데이터에 접근하면 오류가 발생

            // 키가 있는지 안전하게 확인하고 싶을 때 .TryGetValue() 를 사용한다

            Debug.Log($"3.1 키 존재 여부");
            if (studentAge.TryGetValue("로건", out int lgAge))
            {
                Debug.Log($"로건의 나이: {lgAge}");
            }

            if (studentAge.TryGetValue("민근", out int mgAge))
            {
                Debug.Log($"민근의나이: {mgAge}");
            }

            else
            {
                Debug.Log($"학생 정보가 없습니다");
            }

            // 그냥 키가 존재하는 지 여부만 확인 하고 싶을 때
            // 3.2 키 존재 여부 확인: .Contains()

            Debug.Log($"로건의 정보가 있나요? {studentAge.ContainsKey("로건")}");

            // 4. 데이터 수정: Key 를 사용하여 접근 후 수정

            Debug.Log("4. 데이터 수정 : 미미");
            studentAge["미미"] = 30;
            Debug.Log($"수정된 미미의 나이: {studentAge["미미"]}");

            // 5. 데이터 삭제: .Remove(Key)
            // 특정키의 해당하는 데이터 쌍(Pair)를 삭제한다 

            Debug.Log("미미의 데이터 삭제 후");
            studentAge.Remove("미미");
            Debug.Log($"미미는 삭제되었나? {studentAge.Count}");


            //6. 모든 데이터 확인: 반복문
            // pair를 확인 하는 법  
            Debug.Log($"6. 모든 학생 정보 확인");
            foreach (KeyValuePair<string, int> entry in studentAge)
            {
                Debug.Log($"이름: {entry.Key}, 나이{entry.Value}");
            }
            Debug.Log("");

            // 모든키만 따로 확인 하는 법: .Keys

            foreach (string name in studentAge.Keys)
            {
                Debug.Log($"이름: {name}");                               
            }


            // 모든 밸류만 따로 확인 하는 법: .Keys

            foreach (int age in studentAge.Values)
            {
                Debug.Log($"나이: {age}");
            }

            // 정리: 언제 사용할까?
            // 고유한 식별자(key)로 특정 데이터(Value)를 빠르게 찾아야 할 때
            // : 사용자 ID로 사용자 정보를 찾거나, 상품 코드로 상품 상세 정보를 찾을 때 
            // 매우 효율적이다. 
            // 설정 값이나 환경 변수를 관히 할때
            // "DatabaseConeectionString: Server = ... 과 같이 이름과 같이 쌍으로 데이터를 관리할때
            // 
>>>>>>> Stashed changes
        }
    }
}
