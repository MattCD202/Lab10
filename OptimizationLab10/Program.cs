using System.Diagnostics;

namespace OptimizationLab10;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("Лабораторная работа №10");
        Console.WriteLine("Разработка тестовых модулей проекта и оптимизация программы");
        Console.WriteLine("Индивидуальный модуль: удаление повторяющихся элементов массива");
        Console.WriteLine("Параметр оптимизации: время выполнения");
        Console.WriteLine();

        // Одинаковые данные используются для честного сравнения двух вариантов.
        int[] data = DataGenerator.CreateTestData(length: 15000, valueRange: 3000);

        // Прогрев JIT-компиляции до начала замеров.
        _ = DuplicateProcessor.RemoveDuplicatesOriginal(new int[] { 1, 2, 2, 3 });
        _ = DuplicateProcessor.RemoveDuplicatesOptimized(new int[] { 1, 2, 2, 3 });

        const int measurements = 5;
        double originalTotal = 0;
        double optimizedTotal = 0;

        int[]? originalResult = null;
        int[]? optimizedResult = null;

        Console.WriteLine("Измерения времени выполнения:");
        Console.WriteLine();

        for (int i = 1; i <= measurements; i++)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            originalResult = DuplicateProcessor.RemoveDuplicatesOriginal(data);
            stopwatch.Stop();
            double originalMs = stopwatch.Elapsed.TotalMilliseconds;
            originalTotal += originalMs;

            stopwatch.Restart();
            optimizedResult = DuplicateProcessor.RemoveDuplicatesOptimized(data);
            stopwatch.Stop();
            double optimizedMs = stopwatch.Elapsed.TotalMilliseconds;
            optimizedTotal += optimizedMs;

            Console.WriteLine(
                $"Измерение {i}: исходный = {originalMs:F2} мс; " +
                $"оптимизированный = {optimizedMs:F2} мс");
        }

        double originalAverage = originalTotal / measurements;
        double optimizedAverage = optimizedTotal / measurements;

        bool sameResult = originalResult != null &&
                          optimizedResult != null &&
                          originalResult.SequenceEqual(optimizedResult);

        double improvement = originalAverage > 0
            ? (originalAverage - optimizedAverage) / originalAverage * 100.0
            : 0;

        Console.WriteLine();
        Console.WriteLine("Результаты:");
        Console.WriteLine($"Среднее время исходного модуля:    {originalAverage:F2} мс");
        Console.WriteLine($"Среднее время оптимизированного:   {optimizedAverage:F2} мс");
        Console.WriteLine($"Количество уникальных элементов:   {optimizedResult?.Length ?? 0}");
        Console.WriteLine($"Результаты совпадают:              {(sameResult ? "ДА" : "НЕТ")}");
        Console.WriteLine($"Изменение времени:                 {improvement:F2}%");
        Console.WriteLine();
        Console.WriteLine("Примечание: фактическое время зависит от компьютера и режима сборки.");
        Console.WriteLine("Для завершения нажмите Enter...");
        Console.ReadLine();
    }
}
