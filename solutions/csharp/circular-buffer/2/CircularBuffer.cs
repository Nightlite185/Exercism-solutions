// THIS IS THE FIRST ALL-GREEN PASSING VERSION, USING ARRAY OF STRUCTS 'Slot' MANAGING STATE AND VALUE SEPARATELY
// (Instead of just having an array of types T, being at risk of the input type being non-nullable - cuz previous version relied on nulls.)

public class CircularBuffer<T>(int capacity)
{
    private struct Slot<T>
    {
        private T _value;
        public bool IsSet;
        public T Value
        {
            get { return _value; }
            set { IsSet = true; _value = value; }
        }

        public void Clear()
        {
            this.IsSet = false;
            this._value = default!;
        }
    }

    private Slot<T>[] buffer = new Slot<T>[capacity];

    private List<int> writeHistory = []; // indexes of buffer sorted from oldest written to latest.

    private int GetNextEmptyIdx(int lastFullIdx)
    {
        var allEmpty = buffer
            .Index()
            .Where(set => set.Item.IsSet == false);

        if (!allEmpty.Any())
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

        int oldestIdx = writeHistory[0];        // we copy the first element to index with it in the line below
        T readValue = buffer[oldestIdx].Value;  // and copy that value from the buffer as well

        writeHistory.RemoveAt(0);          // And remove it from the history right away 
        buffer[oldestIdx].Clear();         // (read elements also get removed from the buffer - no need to keep it in the history.)

        return readValue;
    }

    public void Write(T value)
    {
        if (buffer.All(x => x.IsSet == true))
            throw new InvalidOperationException("Buffer is full.");

        if (writeHistory.Count == 0)
        {
            buffer[0].Value = value;
            writeHistory.Add(0);
            return;
        }

        else
        {
            int next = GetNextEmptyIdx(writeHistory.Last());

            buffer[next].Value = value;
            writeHistory.Add(next);
        }
    }

    public void Overwrite(T value)
    {
        if (buffer.Any(x => x.IsSet == false))
        {
            if (writeHistory.Count == 0)
            {
                buffer[0].Value = value;
                writeHistory.Add(0);
                return;
            }

            int next = GetNextEmptyIdx(writeHistory.Last());
            buffer[next].Value = value;
            writeHistory.Add(next);
            return;
        }

        buffer[writeHistory[0]].Value = value;

        writeHistory.Add(writeHistory[0]);
        writeHistory.RemoveAt(0);
    }

    public void Clear()
    {
        Array.Clear(buffer);
        writeHistory.Clear();
    }
}