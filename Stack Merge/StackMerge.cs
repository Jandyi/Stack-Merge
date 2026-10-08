using System;

class IntStack
{
    private int[] items;
    private int top;
    private int maxItems;

    public IntStack(int size)
    {
        maxItems = size;
        items = new int[maxItems];
        MakeEmpty();
    }

    public void MakeEmpty() { top = -1; }
    public bool IsEmpty() { return top == -1; }
    public bool IsFull() { return top == maxItems - 1; }

    public void Push(int val)
    {
        top++;
        items[top] = val;
    }

    public int Pop()
    {
        int val = items[top];
        top--;
        return val;
    }

    public int Size() { return top + 1; }
}

class Program
{
    // Insert a value while keeping the result stack sorted in descending order.
    static void InsertSorted(IntStack result, IntStack temp, int val)
    {
        int temp_val;
        while (!result.IsEmpty())
        {
            temp_val = result.Pop();
            if (temp_val > val)
            {
                temp.Push(temp_val);
            }
            else
            {
                result.Push(temp_val); // found the right spot, put it back
                break;
            }
        }

        result.Push(val);

        // restore temp back into result
        while (!temp.IsEmpty())
        {
            temp_val = temp.Pop();
            result.Push(temp_val);
        }
    }

    // Check whether a value already exists in a stack.
    static bool Contains(IntStack s, IntStack temp, int val)
    {
        bool found = false;
        int temp_val;
        while (!s.IsEmpty() && !found)
        {
            temp_val = s.Pop();
            if (temp_val == val) found = true;
            temp.Push(temp_val);
        }
        // restore s back
        while (!temp.IsEmpty())
        {
            temp_val = temp.Pop();
            s.Push(temp_val);
        }
        return found;
    }

    // Merge two stacks while keeping duplicates.
    static IntStack mergeDup(IntStack s1, IntStack s2)
    {
        int cap = s1.Size() + s2.Size();
        IntStack result = new IntStack(cap);
        IntStack temp = new IntStack(cap);
        int temp_val;

        while (!s1.IsEmpty())
        {
            temp_val = s1.Pop();
            InsertSorted(result, temp, temp_val);
        }
        while (!s2.IsEmpty())
        {
            temp_val = s2.Pop();
            InsertSorted(result, temp, temp_val);
        }

        return result;
    }

    // Merge two stacks while removing duplicates.
    static IntStack mergeNoDup(IntStack s1, IntStack s2)
    {
        int cap = s1.Size() + s2.Size();
        IntStack result = new IntStack(cap);
        IntStack temp = new IntStack(cap);
        int temp_val;

        while (!s1.IsEmpty())
        {
            temp_val = s1.Pop();
            if (!Contains(result, temp, temp_val)) // skip if already exists
                InsertSorted(result, temp, temp_val);
        }
        while (!s2.IsEmpty())
        {
            temp_val = s2.Pop();
            if (!Contains(result, temp, temp_val))
                InsertSorted(result, temp, temp_val);
        }

        return result;
    }

    // Print a stack from top to bottom.
    static void printStack(string label, IntStack s)
    {
        IntStack temp = new IntStack(s.Size());
        int temp_val;

        Console.Write(label + " (top->bottom): [ ");
        while (!s.IsEmpty())
        {
            temp_val = s.Pop();
            Console.Write(temp_val + " ");
            temp.Push(temp_val);
        }
        Console.WriteLine("]");

        while (!temp.IsEmpty())
            s.Push(temp.Pop());
    }

    static IntStack readStack(string name)
    {
        Console.Write("Enter size of " + name + ": ");
        int size = int.Parse(Console.ReadLine());
        IntStack s = new IntStack(size);
        for (int i = 0; i < size; i++)
        {
            Console.Write("  Enter element " + (i + 1) + ": ");
            s.Push(int.Parse(Console.ReadLine()));
        }
        return s;
    }

    // Create a copy so the original stacks can be used for both merge operations.
    static IntStack readStackCopy(IntStack original)
    {
        IntStack temp = new IntStack(original.Size());
        IntStack copy = new IntStack(original.Size());
        int temp_val;

        while (!original.IsEmpty())
        {
            temp_val = original.Pop();
            temp.Push(temp_val);
        }
        while (!temp.IsEmpty())
        {
            temp_val = temp.Pop();
            original.Push(temp_val); // restore original
            copy.Push(temp_val);     // fill copy
        }
        return copy;
    }

    static void Main()
    {
        Console.WriteLine("Stack 1");
        IntStack s1a = readStack("Stack 1");
        Console.WriteLine("Stack 2");
        IntStack s2a = readStack("Stack 2");
        printStack("Stack 1", s1a);
        printStack("Stack 2", s2a);

        // copy stacks so both merged duplicated and non duplicated stacks get full input
        IntStack s1b = readStackCopy(s1a);
        IntStack s2b = readStackCopy(s2a);

        Console.WriteLine("\nMerge with duplicates");
        IntStack merged = mergeDup(s1a, s2a);
        printStack("Result", merged);

        Console.WriteLine("\nMerge without duplicates");
        IntStack merged2 = mergeNoDup(s1b, s2b);
        printStack("Result", merged2);
    }
}