namespace lab_1
{
    public class GameRecord
    {
        public int GameId { get; }
        public GameAccount FirstPlayer { get; }
        public GameAccount SecondPlayer { get; }
        public int Rating { get; }
        public string Result { get; }
        public string GameType { get; }

        public GameRecord(int id, GameAccount firstPlayer, GameAccount secondPlayer, int rating, string result, string gameType)
        {
            GameId = id;
            GameType = gameType;
            FirstPlayer = firstPlayer;
            SecondPlayer = secondPlayer;
            Result = result;
            Rating = rating;
        }
    }
}