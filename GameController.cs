namespace lab_1
{
    class GameController
    {
        public Game getBasicGame()
        {
            return new BasicGame();
        }

        public Game getRankedGame()
        {
            return new RankedGame();
        }

        public Game getDoubleDownGame()
        {
            return new DoubleDownGame();
        }
        public Game getSafeGame()
        {
            return new SafeGame();
        }
        public Game getOneSideRatingGame()
        {
            return new OneSideRatingGame();
        }
    }
}
