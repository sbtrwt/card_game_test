using CardGame.Events;
using CardGame.Main;
using CardGame.Utilities;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace CardGame.UI.Login
{
    public class LoginUIService : MonoBehaviour
    {
      
        [SerializeField] private Button lobbyButton;
        [SerializeField] private Button otpButton;
        [SerializeField] private TMP_InputField inputMobile;
        [SerializeField] private TMP_InputField inputOTP;
        [SerializeField] private TMP_Text messageText;
        [SerializeField] private Button okButton;
        [SerializeField] private GameObject messagePanel;
        private void Start()
        {
            lobbyButton.onClick.AddListener(OnClickLobbyButton);
            otpButton.onClick.AddListener(OnClickOTPButton);
            okButton.onClick.AddListener(OnClickOKButton);
        }

        private void OnClickLobbyButton()
        {
           // Debug.Log(inputOTP.text);
           if(String.IsNullOrEmpty(inputOTP.text.Trim()))
            {
                SetMessagePanel(true);
                SetMessageText("OTP is required!");
                return;
            }
            //Validate OTP

            SecurePlayerPrefs.SetString(GlobalConstant.KEY_TOKEN, "token1");
            //Jump to Dashbaord
            SceneManager.LoadScene(GlobalConstant.DASHBOARD_INDEX);
        }

        private void OnClickOTPButton()
        {
            if (String.IsNullOrEmpty(inputMobile.text.Trim()))
            {
                SetMessagePanel(true);
                SetMessageText("Mobile number is required!");
                return;
            }
            //Call API to get OTP


        }

        private void SetMessagePanel(bool isActive) => messagePanel.SetActive(isActive); 
        private void SetMessageText(string messageTextToSet) => messageText.text = messageTextToSet; 
        private void OnClickOKButton()
        {
            SetMessagePanel(false);

        }
    }
}