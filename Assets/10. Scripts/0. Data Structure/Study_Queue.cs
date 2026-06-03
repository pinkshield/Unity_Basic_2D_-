using UnityEngine;
using System.Collections.Generic;

namespace Study_DataStructure
{

    public class Study_Queue : MonoBehaviour
    {
        void Start()
        {
            Queue();
        }

        private void Queue()
        {
            // 1. Queue의 생성: 어떤 종류의 데이터를 담을지 알려주기
            // string(문자열)만 담을수 있는 Queue 를 만들어보자 이름은 "waitingLine"    

            Queue<string> waitingLine; // Queue의 선언
            waitingLine = new Queue<string>(); //Queue 의 생성

            Debug.Log("1. Queue 의 생성 직후");
            Debug.Log($"대기열의 사람수: {waitingLine.Count}");
            Debug.Log("");

            // 2. 데이터 추가: .Enqueue()
            waitingLine.Enqueue("앨리");
            waitingLine.Enqueue("바비");
            waitingLine.Enqueue("찰스");

            Debug.Log("2. Queue 의 데이터 추가 후");
            Debug.Log($"대기열의 사람수: {waitingLine.Count}");
            Debug.Log("");

            //string log = waitingLine[0]; // 배열이나 인덱스를 사용할수 없다.

            // 3. 데이터 확인: .Peek()
            // 데이터를 꺼내지 않고, 줄의 맨앞의 어떤데이터가 있는지 살짝 확인한다

            Debug.Log("3. 줄 맨 앞의 사람 확인하기");
            Debug.Log($"줄의 맨 앞의 사람: {waitingLine.Peek()}");
            Debug.Log($"대기열의 사람수: {waitingLine.Count}");
            Debug.Log("");

            // 4. 데이터 꺼내기: Dequeue()
            // 줄 맨 앞 데이터를 꺼낸다. 꺼낸 데이터는 Queue 에서 사라진다

            Debug.Log("4. 대기열에 데잍 꺼내기");
            string servedPerson = waitingLine.Dequeue();
            Debug.Log($"{servedPerson}"); // 꺼내기만 하면 자동으로 사라진다.
            Debug.Log($"대기열의 사람수: {waitingLine.Count}");
            Debug.Log("");

            // 큐에 더 꺼낼 것이 없을 때는? 
            waitingLine.Dequeue();

            waitingLine.Enqueue("심슨");
            waitingLine.Enqueue("존");
            waitingLine.Enqueue("피터");

            // 5. 모든 데이터를 꺼내지 않고 확인해야 할 경우에는

            Debug.Log($"대기열의 모든 사람 확인하기");
            foreach (string person in waitingLine)
            {
                Debug.Log($"{person}");
            }

            //정리: Queue<T> 언제 사용할까?
            // 1. 작업처리 순서가 중요한 경우
            // - 운영체제의 작업 스케쥴링 : CPU 가 처리해야할 작업들이 Queue에 쌓여 순서대로 처리된다
            // - 프린터의 인쇄 대기열: 먼저 인쇄 요처을 보낸 문서가 먼저 인쇄
            // - 온라인게임의 접속 대기열 : 먼저 접속을 대기한 유저부터 게임에 입장

            // 2. 버퍼링 (Buffering) 
            // - 데이터를 일시적으로 저장하고 순서대로 처리해야 할 때 사용 된다
            // - 예를 들어, 네트워크에서 데이털르 수신할 떄

            // 3. 너비 우선 탐색 **(BFs - Breadth-First Search)
            // - 그래프나 트리를 탐색할 때, 현재 노드와 연결된 모든 노드를 먼저 방문하고 다음 깊이로 넘어가는 BFS 
            //  알고리즘에서 사용한다
            

        }

    }


}
