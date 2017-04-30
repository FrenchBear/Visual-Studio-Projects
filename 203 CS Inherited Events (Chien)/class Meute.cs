using System;
using System.Collections.ObjectModel;


namespace CS203
{
    class Meute<T> where T : Animal
    {
        private readonly Collection<T> mCol;

        public Meute()
        {
            mCol = new Collection<T>();
        }

        public Meute(T a1)
        {
            // Using a Collection Initializer
            mCol = new Collection<T> { a1 };
        }

        public void Add(T a1)
        {
            mCol.Add(a1);
        }

        public void Enerver()
        {
            foreach (T a in mCol)
            {
                a.Enerver();
            }
        }
    }


    // Custom Event Handler in C#
    class Events
    {
        event EventHandler PreDrawEvent;

        event EventHandler OnDraw
        {
            add
            {
                lock (PreDrawEvent)
                {
                    PreDrawEvent += value;
                }
            }
            remove
            {
                lock (PreDrawEvent)
                {
                    PreDrawEvent -= value;
                }
            }
        }

    }

}
