using System.Collections.Generic;

namespace MiPrimerApi.Repositories
{
    public static class InstrumentRepository
    {
        public static List<string> Instruments { get; set; }

        static InstrumentRepository()
        {
            Instruments = new List<string>
            {
                "Guitarra",
                "Batería",
                "Piano"
            };
        }
    }
}
