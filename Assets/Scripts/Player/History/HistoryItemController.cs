using UnityEngine;

namespace CardGame.Player.History
{
    public class HistoryItemController
    {
        private HistoryItemView historyItemView;
        public HistoryItemController(HistoryItemView prefab, Transform container)
        {
            InitView(prefab, container);
        }
        private void InitView(HistoryItemView prefab, Transform container)
        {
            historyItemView = UnityEngine.Object.Instantiate(prefab, container);
            historyItemView.SetController(this);

        }

        public void Init(string gameName, string dateTime)
        {
            historyItemView.SetGameNameText(gameName);
            historyItemView.SetTimeText(dateTime);
        }
    }
}
