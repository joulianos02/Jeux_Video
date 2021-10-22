//-----------------------------------------------------------------------
// <copyright file="Palette.cs" company="Marco Lavoie">
// Marco Lavoie, 2010-2016. Tous droits r�serv�s
// 
// L'utilisation de ce mat�riel p�dagogique (pr�sentations, code source 
// et autres) avec ou sans modifications, est permise en autant que les 
// conditions suivantes soient respect�es:
//
// 1. La diffusion du mat�riel doit se limiter � un intranet dont l'acc�s
//    est imit� aux �tudiants inscrits � un cours exploitant le dit 
//    mat�riel. IL EST STRICTEMENT INTERDIT DE DIFFUSER CE MAT�RIEL 
//    LIBREMENT SUR INTERNET.
// 2. La redistribution des pr�sentations contenues dans le mat�riel 
//    p�dagogique est autoris�e uniquement en format Acrobat PDF et sous
//    restrictions stipul�es � la condition #1. Le code source contenu 
//    dans le mat�riel p�dagogique peut cependant �tre redistribu� sous 
//    sa forme  originale, en autant que la condition #1 soit �galement 
//    respect�e.
// 3. Le mat�riel diffus� doit contenir int�gralement la mention de 
//    droits d'auteurs ci-dessus, la notice pr�sente ainsi que la
//    d�charge ci-dessous.
// 
// CE MAT�RIEL P�DAGOGIQUE EST DISTRIBU� "TEL QUEL" PAR L'AUTEUR, SANS 
// AUCUNE GARANTIE EXPLICITE OU IMPLICITE. L'AUTEUR NE PEUT EN AUCUNE 
// CIRCONSTANCE �TRE TENU RESPONSABLE DE DOMMAGES DIRECTS, INDIRECTS, 
// CIRCONSTENTIELS OU EXEMPLAIRES. TOUTE VIOLATION DE DROITS D'AUTEUR 
// OCCASIONN� PAR L'UTILISATION DE CE MAT�RIEL P�DAGOGIQUE EST PRIS EN 
// CHARGE PAR L'UTILISATEUR DU DIT MAT�RIEL.
// 
// En utilisant ce mat�riel p�dagogique, vous acceptez implicitement les
// conditions et la d�charge exprim�s ci-dessus.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PacManDevoir01
{
    /// <summary>
    /// Une palette de tuiles est essentiellement une texture contenant une s�rie de tuiles.
    /// Celles-ci peuvent servir soit � constituer un monde de tuiles (voir la classe MondeDeTuiles)
    /// ou les diff�rents mouvements d'animation d'un sprite (voir classe SpriteAnimation).
    /// </summary>
    public class Palette
    {
        /// <summary>
        /// Palette des tuiles.
        /// </summary>
        private Texture2D tuiles;

        /// <summary>
        /// Largeur d'une tuile en pixels.
        /// </summary>
        private int largeurTuile;

        /// <summary>
        /// Hauteur d'une tuile en pixels.
        /// </summary>
        private int hauteurTuile;

        /// <summary>
        /// Constructeur param�tr�.
        /// </summary>
        /// <param name="tuiles">Texture contenant les tuiles.</param>
        /// <param name="largeurTuile">Largeur uniforme de chaque tuile, en pixels.</param>
        /// <param name="hauteurTuile">Hauteur uniforme de chaque tuile, en pixels.</param>
        public Palette(Texture2D tuiles, int largeurTuile, int hauteurTuile)
        {
            this.tuiles = tuiles;

            this.largeurTuile = largeurTuile;
            this.hauteurTuile = hauteurTuile;
        }

        /// <summary>
        /// Accesseur pour l'attribut tuiles.
        /// </summary>
        public Texture2D Tuiles
        {
            get { return this.tuiles; }
        }

        /// <summary>
        /// Accesseur pour l'attribut largeurTuile.
        /// </summary>
        public int LargeurTuile
        {
            get { return this.largeurTuile; }
        }

        /// <summary>
        /// Accesseur pour l'attribut hauteurTuile.
        /// </summary>
        public int HauteurTuile
        {
            get { return this.hauteurTuile; }
        }

        /// <summary>
        /// Accesseur retournant le nombre de tuiles dans la palette, calcul�e selon
        /// la taille de la palette et les dimensions uniformes des tuiles.
        /// </summary>
        public int NombreDeTuiles
        {
            get
            {
                int tuilesParRangee = this.tuiles.Width / this.LargeurTuile;   // nombre de tuiles dans une rang�e de la palette
                int tuilesParColonne = this.tuiles.Height / this.HauteurTuile; // nombre de tuiles dans une colonne de la palette

                return tuilesParRangee * tuilesParColonne;
            }
        }

        /// <summary>
        /// Retourne un Rectangle aux coordonn�es de la tuile (en pixels) indiqu�e en argument.
        /// </summary>
        /// <param name="tuileIdx">Index de la tuile dont on veut obtenir les coordonn�es.</param>
        /// <returns>Rectangle contenant les coordonn�es de la tuile (en pixels) dans la palette.</returns>
        public Rectangle SourceRect(int tuileIdx)
        {
            int tuilesParRangee = this.tuiles.Width / this.LargeurTuile; // nombre de tuiles dans une rang�e de la palette

            int paletteRow = tuileIdx / tuilesParRangee;            // rang�e de la tuile vis�e
            int paletteCol = tuileIdx % tuilesParRangee;            // colonne de la tuile vis�e

            // Cr�er un Rectangle aux coordonn�es et dimensions de la tuile dans la palette.
            Rectangle sourceRect = new Rectangle(
                paletteCol * this.LargeurTuile,
                paletteRow * this.HauteurTuile,
                this.LargeurTuile,
                this.HauteurTuile);

            return sourceRect;
        }

        /// <summary>
        /// Affiche � l'�cran la tuile indiqu�e dans le rectangle destinataire fourni
        /// </summary>
        /// <param name="tuileIdx">Index de la tuile � afficher.</param>
        /// <param name="destRect">Position o� afficher la tuile � l'�cran.</param>
        /// <param name="spriteBatch">Gestionnaire d'affichage en batch aux p�riph�riques.</param>
        public void Draw(int tuileIdx, Rectangle destRect, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.tuiles, destRect, this.SourceRect(tuileIdx), Color.White);   // afficher la tuile
        }
    }
}
