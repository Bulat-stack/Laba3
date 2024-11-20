using System;
using System.Threading;
using System.Threading.Tasks;

namespace DistributedQueue.Common
{
    internal class GregoryLeibnizGetPIJob : IComputePiJob
    {
        public Task ComputePyAsync(string name, int iterations, CancellationToken token)
        {
            return SimulateWorkAsync(name, iterations, token);
        }

        private async Task SimulateWorkAsync(string name, int iterations, CancellationToken token)
        {
            Console.WriteLine($"{DateTime.Now}: GregoryLeibnizGetPIJob: Starting task {name}, iterations: {iterations}");

            string[] statusMessages = {
                "Processing data...", "Analyzing results...", "Generating report...",
                "Calculating metrics...", "Verifying integrity...", "Optimizing performance...",
                "Updating database...", "Sending notifications...", "Cleaning up...",
                "Finalizing..."
            };

            for (int i = 0; i < iterations; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine($"{DateTime.Now}: GregoryLeibnizGetPIJob: Cancelled task {name}");
                    return;
                }

                // Simulate some work
                await Task.Delay(500); // Adjust delay as needed

                // Show progress and status
                int messageIndex = i % statusMessages.Length;
                Console.WriteLine($"{DateTime.Now}: GregoryLeibnizGetPIJob: Task: {name}, Iteration: {i + 1}, Status: {statusMessages[messageIndex]}");

                if (i % 100 == 0 && i != 0) //Вывод прогресса каждые 100 итераций
                {
                    double percentComplete = (double)i / iterations * 100;
                    Console.WriteLine($"{DateTime.Now}: GregoryLeibnizGetPIJob: Task: {name}, Progress: {percentComplete:F2}%");
                }
            }

            Console.WriteLine($"{DateTime.Now}: GregoryLeibnizGetPIJob: Finished task {name}");
        }
    }
}