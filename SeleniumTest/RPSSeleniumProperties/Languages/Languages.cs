using System;
using System.Collections.Generic;
using System.Text;

namespace RPSSeleniumProperties.Languages
{
    public static class Languages
    {
        static Languages()
        {
            CurrentLanguage =  AvailableLanguages.Español;
        }

        public static AvailableLanguages CurrentLanguage { get; set; }
        public static AvailableLanguages CodToEnum(string codlanguage)
        {
            switch(codlanguage)
            {
                case "01": return AvailableLanguages.Español;
                default: return AvailableLanguages.Español;                  
            }
        }
        public static string New
        {
            get
            {
                switch (CurrentLanguage)
                {
                    case AvailableLanguages.Español: return "Nuevo";
                    default: return null;

                }

            }
        }
        public static string Accept { get
            {
                switch (CurrentLanguage)
                {
                    case AvailableLanguages.Español: return "Aceptar";
                    default: return null;

                }

            } 
        }
        public static string Save
        {
            get
            {
                switch (CurrentLanguage)
                {
                    case AvailableLanguages.Español: return "Guardar";
                    default: return null;

                }

            }
        }
        public static string Delete
        {
            get
            {
                switch (CurrentLanguage)
                {
                    case AvailableLanguages.Español: return "Eliminar";
                    default: return null;

                }

            }
        }

        public static string Consult
        {
            get
            {
                switch (CurrentLanguage)
                {
                    case AvailableLanguages.Español: return "Consultar";
                    default: return null;

                }

            }
        }
    }


    public enum AvailableLanguages
    {
        Español = 1
    }

}
