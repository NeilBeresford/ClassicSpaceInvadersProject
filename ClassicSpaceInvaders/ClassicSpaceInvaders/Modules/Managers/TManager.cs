using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ClassicSpaceInvaders.Modules.Game;
using ClassicSpaceInvaders.Modules.Utilities;
using System.Collections.Generic;

namespace ClassicSpaceInvaders.Modules.Managers
{
    public class GameObject : GameInterface
    {
        #region Properties
        /// <summary>
        /// BaseID - used when referencing objects
        /// </summary>
        public Int32 BaseID { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Basic public constructor, needed when used with the template for example
        /// </summary>
        public GameObject()
        {
        }

        #endregion

        #region Public Functionality

        /// <summary>
        /// virtual Draw, allowing drawing from global spritebatch
        /// </summary>
        /// <param name="gameTime">Structure passed in containing the current frame times</param>
        public virtual void Draw(GameTime gameTime)
        {

        }

        /// <summary>
        /// Used when initialing the object.
        /// </summary>
        public virtual void Initialise()
        {

        }

        /// <summary>
        /// Called at loading of the class object, allowing resources etc to be
        /// loaded.
        /// </summary>
        public virtual void LoadContent()
        {

        }

        /// <summary>
        /// Called periodically to all game progression and sprite movement
        /// for example.
        /// </summary>
        /// <param name="gameTime">Structure passed in containing the current frame times</param>
        public virtual void Update( GameTime gameTime )
        {
        
        }

        #endregion


    }

    public class TManager<T> where T : GameObject
    {

        #region Private Data

        /// <summary>
        /// Object list, stored Template objects
        /// </summary>
        private List<T>             mObjectList = new List<T>();

        /// <summary>
        /// Object ID references stored for deletion after update processed.
        /// </summary>
        private List<Int32>         mKillList   = new List<Int32>();

        #endregion

        #region Properites
        public int ID { get; set; }

        public Int32 ObjectCount
        {
            get{  return( mObjectList.Count ); }
        }


        public T this[Int32 ID]
        {
            get { return mObjectList[ID]; }
            set { mObjectList[ID] = value; }
        }
        
        #endregion

        #region Constructors

        /// <summary>
        /// Basic constructor, needed to allow this to be used with gameObjects etc
        /// </summary>
        public TManager()
        {
        }

        /// <summary>
        /// Constructor, allowing the object list to be created, with the current class/structure/type
        /// </summary>
        /// <param name="obj">reference object passed in</param>
        public TManager( T obj )
        {
            mObjectList = new List<T>();
            ID          = 0;
        }

        #endregion

        #region Public Functionality

        /// <summary>
        /// Adds the passed in object to the objectlist
        /// </summary>
        /// <param name="obj">object to be added to list</param>
        /// <returns>returns the unique ID for the objecxt that has been added to the list</returns>
        public Int32 Add( T obj )
        {
            obj.BaseID  = ID++;
            mObjectList.Add( obj );

            return( obj.BaseID );
        }

        /// <summary>
        /// Call this to allow the object to be removed.
        /// </summary>
        /// <param name="nID">Unique Id for the object stored in the list, to be removed.</param>
        public void Kill( Int32 nID )
        {
            mKillList.Add( nID );
        }

        /// <summary>
        /// Periodically updates the objects stored within the list.
        /// Also, please note the kill list is processed at the end of this function.
        /// </summary>
        /// <param name="gameTime">Structure containing the frame times</param>
        public virtual void Update( GameTime gameTime )
        {
            // call the update function for all objects added to the list
            if ( mObjectList.Count > 0 )
            {
                foreach( T obj in mObjectList )
                {
                    obj.Update( gameTime );
                }
            }

            // remove any killed objects
            if ( mKillList.Count > 0 )
            {
                foreach( Int32 nID in mKillList )
                {
                    Remove( nID );
                }

                mKillList.Clear();
            }

        }

        /// <summary>
        /// Periodically processes all the objects calling their draw functions
        /// </summary>
        /// <param name="gameTime">Structure containing the frame times</param>
        public virtual void Draw( GameTime gameTime )
        {
            // call the draw function for all objects added to the list
            if (mObjectList.Count > 0)
            {
                foreach (T obj in mObjectList)
                {
                    obj.Draw(gameTime);
                }
            }

        }

        #endregion

        #region Private Functionality

        /// <summary>
        /// This will remove the object from the main objectlist.
        /// It compares the pass3ed in ID with the baseID of the objects stored.
        /// </summary>
        /// <param name="nID"></param>
        /// <returns>true - object deleted successfully</returns>
        private bool Remove( Int32 nID )
        {
            bool bRet = true;
    
            foreach( T obj in mObjectList )
            {
                if ( obj.BaseID == nID )
                {
                    try
                    {
                        mObjectList.Remove(obj);
                        break;
                    }
                    catch
                    {
                        bRet = false;
                        break;
                    }
                }
            }

            return( bRet );
        }


        #endregion

    }
}
