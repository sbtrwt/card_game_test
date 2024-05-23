using CardGame.GameRoom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CardGame.UI.Dashboard
{
    public class DashboardUIService 
    {
        private Transform parentContainer;

        private DashboardUISO dashboardUISO;
        private List<GameRoomButtonController> allGameRoomButtons;
        private Button historyButton;
        private Button closeButton;
        private GameObject historyPanel;
        public DashboardUIService(DashboardUISO dashboardUISO, Transform container, Button historyButton, Button closeButton, GameObject historyPanel)
        {
            this.dashboardUISO = dashboardUISO;
            this.parentContainer = container;
            this.historyButton = historyButton;
            this.closeButton = closeButton;
            this.historyPanel = historyPanel;

            RenderAllMenuButton();
            this.historyButton.onClick.AddListener(OnClickHistory);
            this.closeButton.onClick.AddListener(OnClickCloseHistory);
        }

        private void RenderAllMenuButton() 
        {
            allGameRoomButtons = new List<GameRoomButtonController>();
            GameRoomButtonController gameRoomButtonController;
            foreach (var room in dashboardUISO.GameRoomsSO)
            {
                gameRoomButtonController = new GameRoomButtonController(dashboardUISO.GameRoomButtonViewPrefab, parentContainer);
                gameRoomButtonController.Init(room);
                allGameRoomButtons.Add(gameRoomButtonController);

            }
        }

        private void OnClickHistory() 
        {
            historyPanel.SetActive(true);
        }
        private void OnClickCloseHistory()
        {
            historyPanel.SetActive(false);
        }
    }

}