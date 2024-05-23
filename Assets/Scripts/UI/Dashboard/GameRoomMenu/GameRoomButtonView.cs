using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CardGame.UI.Dashboard
{
    public class GameRoomButtonView : MonoBehaviour
    {
        private GameRoomButtonController controller;

        [SerializeField] private Button roomButton;
        [SerializeField] private TMP_Text buttonText;
        private void Start()
        {
            roomButton.onClick.AddListener(OnRoomButtonClick);
        }
        public void SetController(GameRoomButtonController controller)
        {
            this.controller = controller;

        }

        private void OnRoomButtonClick() 
        {
            controller.OnRoomButtonClick();
        }

        public void SetButtonText(string buttonTextToSet)
        {
            buttonText.text = buttonTextToSet;
        }
    }
}
