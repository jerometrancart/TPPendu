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
            var r = new Random();
            //GENERE MOI UN INDEX ALEAT ENTRE 0 ET 7
            var index = r.Next(8);
            //UTILISE L'INDEX ALEAT POUR CHOISIR LE MOT DANS LA LISTE
            MotATrouver = mots[index];
            // // METHODE 1
            // for (int i = 0; i < MotATrouver.Length; i++)
            // {
            //     MotCourant = MotCourant + "-";
            // }

            // METHODE 2
            MotCourant = string.Concat(Enumerable.Repeat('-', MotATrouver.Length));
        }

        //CREER UN BOOLEEN POUR L'ARRET DU JEU
        //A RECUP DANS LA CLASSE DE LOGIQUE DU JEU
        public bool GagneOuPerdu()
        {
            return MotCourant == MotATrouver || NbEssai >= NbEssaiMax;
        }

        //CREER UNE FONCTION POUR TESTER LES LETTRES SAISIES
        public void TesterLettre(char c)
        {
            if(LettresTestees.Contains(c))
            {
                return;
            }
            //AJOUTE LA LETTRE TESTEE DANS LA LISTE
            LettresTestees.Add(c);
            //GENERE UN TABLEAU DE CHAR A PARTIR D'UN STRING
            var copie = MotCourant.ToArray();
            //CREE UN BOOL POUR GERER SI LE JOUEUR S'EST TROMPE
            bool trouve = false;
            //PARCOURT CHAQUE LETTRE DU MOT A TROUVER
            for (int i = 0; i < MotATrouver.Length; i++)
            {
                var caractere = MotATrouver[i];
                //SI DANS MA COPIE TU TROUVES LE MEME CARAC QUE DANS LE MOT ORIGINAL
                //A LA MEME PLACE, MET A JOUR LE MOT COURANT
                if(caractere == c)
                {
                    copie[i] = c;
                    //LE JOUEUR NE S'EST PAS TROMPE SUR CE TOUR
                    trouve = true;
                }
            }
            if(trouve)
            {   
                //REAFFICHE LE MOT AVEC UN TIRET EN MOINS
                MotCourant = new string(copie);
            }
            else
            {
                //LE JOUEUR S'EST TROMPE, ON SE RAPPROCHE DE LA MORT
                NbEssai++;
            }
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
