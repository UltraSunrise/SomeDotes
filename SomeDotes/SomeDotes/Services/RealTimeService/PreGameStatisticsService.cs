namespace SomeDotes.Services.RealTimeService
{
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Win32;
    using SomeDotes.Models.Interfaces;
    using SomeDotes.ViewModels;
    using System.Diagnostics;
    using System.IO;

    public class PreGameStatisticsService : IPreGameStatisticsService
    {
        private ICurrentGameService cgs;
        private IMemoryCache cache;
        private bool check;

        public PreGameStatisticsService(IMemoryCache cache, CurrentGameService cgs)
        {
            this.cache = cache;
            this.cgs = cgs;
            check = false;

            Run();

            // Unfortunate
            while (!check) { }
        }

        public PreGameViewModel PreGameViewModel { get; set; }
        
        public void Run()
        {
            RegisterCGSFile();

            Process[] programName = Process.GetProcessesByName("Dota2");
            if (programName.Length != 0)
            {
                cgs.NewGameState += OnNewGameState;

                cgs.Start();
            }
        }
        
        private void OnNewGameState(CurrentGameStateService gs)
        {
            PreGameViewModel = new PreGameViewModel(cache, gs);
            check = true;
        }

        private void RegisterCGSFile()
        {
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey(@"Software\Valve\Steam");

            if (regKey != null)
            {
                string gsifolder = regKey.GetValue("SteamPath") +
                                   @"\steamapps\common\dota 2 beta\game\dota\cfg\gamestate_integration";
                Directory.CreateDirectory(gsifolder);
                string gsifile = gsifolder + @"\gamestate_integration_testGSI.cfg";
                if (File.Exists(gsifile))
                    return;

                string[] contentofgsifile =
                {
                    "\"Dota 2 Integration Configuration\"",
                    "{",
                    "    \"uri\"           \"http://localhost:4000\"",
                    "    \"timeout\"       \"5.0\"",
                    "    \"buffer\"        \"0.1\"",
                    "    \"throttle\"      \"0.1\"",
                    "    \"heartbeat\"     \"30.0\"",
                    "    \"data\"",
                    "    {",
                    "        \"provider\"      \"1\"",
                    "        \"map\"           \"1\"",
                    "        \"player\"        \"1\"",
                    "        \"hero\"          \"1\"",
                    "        \"abilities\"     \"1\"",
                    "        \"items\"         \"1\"",
                    "    }",
                    "}",

                };

                File.WriteAllLines(gsifile, contentofgsifile);
            }
        }
    }
}
