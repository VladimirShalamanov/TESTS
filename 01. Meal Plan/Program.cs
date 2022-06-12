using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Meal_Plan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] meal = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToArray();
            int[] calories = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var mealStack = new Stack<string>(meal);
            var caloriesStack = new Stack<int>(calories);

            int countMeals = 0;

            int currCalories = caloriesStack.Peek();
            while (mealStack.Count > 0 && caloriesStack.Count > 0)
            {
                string currMeal = mealStack.Peek();
                int mealCalories = 0;
                if (currMeal == "salad")
                {
                    mealCalories = 350;
                }
                else if (currMeal == "soup")
                {
                    mealCalories = 490;
                }
                else if (currMeal == "pasta")
                {
                    mealCalories = 680;
                }
                else if (currMeal == "steak")
                {
                    mealCalories = 790;
                }

                currCalories -= mealCalories;
                if (currCalories > 0)
                {
                    mealStack.Pop();
                    countMeals++;
                }
                else if (currCalories < 0 && caloriesStack.Count > 0)
                {
                    mealStack.Pop();
                    countMeals++;
                }

                if (currCalories == 0)
                {
                    caloriesStack.Pop();
                    if (caloriesStack.Count > 0)
                        currCalories = caloriesStack.Peek();
                }
                else if (currCalories < 0)
                {
                    caloriesStack.Pop();
                    if (caloriesStack.Count > 0)
                    {
                        int oldCalories = Math.Abs(currCalories);
                        int lastCalories = caloriesStack.Pop() - oldCalories;
                        caloriesStack.Push(lastCalories);
                        currCalories = caloriesStack.Peek();
                    }
                }
            }

            if (mealStack.Count == 0)
            {
                Console.WriteLine($"John had {countMeals} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", caloriesStack)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {countMeals} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", mealStack)}.");
            }
        }
    }
}
