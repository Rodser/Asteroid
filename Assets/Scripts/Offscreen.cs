using UnityEngine;

namespace Assets.Scripts
{
    public class Offscreen : MonoBehaviour
    {
		[SerializeField] private float offset = 0.05f;

        private Vector3 viewportPosition;
		private Camera cameraView;
        private float leftBorder;
        private float rightBorder;
        private float topBorder;
        private float bottomBorder;

        private void Start()
        {
			cameraView = Camera.main.GetComponent<Camera>();
			leftBorder = 0f - offset;
			rightBorder = 1f + offset;
			topBorder = 0f - offset;
			bottomBorder = 1f + offset;
        }
        private void Update()
        {
			viewportPosition = cameraView.WorldToViewportPoint(transform.position);

			if (viewportPosition.x < leftBorder)
			{
				viewportPosition.x = rightBorder;
				TranslatePosition();
			}
			else if (viewportPosition.x > rightBorder)
			{
				viewportPosition.x = leftBorder;
				TranslatePosition();
			}

			if (viewportPosition.y < topBorder)
			{
				viewportPosition.y = bottomBorder;
				TranslatePosition();
			}
			else if (viewportPosition.y > bottomBorder)
			{
				viewportPosition.y = topBorder;
				TranslatePosition();
			}
		}

        private void TranslatePosition()
        {
			transform.position = cameraView.ViewportToWorldPoint(viewportPosition);
        }
    }
}