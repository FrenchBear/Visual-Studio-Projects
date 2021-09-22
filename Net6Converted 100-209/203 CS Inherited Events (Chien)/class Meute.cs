// 2021-09-19   PV  VS2022; Net6

using System;
using System.Collections.ObjectModel;

#pragma warning disable IDE0051 // Remove unused private members

namespace CS203
{
    internal class Meute<T> where T : Animal
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
    internal class Events
    {
        private event EventHandler PreDrawEvent;

        private event EventHandler OnDraw
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