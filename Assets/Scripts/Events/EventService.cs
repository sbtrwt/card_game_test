namespace CardGame.Events
{
    public class EventService
    {
        public EventController<int> OnCardDraw { get; private set; }
        public EventController<int> OnCardDrop { get; private set; }
        public EventService()
        {
            OnCardDraw = new EventController<int>();
            OnCardDrop = new EventController<int>();
        }

    }

}