using UnityEngine;

namespace Rodlix.Asteroid
{
    internal class WingBuilder
    {
        private WingConfig _wingConfig;

        public WingBuilder(WingConfig wingConfig)
        {
            _wingConfig = wingConfig;
        }

        internal Wing Build(Transform parentTransform)
        {
            var wing = Object.Instantiate(_wingConfig.Wing, parentTransform);
            return wing;
        }
    }
}