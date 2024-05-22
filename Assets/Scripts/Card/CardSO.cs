using UnityEngine;

namespace CardGame.Card
{

    [CreateAssetMenu(fileName = "CardScriptableObject", menuName = "ScriptableObjects/CardScriptableObject")]
    public class CardSO : ScriptableObject
    {
        public CardType CardTYPE;
        public CardNumber CardNumber;
        public Sprite OpenFace;
        public Sprite CloseFace;

    }


}

