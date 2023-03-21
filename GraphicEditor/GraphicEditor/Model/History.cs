using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor.Model
{
    public class History<T>
    {
        private readonly List<T> history;
        private int index;

        public History(T firstElemet)
        {
            history = new List<T> { firstElemet };
            index = 0;
        }

        public bool CanUndo()
        {
            return index > 0;
        }

        public T Undo()
        {
            if (CanUndo())
            {
                return history[--index];
            }

            return history[index];
        }

        public bool CanRedo()
        {
            return index < history.Count - 1;
        }

        public T Redo()
        {
            if (CanRedo())
            {
                return history[++index];
            }

            return history[index];
        }

        public void AddItem(T item)
        {
            index++;

            if (index <= history.Count - 1)
            {
                history.RemoveRange(index, history.Count - index);
            }

            history.Add(item);
        }
    }
}
