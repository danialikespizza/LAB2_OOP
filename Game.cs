namespace lab_1
{
    public abstract class Game
    {
        protected static int Id = 1234567890;

        protected Random random = new Random();

        public abstract string GameType { get; }

        protected abstract int GenerateRating();



        public virtual void PlayGame(GameAccount firstPlayer, GameAccount secondPlayer)
        {
            int rating = this.GenerateRating();
            int winnerSide = random.Next(0, 100);
            if (winnerSide >= 50)
            {
                firstPlayer.WinGame(secondPlayer, rating, Id, this.GameType);
                secondPlayer.LoseGame(firstPlayer, rating, Id, this.GameType);
            }
            else
            {
                firstPlayer.LoseGame(secondPlayer, rating, Id, this.GameType);
                secondPlayer.WinGame(firstPlayer, rating, Id, this.GameType);
            }
            Id++;
        }
    }

    public class BasicGame : Game
    {
        public override string GameType
        {
            get
            {
                return "Basic";
            }
        }

        protected override int GenerateRating()
        {
            return 0;
        }
    }

    public class RankedGame : Game
    {
        public override string GameType
        {
            get
            {
                return "Ranked";
            }
        }

        protected override int GenerateRating()
        {
            return random.Next(20, 30);
        }
    }

    public class DoubleDownGame : Game
    {
        public override string GameType
        {
            get
            {
                return "DoubleDown";
            }
        }

        protected override int GenerateRating()
        {
            return random.Next(20, 26);
        }

        public override void PlayGame(GameAccount firstPlayer, GameAccount secondPlayer)
        {
            int rating = this.GenerateRating();
            int winnerSide = random.Next(0, 100);
            if (winnerSide >= 50)
            {
                firstPlayer.WinGame(secondPlayer, rating * 2, Id, this.GameType);
                secondPlayer.LoseGame(firstPlayer, rating, Id, this.GameType);
            }
            else
            {
                firstPlayer.LoseGame(secondPlayer, rating * 2, Id, this.GameType);
                secondPlayer.WinGame(firstPlayer, rating, Id, this.GameType);
            }
            Id++;
        }

    }
    public class SafeGame : Game
    {
        public override string GameType
        {
            get
            {
                return "Safe";
            }
        }
        protected override int GenerateRating()
        {
            return 0;
        }

        public override void PlayGame(GameAccount firstPlayer, GameAccount secondPlayer)
        {
            int rating = this.GenerateRating();
            int winnerSide = random.Next(0, 100);
            if (winnerSide >= 50)
            {
                firstPlayer.WinGame(secondPlayer, rating, Id, this.GameType);
                secondPlayer.LoseGame(firstPlayer, rating, Id, this.GameType);
            }
            else
            {
                firstPlayer.LoseGame(secondPlayer, rating, Id, this.GameType);
                secondPlayer.WinGame(firstPlayer, rating, Id, this.GameType);
            }
            Id++;
        }

    }
    public class OneSideRatingGame : Game
    {
        public override string GameType
        {
            get
            {
                return "OneSideRating";
            }
        }
        protected override int GenerateRating()
        {
            return random.Next(20, 30);
        }
        public override void PlayGame(GameAccount firstPlayer, GameAccount secondPlayer)
        {
            int rating = this.GenerateRating();
            int winnerSide = random.Next(0, 100);
            if (winnerSide >= 50)
            {
                firstPlayer.WinGame(secondPlayer, rating, Id, this.GameType);
                secondPlayer.LoseGame(firstPlayer, 0, Id, this.GameType);
            }
            else
            {
                firstPlayer.LoseGame(secondPlayer, rating, Id, this.GameType);
                secondPlayer.WinGame(firstPlayer, 0, Id, this.GameType);
            }
            Id++;
        }
    }

}

