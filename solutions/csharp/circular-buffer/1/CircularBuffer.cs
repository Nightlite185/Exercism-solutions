// THIS VERSION DOESN'T PASS EXERCISM'S TESTS, BC THE TYPE PASSED IN IN TESTS IS <T> (NOT <T?>), WHICH IS NOT NULLABLE. 
// AND THIS VER. RELIES ON NULLS AS EMPTY SPACES IN BUFFER. I'M KEEPING THIS VERSION FOR REFERENCE THOUGH.

public class CircularBuffer<T>(int capacity)
{
    private T?[] buffer = new T?[capacity];

    private List<int> writeHistory = []; // indexes of buffer sorted from oldest written to latest.

    private int GetNextEmptyIdx(int lastFullIdx)
    {
        var allEmpty = buffer
            .Index()
            .Where(set => set.Item == null);

        if (allEmpty.Count() == 0)
            throw new InvalidOperationException("Buffer is full - can't write.");

        // First we look from the right side of lastFullIdx for an empty one
        int? rightIdx = allEmpty.FirstOrDefault(set => set.Index > lastFullIdx).Index;

        // If we found it: we return it. Else: we start from index 0, and take the first empty one.
        return rightIdx.HasValue
            ? (int)rightIdx
            : allEmpty.First().Index;
    }

    public T Read()
    {
        if (writeHistory.Count == 0)
            throw new InvalidOperationException("Buffer is empty - nothing to read has been found");

        int oldestIdx = writeHistory.First(); // we copy the first element to return it later
        writeHistory.RemoveAt(0);          // And remove it from the history right away 
                                           // (read elements get removed from the buffer - no need to keep it in the history.)
        return buffer[oldestIdx]!;
    }

    public void Write(T value)
    {
        if (buffer.All(x => x != null))
            throw new InvalidOperationException("Buffer is full.");

        if (writeHistory.Count == 0)
        {
            buffer[0] = value;
            writeHistory.Add(0);
            return;
        }

        else
        {
            int next = GetNextEmptyIdx(writeHistory.Last());

            buffer[next] = value;
            writeHistory.Add(next);
        }
    }

    public void Overwrite(T value)
    {
        if (buffer.Any(x => x == null))
        {
            if (writeHistory.Count() == 0)
            {
                buffer[0] = value;
                writeHistory.Add(0);
                return;
            }

            int next = GetNextEmptyIdx(writeHistory.Last());
            buffer[next] = value;
            writeHistory.Add(next);
            return;
        }

        buffer[writeHistory.First()] = value;

        writeHistory.Add(writeHistory.First());
        writeHistory.RemoveAt(0);
    }

    public void Clear()
    {
        Array.Clear(buffer);
        writeHistory.Clear();
    }
}