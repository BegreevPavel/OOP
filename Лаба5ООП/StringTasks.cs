using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class StringTasks
{
    static string[] testTexts =
    {
        "В лесу родилась елочка. В лесу она росла. Зимой и летом стройная, зеленая была.",
        "Сегодня хорошая погода! Я пошел гулять. Вечером вернусь домой?",
        "Привет! Как дела? Все хорошо."
    };

    public static void CreateText()
    {
        Console.WriteLine("\n1. Ввести строку вручную");
        Console.WriteLine("2. Выбрать тестовую строку");

        int choice = Program.ReadInt("Ваш выбор: ", 1, 2);

        string text = "";

        if (choice == 1)
        {
            do
            {
                Console.WriteLine("Введите несколько предложений:");
                text = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(text))
                {
                    Console.WriteLine("Строка не должна быть пустой.");
                }

            } while (string.IsNullOrWhiteSpace(text));
        }
        else
        {
            Console.WriteLine("\nДоступные тестовые строки:");

            for (int i = 0; i < testTexts.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {testTexts[i]}");
            }

            int testNumber = Program.ReadInt("Выберите тестовую строку: ", 1, testTexts.Length);

            text = testTexts[testNumber - 1];
        }

        Console.WriteLine("\nИсходная строка:");
        Console.WriteLine(text);

        string result = SwapSentences(text);

        Console.WriteLine("\nРезультат:");
        Console.WriteLine(result);
    }

    static string SwapSentences(string text)
    {
        MatchCollection matches = Regex.Matches(text, @"[^.!?]*[.!?]+|[^.!?]+$");

        List<string> sentences = new List<string>();

        foreach (Match match in matches)
        {
            string sentence = match.Value.Trim();

            if (sentence.Length > 0)
            {
                sentences.Add(sentence);
            }
        }

        // Если предложений меньше двух, менять нечего.
        if (sentences.Count < 2)
        {
            Console.WriteLine(
                "\nВ строке меньше двух предложений. Перестановка невозможна!");

            return text;
        }

        // Меняем местами первое и последнее предложения.
        string first = sentences[0];

        sentences[0] = sentences[sentences.Count - 1];
        sentences[sentences.Count - 1] = first;

        return string.Join(" ", sentences);
    }
}