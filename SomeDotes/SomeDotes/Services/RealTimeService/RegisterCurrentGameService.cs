namespace SomeDotes.Services.RealTimeService
{
    using Microsoft.Win32;
    using SomeDotes.Models.Interfaces;
    using SomeDotes.Models.MainModels;
    using SomeDotes.Services.Helpers;
    using SomeDotes.ViewModels;
    using System.Diagnostics;
    using System.IO;

    public class RegisterCurrentGameService : IRegisterCurrentGameService
    {
        #region Declaration

        private ICurrentGameService cgs;
        private IConvertSteamIdToAccountId converter;
        private MatchInfo currentMatchInfo;
        private static RegisterCurrentGameService singelton;

        #endregion

        #region Initialize

        private RegisterCurrentGameService()
        {
            converter = new ConvertSteamIdToAccountId();
        }

        #endregion

        #region Public Methods

        public MatchInfo CurrentMatchInfo
        {
            get
            {
                if (currentMatchInfo == null)
                    currentMatchInfo = new MatchInfo();
                return currentMatchInfo;
            }
            set
            {
                if (value == null)
                    return;
                currentMatchInfo = value;
            }
        }

        public void Run()
        {
            RegisterCGSFile();

            Process[] programName = Process.GetProcessesByName("Dota2");
            if (programName.Length != 0)
            {
                cgs = new CurrentGameService(4000);
                cgs.NewGameState += OnNewGameState;

                cgs.Start();
            }
        }

        public MatchInfo MatchInfo()
        {
            return CurrentMatchInfo;
        }

        #endregion

        #region Private Methods

        private void OnNewGameState(CurrentGameStateService gs)
        {
            CurrentGameViewModel currentGameViewModel = new CurrentGameViewModel(gs);

            CurrentMatchInfo = currentGameViewModel.CurrentMatchInfo;
        }

        #region RegisterGame

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

        public static RegisterCurrentGameService GetInstance()
        {
            return singelton ?? (singelton = new RegisterCurrentGameService());
        }

        #endregion

        #endregion
    }
}
