﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ClassicSpaceInvaders.Modules.Game;
using ClassicSpaceInvaders.Modules.Utilities;
using ClassicSpaceInvaders.Modules.Managers;


namespace ClassicSpaceInvaders.Modules.Sprites
{
    public class AnimSprite : Sprite
    {
        #region Private Data

        private List<Rectangle>     mAnimFrames     = new List<Rectangle>();
        private float               mAnimFrameDelay = 0.0f;
        private bool                mReloop         = true;
        private bool                mAnimActive     = false;

        private float               mCurFrameTime   = 0.0f;
        private Int32               mCurFrame       = 0;
        private Int32               mTotalFrames    = 0;

        #endregion

        #region Properties

        public List<Rectangle> FrameList
        {
            get {  return( mAnimFrames ); }
        }

        public float FrameDelay
        {
            get { return (mAnimFrameDelay); }
            set { mAnimFrameDelay = value; }
        }

        public bool Loop
        {
            get { return (mReloop); }
            set { mReloop = value; }
        }


        public bool AnimActive
        {
            get { return (mAnimActive); }
            set
            {
                mAnimActive     = value;
                mCurFrameTime   = 0.0f;
            }
        }


        #endregion

        #region public Functionality

        public void SetAnim( Rectangle[] Frames, float FrameDelay, bool Loop )
        {
            // Add frames to list...
            mAnimFrames.Clear();
            foreach( Rectangle rFrame in Frames )
            {
                mAnimFrames.Add( rFrame );
            }
            mCurFrame       = 0;
            mTotalFrames    = mAnimFrames.Count;        // or use Frames.Length

            mAnimFrameDelay = FrameDelay;
            mReloop         = Loop;
            mAnimActive     = false;
        }


        public override void Update(GameTime gameTime)
        {
            // if active, anim sprite
            if ( mAnimActive == true )
            {
                if ( mCurFrameTime < mAnimFrameDelay )
                {
                    mCurFrameTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                else
                {
                    mCurFrameTime = 0.0f;
                    mCurFrame++;

                    if ( mCurFrame >= mTotalFrames )
                    {
                        if ( mReloop == true )
                        {
                            mCurFrame   = 0;
                        }
                        else
                        {
                            mAnimActive = false;
                        }
                    }
                    
                    if ( mAnimActive == true )
                    { 
                        SourceRect      = mAnimFrames[ mCurFrame ];
                    }
                }

            }

            base.Update(gameTime);
        }

        #endregion



    }
}