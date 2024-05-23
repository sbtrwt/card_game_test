using CardGame.GameRoom;
using CardGame.UI.Dashboard;
using CardGame.Utilities;
using System.Collections.Generic;
using UnityEngine;

namespace CardGame.Main
{
    public class DashboardService : MonoBehaviour
    {
        private DashboardUIService dashBoardUIService;

        [SerializeField] private DashboardUISO dashboardUISO;
        [SerializeField] private Transform gameRoomMenuContainer;

        private void Start()
        {
            InitializeServices();
        }
        private void InitializeServices()
        {
            dashBoardUIService = new DashboardUIService(dashboardUISO, gameRoomMenuContainer);
        }
      
    }

}