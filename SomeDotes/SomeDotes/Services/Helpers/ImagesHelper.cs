namespace SomeDotes.Services.Helpers
{
    using System.Collections.Generic;

    public class ImagesHelper
    {
        private static ImagesHelper singelton;

        private ImagesHelper() { }

        public string[] AllImages { get; set; } = new string[10];
        public bool AreAllAdded { get; set; }

        public static ImagesHelper GetInstance()
        {
            if (singelton == null)
                singelton = new ImagesHelper();

            return singelton;
        }
    }
}
