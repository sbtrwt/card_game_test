using CardGame.GameRoom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CardGame.UI.Dashboard
{
    public class DashboardUIService 
    {
        private Transform parentContainer;

        private DashboardUISO dashboardUISO;
        private List<GameRoomButtonController> allGameRoomButtons;
       
        public DashboardUIService(DashboardUISO dashboardUISO, Transform container)
        {
            this.dashboardUISO = dashboardUISO;
            this.parentContainer = container;
            

            RenderAllMenuButton();
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
    }

}