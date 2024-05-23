using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CardGame.Player.History
{
    public class HistoryItemView : MonoBehaviour
    {
        private HistoryItemController controller;
        [SerializeField] private TMP_Text gameNameText;
        [SerializeField] private TMP_Text timeText;
        public void SetController(HistoryItemController controller)
        {
            this.controller = controller;
        }

        public void SetGameNameText(string textToSet)
        {
            gameNameText.text = textToSet;
        }
        public void SetTimeText(string textToSet)
        {
            timeText.text = textToSet;
        }

    }
}
