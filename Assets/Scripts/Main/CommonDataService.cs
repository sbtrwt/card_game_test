using CardGame.GameRoom;
using CardGame.UI.Dashboard;
using CardGame.Utilities;
using System.Collections.Generic;
using UnityEngine;
namespace CardGame.Main
{
    public class CommonDataService : GenericMonoSingleton<CommonDataService>
    {
        public GameRoomSO SelectedGameRoom;
        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(this);
        }
    }
}
