using CardGame.Main;
using CardGame.Utilities;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace CardGame.Player
{
    [Serializable]
    public class PlayerGameHistory
    {
        [SerializeField]
        public List<PlayerGameData> PlayerGameDataHistory;
        public PlayerGameHistory()
        {
            PlayerGameDataHistory = new List<PlayerGameData>();
        }

        public List<PlayerGameData> GetSavedHistory() 
        {
            string historyText = SecurePlayerPrefs.GetString(GlobalConstant.KEY_PLAYERDATAHISTORY);
            Debug.Log(historyText);
            PlayerGameHistory tempHistory = new PlayerGameHistory();
            if (!string.IsNullOrEmpty(historyText))
            { JsonUtility.FromJsonOverwrite(historyText, tempHistory); }
            return tempHistory.PlayerGameDataHistory;
        }

        public void AddSavedHistory(PlayerGameData newGameEntry)
        {
          
               PlayerGameDataHistory = GetSavedHistory();
            PlayerGameDataHistory.Add(newGameEntry);
            Debug.Log(JsonUtility.ToJson(this));
            SecurePlayerPrefs.SetString(GlobalConstant.KEY_PLAYERDATAHISTORY, JsonUtility.ToJson(this));
           
        }
    }
}
