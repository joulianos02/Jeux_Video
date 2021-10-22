using Microsoft.Xna.Framework;

namespace PacManDevoir01
{
    public class Animation
    {
        private readonly int[] _frames;
        private readonly float _interval;
        private double _timer = 0;
        private int _currentFrame = 0;

        public Animation(int[] frames, float interval)
        {
            _frames = frames;
            _interval = interval;
        }

        public int CurrentFrame => _frames[_currentFrame];

        public void Update(GameTime gameTime)
        {
            // no need to update if animation is only one frame
            if (_frames.Length > 1)
            {
                _timer += gameTime.ElapsedGameTime.TotalMilliseconds;

                if (_timer > _interval)
                {
                    _timer %= _interval;

                    _currentFrame++;

                    if (_currentFrame >= _frames.Length)
                    {
                        _currentFrame = 0;
                    }
                }
            }
        }
    }
}
