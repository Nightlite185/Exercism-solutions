public static class BinarySearch
{
    public static int Find(int[] input, int target)
    {
        int low = 0;    int mid = 0;   int high = input.Length - 1;
        int middleValue = 0;
        

        while (low <= high)
        {
            mid = (low + high) / 2;
            middleValue = input[mid];
            

            switch (middleValue)
            {
                case int when target > middleValue:
                    low = mid + 1;
                    break;

                case int when target < middleValue:
                    high = mid - 1;
                    break;

                default: return mid;
            }
        }
        return -1;
    }
}