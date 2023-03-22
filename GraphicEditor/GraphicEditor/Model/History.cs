using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor.Model
{
    public class History<T>
    {
        private readonly Stack<T> undoStack;
        private readonly Stack<T> redoStack;

        public History(T firstElemet)
        {
            undoStack = new Stack<T>();
            redoStack = new Stack<T>();

            undoStack.Push(firstElemet);
        }

        public bool CanUndo()
        {
            return undoStack.Count > 1;
        }

        public T Undo()
        {
            if (CanUndo())
            {
                var item = undoStack.Pop();
                redoStack.Push(item);
            }

            return undoStack.Peek();
        }

        public bool CanRedo()
        {
            return redoStack.Count > 0;
        }

        public T Redo()
        {
            if (CanRedo())
            {
                var item = redoStack.Pop();
                undoStack.Push(item);
            }

            return undoStack.Peek();
        }

        public void AddItem(T item)
        {
            redoStack.Clear();
            undoStack.Push(item);
        }
    }
}
