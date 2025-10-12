public static class BinarySearch
{
    public static int Find(int[] input, int target)
    {
        int offsetFromStart = 0;
        int middleValue = 0;
        int sliceMiddleIdx;

        while (target != middleValue && input.Length >= 1)
        {
            sliceMiddleIdx = input.Length != 1
                ? input.Length / 2
                : 0;
                
            middleValue = input[sliceMiddleIdx];
            

            switch (middleValue)
            {
                case int when target > middleValue:
                    offsetFromStart += sliceMiddleIdx +1; // we update the offset only when slicing right, to keep track of how far from the start of OG list are we.
                    input = input[(sliceMiddleIdx+1)..]; // +1 to exclude the sliceMiddleIdx bc the target is higher.
                    break;

                case int when target < middleValue:
                    input = input[..sliceMiddleIdx]; // here we don't subtract anything bc the right border is already exclusive.
                    break;

                default:
                    return offsetFromStart + sliceMiddleIdx;
            }
        }
        return -1;
    }
}