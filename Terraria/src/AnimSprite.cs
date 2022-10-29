using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;

namespace Terraria
{
    class AnimationFrame
    {
        public int i, j;
        public float time;

        public AnimationFrame(int i, int j, float time)
        {
            this.i = i;
            this.j = j;
            this.time = time;
        }
    }

    class Animation
    {
        AnimationFrame[] frames;

        float timer;
        AnimationFrame currFrame;
        int currFrameIndex;

        public Animation(AnimationFrame[] frames)
        {
            this.frames = frames;
            Reset();
        }

        public void Reset()
        {
            timer = 0f;
            currFrameIndex = 0;
            currFrame = frames[0];
        }

        public void NextFrame()
        {
            timer = 0f;
            currFrameIndex++;

            if (currFrameIndex == frames.Length)
                currFrameIndex = 0;

            currFrame = frames[currFrameIndex];
        }

        public AnimationFrame GetFrame(float speed)
        {
            timer += speed;

            if (timer >= currFrame.time)
                NextFrame();

            return currFrame;
        }
    }

    class AnimSprite : Transformable, Drawable
    {
        public float Speed = 0.05f;

        RectangleShape rectShape;
        SpriteSheet ss;
        Dictionary<string, Animation> animations = new Dictionary<string, Animation>();
        Animation currAnim;
        string currAnimName;

        public Color Color
        {
            set { rectShape.FillColor = value; }
            get { return rectShape.FillColor; }
        }

        public AnimSprite(SpriteSheet ss)
        {
            this.ss = ss;

            rectShape = new RectangleShape(new Vector2f(ss.SubWidth, ss.SubHeight));
            rectShape.Origin = new Vector2f(ss.SubWidth / 2, ss.SubHeight / 2);
            rectShape.Texture = ss.Texture;
        }

        public void AddAnimation(string name, Animation animation)
        {
            animations[name] = animation;
            currAnim = animation;
            currAnimName = name;
        }

        public void Play(string name)
        {
            if (currAnimName != name)
            {
                currAnim = animations[name];
                currAnimName = name;
                currAnim.Reset();
            }
        }

        public IntRect GetTextureRect()
        {
            var currFrame = currAnim.GetFrame(Speed);
            return ss.GetTextureRect(currFrame.i, currFrame.j);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            rectShape.TextureRect = GetTextureRect();

            states.Transform *= Transform;
            target.Draw(rectShape, states);
        }
    }
}
