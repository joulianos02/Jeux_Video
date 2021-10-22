using Microsoft.Xna.Framework;

namespace PacManDevoir01
{
    public class FormeEnglobante
    {
       //creation de forme englobante
        public FormeEnglobante(Vector2 position, float largeur, float hauteur)
        {
            Position = position;
            Largeur = largeur;
            Hauteur = hauteur;
        }

        //creation de variable pour definir les coordonnees
        public Vector2 Position { get; set; }
        public float Largeur { get; set; }
        public float Hauteur { get; set; }

        public Rectangle Rectangle => new((int)Position.X, (int)Position.Y, (int)Largeur, (int)Hauteur);

        /// <summary>
        /// Utilisation de la méthode AABB
        /// </summary>
        public bool EnCollisionAvec(FormeEnglobante autreFormeEnglobante) =>
                Position.X < autreFormeEnglobante.Position.X + autreFormeEnglobante.Largeur &&
                Position.X + Largeur > autreFormeEnglobante.Position.X &&
                Position.Y < autreFormeEnglobante.Position.Y + autreFormeEnglobante.Hauteur &&
                Position.Y + Hauteur > autreFormeEnglobante.Position.Y;


        /// <summary>
        /// Avec une ligne.
        /// </summary>
        /// <param name="segment"></param>
        /// <returns></returns>
        public bool EnCollisionAvec(Segment segment) =>
            EnCollisionAvec(segment.P1) || EnCollisionAvec(segment.P2);

        /// <summary>
        /// Avec un point.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool EnCollisionAvec(Vector2 p) =>
            p.X < Position.X + Largeur &&
            p.X > Position.X &&
            p.Y < Position.Y + Hauteur &&
            p.Y > Position.Y;

    }
}
