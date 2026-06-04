using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using System.Collections.Generic;

namespace Study_LoginUI
{
    public class Study_LoginUI : MonoBehaviour
    {
        [field: SerializeField]
        private TMP_InputField EmailField { get; set; }

        [field: SerializeField]
        private TMP_InputField PasswordField { get; set; }

        [field: SerializeField]
        private Button LoginButton { get; set; }

        private Selectable[] selectables;
        private int index = 0;

        private void Awake()
        {
            selectables = new Selectable[] { EmailField, PasswordField, LoginButton };

            // 실제 형태는 다르지만 공통의특징을 활용하는 방법 (추상화)
            // 각각의  필드는 다르지만, 세 필드는 공통적으로 Slectable 선택할수있는 것을 사용할 수 있다.
        }

        private void Update()
        {
            if (Keyboard.current.tabKey.wasPressedThisFrame)
            {
                int prevIndex = index;
                index += 1;
                if (index >= selectables.Length) index = 0;
                selectables[index].Select();
            }
            
        }




        public void OnEndEditEmail(string email)
        {
            index = 0;
            Debug.Log($"입력한 이메일은 : {email}");
        }
        public void OnEndEditPassword(string password)
        {
            index = 1;
            Debug.Log($"입력한 비밀번호는 : {password}");

        }

       
        public void OnClickLoginButton()
        {
            index = 2;
            Debug.Log($"로그인 버튼 클릭!");
        }

    }

    public class User
    {
        public string ID { get; private set; }
        public string Password { get; private set; }


        public User(string id, string password)
        {
            ID = id;
            Password = password;
        }

        public override string ToString()
        {
            return $"User: ID {ID}, Pw = {Password}";
        }

    }
}


