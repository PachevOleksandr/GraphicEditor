namespace GraphicEditor.Helpers
{
    public class History<T>
    {
        private readonly Stack<T> undoStack;
        private readonly Stack<T> redoStack;

        public History(T firstElement)
        {
            undoStack = new Stack<T>();
            redoStack = new Stack<T>();

            undoStack.Push(firstElement);
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

        public void Reset()
        {
            while (CanUndo())
            {
                undoStack.Pop();
            }

            redoStack.Clear();
        }
    }
}
