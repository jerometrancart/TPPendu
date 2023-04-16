using System;

namespace TPPendu
{
    public class Pendu
    {   
        //CREER UNE LISTE DE MOT A TROUVER
        private List<string> mots = new List<string>
        {
            "souris",
            "maison",
            "ouragan",
            "vacances",
            "chameau",
            "chalumeau",
            "piano",
            "ordinateur"
        };
        //NBESSAIMAX = TAILLE DU PENDU AU MAX
        private const int NbEssaiMax = 7;
        private int NbEssai;
        //CREER UNE LISTE DE CARACTERES A TESTER
        //LECTURE SEULE
        public List<char> LettresTestees {get;}= new List<char>();
        //CHOISIR LE MOT A TROUVER
        public string MotATrouver { get; private set; }
        //AFFICHER CE QUE L UTILISATEUR A TROUVE ACTUELLEMENT
        public string MotCourant { get; private set; }
        //LE MOT A TROUVER DOIT AVOIR AUTANT DE TIRETS QUE LE MOT CHOISI
        public Pendu()
        {
            
        }

        //CREER UN BOOLEEN POUR L'ARRET DU JEU
        //A RECUP DANS LA CLASSE DE LOGIQUE DU JEU
        public bool GagneOuPerdu()
        {
            return false;
        }

        //CREER UNE FONCTION POUR TESTER LES LETTRES SAISIES
        public void TesterLettre(char c)
        {

        }
        //LOGIQUE DU PENDU
        public void AfficherPendu()
        {
            var template = "  --------------     " + Environment.NewLine +
                             "    |        1       " + Environment.NewLine +
                             "    |        1       " + Environment.NewLine +
                             "    |       2 2'      " + Environment.NewLine +
                             "    |       2'2¤2      " + Environment.NewLine +
                             "    |      44355     " + Environment.NewLine +
                             "    |        3       " + Environment.NewLine +
                             "    |        3       " + Environment.NewLine +
                             "    |       6 7      " + Environment.NewLine +
                            @"   /|\     6   7     " + Environment.NewLine +
                            @"  / | \              " + Environment.NewLine +
                            @" /  |  \             ";
            for (int i = 1; i <= NbEssaiMax; i++)
            {
                if (NbEssai >= i)
                {
                    if (i != 2)
                    {
                        template = template.Replace(i.ToString(), i switch
                        {
                            1 => "|",
                            3 => "|",
                            4 => "-",
                            5 => "-",
                            6 => "/",
                            7 => "\\",
                            _ => ""
                        });
                    }
                    else
                    {
                        template = template
                            .Replace("2'", "\\")
                            .Replace("2¤", "_")
                            .Replace("2", "/");
                    }
                }
                else
                {
                    template = template.Replace(i.ToString(), i switch
                    {
                        4 => " ",
                        _ => ""
                    })
                    .Replace("'", "").Replace("¤", "");
                }

            }
            Console.Write(template);
            Console.WriteLine();
        }
    }
}
