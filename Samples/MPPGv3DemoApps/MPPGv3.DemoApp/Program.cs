using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MPPGv3.ServiceFactory;
using MPPGv3.UIFactory;
using System;
using System.Collections.Generic;
using System.IO;

namespace MPPGv3.DemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json");

            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(config);
            services.AddSingleton<IMppgv3UIFactory, Mppgv3UIfactory>();
            services.AddSingleton<IProcessCardSwipeClient, ProcessCardSwipeClient>();
            services.AddSingleton<IProcessKeyPadEntryClient, ProcessKeyPadEntryClient>();
            services.AddSingleton<IProcessManualEntryClient, ProcessManualEntryClient>();
            services.AddSingleton<IProcessTokenClient, ProcessTokenClient>();
            services.AddSingleton<IGetProcessorReportClient, GetProcessorReportClient>();
            services.AddSingleton<IProcessReferenceIDClient, ProcessReferenceIDClient>();
            services.AddSingleton<IProcessEMVSREDClient, ProcessEMVSREDClient>();
            services.AddSingleton<IProcessEncryptedManualEntryClient, ProcessEncryptedManualEntryClient>();
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            var uiFactory = serviceProvider.GetService<IMppgv3UIFactory>();

            while (true)
            {
                try
                {
                    Console.WriteLine("Please select service operation");
                    List<string> operations = new List<string>
                    {
                        "1.GetProcessorReport","2.ProcessCardSwipe","3.ProcessEMVSRED","4.ProcessEncryptedManualEntry",
                        "5.ProcessKeyPadEntry","6.ProcessManualEntry","7.ProcessReferenceID", "8.ProcessToken",
                    };
                    Console.Clear();
                    operations.ForEach(x => { Console.WriteLine(x); });
                    Console.WriteLine("Enter Option:");
                    var keyInfo = Console.ReadKey();
                    Console.WriteLine();

                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.D1:
                            uiFactory.ShowUI(MPPGv3UI.GETPROCESSORREPORT);
                            break;
                        case ConsoleKey.D2:
                            uiFactory.ShowUI(MPPGv3UI.PROCESSCARDSWIPE);
                            break;
                        case ConsoleKey.D3:
                            uiFactory.ShowUI(MPPGv3UI.PROCESSEMVSRED);
                            break;
                        case ConsoleKey.D4:
                            uiFactory.ShowUI(MPPGv3UI.PROCESSENCRYPTEDMANUALENTRY);
                            break;
                        case ConsoleKey.D5:
                            uiFactory.ShowUI(MPPGv3UI.PROCESSKEYPADENTRY);
                            break;
                        case ConsoleKey.D6:
                            uiFactory.ShowUI(MPPGv3UI.PROCESSMANUALENTRY);
                            break;
                        case ConsoleKey.D7:
                            uiFactory.ShowUI(MPPGv3UI.PROCESSREFERENCEID);
                            break;
                        case ConsoleKey.D8:
                            uiFactory.ShowUI(MPPGv3UI.PROCESSTOKEN);
                            break;





                    }
                    bool decision = Confirm("Would you like to Continue with other Request");
                    if (decision)
                        continue;
                    else
                        break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public static bool Confirm(string title)
        {
            ConsoleKey response;
            do
            {
                Console.Write($"{ title } [y/n] ");
                response = Console.ReadKey(false).Key;
                if (response != ConsoleKey.Enter)
                {
                    Console.WriteLine();
                }
            } while (response != ConsoleKey.Y && response != ConsoleKey.N);

            return (response == ConsoleKey.Y);
        }
    }
}
