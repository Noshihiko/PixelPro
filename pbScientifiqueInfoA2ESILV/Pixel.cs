using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelPro
{
    public class Pixel
    {
        private Byte red;
        private Byte green;
        private Byte blue;

        #region Constructeurs de la classe Pixel
        /// <summary>
        /// Constructeur de la classe Pixel
        /// </summary>
        /// <param name="blue"> byte pour la couleur bleue </param>
        /// <param name="green"> byte pour la couleur verte </param>
        /// <param name="red"> byte pour la couleur rouge </param>
        public Pixel(Byte blue, Byte green, Byte red)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
        }

        /// <summary>
        /// Constructeur de la classe Pixel permettant de créer une instance de Pixel à partir d'une autre
        /// </summary>
        /// <param name="a"> Pixel </param>
        public Pixel(Pixel a)
        {
            this.red = a.red;
            this.green = a.green;
            this.blue = a.blue;
        }

        /// <summary>
        /// Constructeur de la classe Pixel implémentant les bytes à 0
        /// </summary>
        public Pixel()
        {
            this.red = 0;
            this.green = 0;
            this.blue = 0;
        }
        #endregion

        #region Accès aux attributs de la classe Pixel
        /// <summary>
        /// Get et set du byte red
        /// </summary>
        public Byte Red
        {
            get { return this.red; }
            set { this.red = value; }
        }

        /// <summary>
        /// Get et set du byte green
        /// </summary>
        public Byte Green
        {
            get { return this.green; }
            set { this.green = value; }
        }

        /// <summary>
        /// Get et set du byte bleu
        /// </summary>
        public Byte Blue
        {
            get { return this.blue; }
            set { this.blue = value; }
        }
        #endregion

        /// <summary>
        /// Ajoute deux Pixels et leurs bytes entre eux
        /// </summary>
        /// <param name="p1"> Pixel à ajouter </param>
        /// <param name="p2"> Pixel à ajouter </param>
        /// <returns> Pixel résultant de l'ajout des deux autres </returns>
        public static Pixel Add(Pixel p1, Pixel p2)
        {
            Pixel result = new Pixel();
            result.blue = Convert.ToByte((Convert.ToInt16(p1.Blue) + Convert.ToInt16(p2.Blue)) % Byte.MaxValue);
            result.green = Convert.ToByte((Convert.ToInt16(p1.Green) + Convert.ToInt16(p2.Green)) % Byte.MaxValue);
            result.red = Convert.ToByte((Convert.ToInt16(p1.Red) + Convert.ToInt16(p2.Red)) % Byte.MaxValue);
            return result;
        }

        /// <summary>
        /// Transforme le pixel en son équivalent en noir et blanc
        /// </summary>
        public void B_and_W()
        {
            int BW = (int)(0.299 * Convert.ToInt32(red) + 0.587*Convert.ToInt32(green) + 0.114*Convert.ToInt32(blue));
            byte bw = Convert.ToByte(BW % 255);
            this.red = bw;
            this.blue = bw;
            this.green = bw;
        }

        /// <summary>
        /// Renvoie le pixel sous la forme d'un string en affichage BGR
        /// </summary>
        /// <returns> string : écriture du pixel en BGR </returns>
        public string toStringGBR()
        {
            string result = Convert.ToString(this.blue);
            if (this.blue <= 9)
            {
                result += " "; 
            }
            result += " " + Convert.ToString(this.green);
            if (this.green <= 9)
            {
                result += " ";
            }
            result += " " + Convert.ToString(this.red);
            if(this.red <= 9)
            {
                result += " ";
            }
            return result;
        }
    }
}
