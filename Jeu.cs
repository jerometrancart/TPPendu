using System;

namespace TPPendu
{
    public class Jeu
    {
        // FAIRE UNE BOUCLE POUR LIRE L'ENTREE UTILISATEUR
        // DEMANDER A LA CLASSE DU PENDU SI LA LETTRE SAISIE EST CONTENUE DANS LE RESULTAT OU NON
        // AFFICHER LES VALEURS DU PENDU SUR L ECRAN DANS UN ENSEMBLE COHERENT
        // GESTION DE LA SORTIE DE LA BOUCLE GAGNE/PERDU

        private Pendu pendu = new Pendu();


        public void LancerJeu() 
        {
            Console.Clear();
            while(pendu.GagneOuPerdu() == false) 
            {
                //AFFICHE LES LETTRE DEJA TESTEES
                Console.WriteLine($"Lettres testées : {string.Join(' ', pendu.LettresTestees)}");
                //EQUIVALENT DE STRING.JOIN
                // foreach (var lettre in pendu.LettresTestees)
                // {
                //     Console.Write($"{lettre} ");
                // }
                //AFFICHE LA POTENCE
                pendu.AfficherPendu();
                //AFFICHE LE MOT AVEC LES TIRETS
                Console.WriteLine($"Mot actuel : {pendu.MotCourant}");
                Console.WriteLine("Entrer une lettre :");
                
                char? saisie = null;
                // SECURISE CONTRE LES VALEURS NULLABLES
                while(saisie.HasValue == false)

                try 
                {

                }
                catch 
                {

                }
            }
            GestionFinDeJeu();
        }

        public void GestionFinDeJeu()
        {
            Console.Clear();
            if(pendu.MotCourant == pendu.MotATrouver)
            {
                Console.WriteLine("Bravo, vous avez gagné ! :-)");
            }
            else
            {
                Console.WriteLine("Dommage, vous avez perdu ! :'-(");
            }
            pendu.AfficherPendu();
            Console.WriteLine($"Le mot à trouver était : {pendu.MotATrouver}");
        }

    }
}
