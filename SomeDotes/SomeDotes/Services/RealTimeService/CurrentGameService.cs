namespace SomeDotes.Services.RealTimeService
{
    using SomeDotes.Models.Interfaces;
    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Net;
    using System.Threading;

    public delegate void NewGameStateHandler(CurrentGameStateService gamestate);

    public class CurrentGameService : ICurrentGameService
    {
        private bool isRunning;
        private int port;
        private HttpListener portListener;
        private AutoResetEvent waitForConnection = new AutoResetEvent(false);
        private CurrentGameStateService currentGameState;

        public CurrentGameService(int Port)
        {
            port = Port;
            portListener = new HttpListener();
            portListener.Prefixes.Add("http://localhost:" + Port + "/");
        }
        
        public bool IsRunning
        {
            get
            {
                return isRunning;
            }
        }

        public int Port
        {
            get
            {
                return port;
            }
        }

        public CurrentGameStateService CurrentGameState
        {
            get
            {
                return currentGameState;
            }
            set
            {
                currentGameState = value;
                RaiseOnNewGameState();
            }
        }

        public bool Start()
        {
            if (!isRunning)
            {
                Thread listenerThread = new Thread(new ThreadStart(Run));

                try
                {
                    portListener.Start();
                }
                catch (HttpListenerException)
                {
                    return false;
                }
                isRunning = true;

                listenerThread.IsBackground = true;

                listenerThread.Start();
                return true;
            }

            return false;
        }

        private void Run()
        {
            while (isRunning)
            {
                portListener.BeginGetContext(ReceiveGameState, portListener);
                waitForConnection.WaitOne();
                waitForConnection.Reset();
            }
            portListener.Stop();
        }

        private void Stop()
        {
            isRunning = false;
        }

        private void ReceiveGameState(IAsyncResult result)
        {
            try
            {
                HttpListenerContext context = portListener.EndGetContext(result);
                HttpListenerRequest request = context.Request;
                string JSON;

                waitForConnection.Set();

                using (Stream inputStream = request.InputStream)
                {
                    using (StreamReader sr = new StreamReader(inputStream))
                        JSON = sr.ReadToEnd();
                }
                using (HttpListenerResponse response = context.Response)
                {
                    response.StatusCode = (int)HttpStatusCode.OK;
                    response.StatusDescription = "OK";
                    response.Close();
                }
                CurrentGameState = new CurrentGameStateService(JSON);
            }
            catch (ObjectDisposedException)
            {
                // Intentionally left blank, when the Listener is closed.
            }
        }
        
        private void RaiseOnNewGameState()
        {
            foreach (Delegate d in NewGameState.GetInvocationList())
            {
                if (d.Target is ISynchronizeInvoke)
                    (d.Target as ISynchronizeInvoke).BeginInvoke(d, new object[] { CurrentGameState });
                else
                    d.DynamicInvoke(CurrentGameState);
            }
        }

        public event NewGameStateHandler NewGameState = delegate { };

        public void Dispose()
        {
            this.Stop();
            this.waitForConnection.Dispose();
            this.portListener.Close();
        }
    }
}
