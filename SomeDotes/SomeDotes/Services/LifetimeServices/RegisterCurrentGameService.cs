namespace SomeDotes.Services.LifetimeServices
{
    using Microsoft.Win32;
    using SomeDotes.Models.Interfaces;
    using System.Diagnostics;
    using System.IO;

    public class RegisterCurrentGameService : IRegisterCurrentGameService
    {
        ICurrentGameService cgs;

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

        static void OnNewGameState(CurrentGameStateService gs)
        {
            //Console.Clear();
            //Console.WriteLine("Press ESC to quit");
            //Console.WriteLine("Current Dota version: " + gs.Provider.Version);
            //Console.WriteLine("Current time as displayed by the clock (in seconds): " + gs.Map.ClockTime);
            //Console.WriteLine("Your steam name: " + gs.Player.Name);
            //Console.WriteLine("hero ID: " + gs.Hero.ID);
            //Console.WriteLine("Health: " + gs.Hero.Health);
            //for (int i = 0; i < gs.Abilities.Count; i++)
            //{
            //    Console.WriteLine("Ability {0} = {1}", i, gs.Abilities[i].Name);
            //}
            //Console.WriteLine("First slot inventory: " + gs.Items.GetInventoryAt(0).Name);
            //Console.WriteLine("Second slot inventory: " + gs.Items.GetInventoryAt(1).Name);
            //Console.WriteLine("Third slot inventory: " + gs.Items.GetInventoryAt(2).Name);
            //Console.WriteLine("Fourth slot inventory: " + gs.Items.GetInventoryAt(3).Name);
            //Console.WriteLine("Fifth slot inventory: " + gs.Items.GetInventoryAt(4).Name);
            //Console.WriteLine("Sixth slot inventory: " + gs.Items.GetInventoryAt(5).Name);

            //if (gs.Items.InventoryContains("item_blink"))
            //    Console.WriteLine("You have a blink dagger");
            //else
            //    Console.WriteLine("You DO NOT have a blink dagger");
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
