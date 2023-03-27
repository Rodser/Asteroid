using UnityEngine;

namespace Rodlix.Asteroid
{
    public class Offscreen : MonoBehaviour
    {
		[SerializeField] private float _offset = 0.05f;

        private Vector3 _viewportPosition;
		private Camera _cameraView;
        private float _leftBorder;
        private float _rightBorder;
        private float _topBorder;
        private float _bottomBorder;

        private void Start()
        {
			_cameraView = Camera.main.GetComponent<Camera>();
			_leftBorder = 0f - _offset;
			_rightBorder = 1f + _offset;
			_topBorder = 0f - _offset;
			_bottomBorder = 1f + _offset;
        }

        private void Update()
        {
            _viewportPosition = _cameraView.WorldToViewportPoint(transform.position);

            CheckingPosition();
        }

        private void CheckingPosition()
        {
            if (_viewportPosition.x < _leftBorder)
            {
                _viewportPosition.x = _rightBorder;
                TranslatePosition();
            }
            else if (_viewportPosition.x > _rightBorder)
            {
                _viewportPosition.x = _leftBorder;
                TranslatePosition();
            }

            if (_viewportPosition.y < _topBorder)
            {
                _viewportPosition.y = _bottomBorder;
                TranslatePosition();
            }
            else if (_viewportPosition.y > _bottomBorder)
            {
                _viewportPosition.y = _topBorder;
                TranslatePosition();
            }
        }

        private void TranslatePosition()
        {
			transform.position = _cameraView.ViewportToWorldPoint(_viewportPosition);
        }
    }
}