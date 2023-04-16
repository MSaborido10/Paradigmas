using System.Collections.Generic;

namespace Game
{
    public class Animation
    {
        private string id;
        private bool isLoopEnabled;
        private List<Texture> frames;
        private float speed = 0;
        private float currentAnimationTime = 0;
        private int currentFrameIndex = 0;

        public string Id => id;
        public Texture CurrentFrame => frames[currentFrameIndex];

        public Animation(string id, List<Texture> frames, float speed, bool isLoopEnabled)
        {
            this.id = id;
            this.frames = frames;
            this.speed = speed;
            this.isLoopEnabled = isLoopEnabled;
        }

        public void Reset()
        {
            this.currentFrameIndex = 0;
            this.currentAnimationTime = 0;
        }

        public void Update()
        {
            currentAnimationTime += Program.deltaTime;

            if (currentAnimationTime >= speed)
            {
                currentFrameIndex++;
                currentAnimationTime = 0;

                if (currentFrameIndex >= frames.Count)
                {
                    if (isLoopEnabled)
                    {
                        currentFrameIndex = 0;
                    }
                    else
                    {
                        currentFrameIndex = frames.Count - 1;
                    }
                }
            }
        }

        //public Animation CreateAnimation(string p_animationID, string p_path, int p_texturesAmount, float p_animationSpeed)
        //{
        //    // Idle Animation
        //    List<Texture> animationFrames = new List<Texture>();

        //    for (int i = 1; i < p_texturesAmount; i++)
        //    {
        //        animationFrames.Add(Engine.GetTexture($"{p_path}{i}.png"));
        //    }

        //    Animation animation = new Animation(p_animationID, animationFrames, p_animationSpeed, true);

        //    return animation;
        //}




    }
}
