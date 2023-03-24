namespace Rodlix.Asteroid
{
    internal class UFOBuilder : IBuilder
    {
        private UFOData _ufoData;

        public UFOBuilder(UFOData ufoData)
        {
            _ufoData = ufoData;
        }

        public void Build()
        {
        }
    }
}