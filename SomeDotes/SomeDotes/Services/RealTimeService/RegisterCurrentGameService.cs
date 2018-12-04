namespace SomeDotes.Services.RealTimeService
{
    using HtmlAgilityPack;
    using Microsoft.Win32;
    using SomeDotes.Helpers;
    using SomeDotes.Models.Intefaces;
    using SomeDotes.Models.Interfaces;
    using SomeDotes.Models.MainModels;
    using SomeDotes.Services.DatabaseServices;
    using SomeDotes.Services.Helpers;
    using SomeDotes.ViewModels;
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Net;
    using System.Text.RegularExpressions;

    public class RegisterCurrentGameService : IRegisterCurrentGameService
    {
        #region Declaration

        private ICurrentGameService cgs;
        private IDatabaseService dbService;
        private IConvertSteamIdToAccountId converter;
        private CurrentGameInfo currentMatchInfo;
        private static RegisterCurrentGameService singelton;

        #endregion

        #region Initialize

        private RegisterCurrentGameService()
        {
            converter = new ConvertSteamIdToAccountId();
        }

        #endregion

        #region Public Methods

        public CurrentGameInfo CurrentMatchInfo
        {
            get
            {
                if (currentMatchInfo == null)
                    currentMatchInfo = new CurrentGameInfo();
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

        public CurrentGameInfo MatchInfo()
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
