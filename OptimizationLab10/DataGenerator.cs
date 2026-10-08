namespace OptimizationLab10;

public static class DataGenerator
{
    public static int[] CreateTestData(int length, int valueRange)
    {
        if (length < 0)
            throw new ArgumentOutOfRangeException(nameof(length));

        if (valueRange <= 0)
            throw new ArgumentOutOfRangeException(nameof(valueRange));

        Random random = new Random(10);
        int[] data = new int[length];

        for (int i = 0; i < data.Length; i++)
        {
            data[i] = random.Next(valueRange);
        }

        return data;
    }
}
