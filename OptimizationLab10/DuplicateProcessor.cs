namespace OptimizationLab10;

public static class DuplicateProcessor
{
    // ИСХОДНЫЙ МОДУЛЬ.
    // Назначение: удалить повторяющиеся элементы массива,
    // сохранив порядок первого появления каждого элемента.
    // Этот метод НЕ ИЗМЕНЯЙТЕ: он нужен для сравнения.
    public static int[] RemoveDuplicatesOriginal(int[]? input)
    {
        if (input == null)
        {
            return Array.Empty<int>();
        }

        List<int> result = new List<int>();

        for (int i = 0; i < input.Length; i++)
        {
            bool exists = false;

            for (int j = 0; j < result.Count; j++)
            {
                if (result[j] == input[i])
                {
                    exists = true;
                    break;
                }
            }

            if (!exists)
            {
                result.Add(input[i]);
            }
        }

        return result.ToArray();
    }

    // МОДУЛЬ ДЛЯ ОПТИМИЗАЦИИ.
    // В начале он намеренно повторяет исходный алгоритм.
    // Ваша задача — изменить ТОЛЬКО этот метод так,
    // чтобы результат сохранился, а время выполнения уменьшилось.
    public static int[] RemoveDuplicatesOptimized(int[]? input)
    {
        if (input == null)
        {
            return Array.Empty<int>();
        }

        List<int> result = new List<int>();

        for (int i = 0; i < input.Length; i++)
        {
            bool exists = false;

            for (int j = 0; j < result.Count; j++)
            {
                if (result[j] == input[i])
                {
                    exists = true;
                    break;
                }
            }

            if (!exists)
            {
                result.Add(input[i]);
            }
        }

        return result.ToArray();
    }
}
