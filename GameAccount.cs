namespace lab_1
{
    public class GameAccount
    {
        public string UserName { get; set; }
        public virtual int CurrentRating
        {
            get
            {
                int rating = 1000;

                foreach (var game in allGames)
                {
                    rating += game.Rating;
                }

                return rating;
            }
        }
        public int GamesCount
        {
            get
            {
                return allGames.Count;
            }
        }

        protected List<GameRecord> allGames = new List<GameRecord>();

        public GameAccount(string userName)
        {
            UserName = userName;
        }

        public virtual void WinGame(GameAccount Opponent, int rating, int idOfTheMatch, string gameType)
        {
            if (rating < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rating), "Rating should be positive");
            }
            GameRecord game = new GameRecord(idOfTheMatch, this, Opponent, rating, "Win", gameType);
            allGames.Add(game);
        }

        public virtual void LoseGame(GameAccount Opponent, int rating, int idOfTheMatch, string gameType)
        {
            if (rating < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rating), "Rating should be positive");
            }
            if (CurrentRating - rating <= 0)
            {
                throw new InvalidOperationException("A Rating is bigger that a rating of the player");
            }
            GameRecord game = new GameRecord(idOfTheMatch, this, Opponent, rating, "Lose", gameType);
            allGames.Add(game);
        }

        public string GetStats()
        {
            var report = new System.Text.StringBuilder();
            report.AppendLine("Id\tType\tAgainst\t\tResult\tRating");
            foreach (var game in allGames)
            {
                report.AppendLine($"{game.GameId}\t{game.GameType}\t{game.SecondPlayer.UserName}\t{game.Result}\t{game.Rating}");
            }
            return report.ToString();
        }
    }

    public class DoubleLooserAccount : GameAccount
    {
        public DoubleLooserAccount(string userName) : base(userName)
        {
            UserName = userName;
        }

        public override void WinGame(GameAccount Opponent, int rating, int idOfTheMatch, string gameType)
        {
            if (rating < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rating), "Rating should be positive");
            }
            GameRecord game = new GameRecord(idOfTheMatch, this, Opponent, rating, "Win", gameType);
            allGames.Add(game);
        }

        public override void LoseGame(GameAccount Opponent, int rating, int idOfTheMatch, string gameType)
        {
            if (rating < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rating), "Rating should be positive");
            }
            if (CurrentRating - rating <= 0)
            {
                throw new InvalidOperationException("A Rating is bigger that a rating of the player");
            }
            GameRecord game = new GameRecord(idOfTheMatch, this, Opponent, rating*2, "Lose", gameType);
            allGames.Add(game);
        }
    }

    public class StreakGameAccount : GameAccount
    {
        public StreakGameAccount(string userName) : base(userName)
        {
            UserName = userName;
        }


        public override int CurrentRating
        {
            get
            {
                int rating = 1000;
                int streak = 0;
                foreach (var game in allGames)
                {
                    if (String.Equals(game.Result, "Win"))
                    {
                        streak++;
                    }
                    if (streak > 5)
                    {
                        rating += 5*streak;
                    }
                    rating += game.Rating;
                }

                return rating;
            }
        }
    }
}


