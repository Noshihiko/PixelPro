using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Drawing;

namespace PixelPro
{
    public class MyImage
    {
        private string typeImage;

        private int tailleOffset;
        private int tailleFichier;

        private int largeur;
        private int hauteur;
        private int bitsCouleur;
        private string nomImage;

        private Pixel[,] image;

        #region Constructeurs de la classe MyImage

        /// <summary>
        /// Constructeur de la classe MyImage
        /// </summary>
        /// <param name="myfile"> string : le nom du fichier de l'image au format bmp </param>
        public MyImage(string myfile)
        {
            byte[] file = File.ReadAllBytes(myfile);

            this.typeImage = Convert.ToChar(file[0]).ToString() + Convert.ToChar(file[1]).ToString();

            this.tailleOffset = Convertir_Endian_To_Int(new byte[] { file[10], file[11], file[12], file[13] });
            this.tailleFichier = Convertir_Endian_To_Int(new byte[] { file[2], file[3], file[4], file[5] });

            this.largeur = Convertir_Endian_To_Int(new byte[] { file[18], file[19], file[20], file[21] });
            this.hauteur = Convertir_Endian_To_Int(new byte[] { file[22], file[23], file[24], file[25] });
            this.bitsCouleur = Convertir_Endian_To_Int(new byte[] { file[28], file[29] });
            this.nomImage = myfile;


            this.image = new Pixel[this.hauteur, this.largeur];

            int index = 54;
            for (int i = 0; i < this.hauteur; i++)
            {
                for (int j = 0; j < this.largeur; j++)
                {
                    this.image[i, j] = new Pixel(file[index], file[index + 1], file[index + 2]);
                    index += 3;
                }
            }
        }

        /// <summary>
        /// Constructeur de la classe MyImage
        /// </summary>
        /// <param name="image2"> MyImage : instance de la classe qui est recopié dans this </param>
        public MyImage(MyImage image2)
        {
            typeImage = image2.typeImage;

            tailleOffset = image2.tailleOffset;
            tailleFichier = image2.tailleFichier;

            largeur = image2.largeur;
            hauteur = image2.hauteur;
            bitsCouleur = image2.bitsCouleur;
            nomImage = image2.nomImage;

            image = image2.image;
        }

        /// <summary>
        /// Constructeur de la classe MyImage
        /// </summary>
        public MyImage()
        {
            typeImage = "BM";

            tailleOffset = 54;
            tailleFichier = tailleOffset;

            largeur = 0;
            hauteur = 0;
            bitsCouleur = 24;
            nomImage = "";

            image = new Pixel[0, 0];
        }

        #endregion

        #region Accès aux attributs de la classe MyImage

        /// <summary>
        /// get du string typeImage
        /// </summary>
        public string TypeImage
        {
            get { return typeImage; }
        }

        /// <summary>
        /// get de l'entier tailleOffset
        /// </summary>
        public int TailleOffset
             { get { return tailleOffset; }
        }

        /// <summary>
        /// get de l'entier tailleFichier
        /// </summary>
        public int TailleFichier
        { 
            get { return tailleFichier; } 
        }
        
        /// <summary>
        /// get de l'entier largeur
        /// </summary>
        public int Largeur
        { 
            get { return largeur; } 
        }

        /// <summary>
        /// get de l'entier hauteur
        /// </summary>
        public int Hauteur
        { 
            get { return hauteur; } 
        }

        /// <summary>
        /// get de l'entier bitsCouleur
        /// </summary>
        public int BitsCouleur
        {  
            get { return bitsCouleur; } 
        }

        /// <summary>
        /// get du string nomImage
        /// </summary>
        public string NomImage
        {
            get { return nomImage; }
        }

        /// <summary>
        /// get de la matrix Pixel[,] image
        /// </summary>
        public Pixel[,] Image
        {
            get { return image; } 
        }
        #endregion

        /// <summary>
        /// Convertie des bytes en base endian en un nombre entier
        /// </summary>
        /// <param name="tab"> la valeur à convertir </param>
        /// <returns> un entier correspondant au nombre endian associé </returns>
        public static int Convertir_Endian_To_Int(byte[] tab)
        {
            int calcul = 0;
            if (tab != null)
            {
                for (int i = 0; i < tab.Length; i++)
                {
                    calcul += (int)(tab[i] * Math.Pow(256, i));
                }
            }
            return calcul;
        }

        /// <summary>
        /// Convertie un nombre entier en base endian sous la forme d'un tableau de bytes
        /// </summary>
        /// <param name="val"> le nombre à convertir </param>
        /// <returns> un tableau de byte en base endian correspondant au nombre entier </returns>
        public static byte[] Convertir_Int_To_Endian(int val)
        {
            byte[] calcul = new byte[4] { 0, 0, 0, 0 };
            if (val > 0)
            {
                for (int i = 3; i >= 0; i--)
                {
                    int perm = (int)Math.Pow(256, i);
                    while (val - perm >= 0)
                    {
                        val -= perm;
                        calcul[i]++;
                    }
                }
            }
            return calcul;
        }

        /// <summary>
        /// Transforme l'instance this en une image au format bmp
        /// </summary>
        /// <param name="file"> chemin pour accéder à l'image </param>
        public void From_Image_To_File(string file)
        {
            int longueur = this.largeur * this.hauteur * 3;

            byte[] picture = new byte[this.tailleFichier + 54];
            byte[] tailleFichierB = Convertir_Int_To_Endian(this.tailleFichier);
            byte[] offsetB = Convertir_Int_To_Endian(this.tailleOffset);
            byte[] largeurB = Convertir_Int_To_Endian(this.largeur);
            byte[] hauteurB = Convertir_Int_To_Endian(this.hauteur);
            byte[] bitsCouleurB = Convertir_Int_To_Endian(this.bitsCouleur);
            byte[] longueurB = Convertir_Int_To_Endian(longueur);

            picture[0] = 66;
            picture[1] = 77;
            picture[14] = 40;
            picture[26] = 1;

            for (int i = 2; i < 6; i++)
            {
                picture[i] = tailleFichierB[i - 2];
            }
            for (int i = 10; i < 14; i++)
            {
                picture[i] = offsetB[i - 10];
            }
            for (int i = 18; i < 22; i++)
            {
                picture[i] = largeurB[i - 18];
            }
            for (int i = 22; i < 26; i++)
            {
                picture[i] = hauteurB[i - 22];
            }
            for (int i = 28; i < 30; i++)
            {
                picture[i] = bitsCouleurB[i - 28];

            }
            for (int i = 34; i < 38; i++)
            {
                picture[i] = longueurB[i - 34];
            }

            int index = 54;
            foreach (Pixel p in this.image)
            {
                picture[index] = p.Blue;
                picture[index + 1] = p.Green;
                picture[index + 2] = p.Red;
                index += 3;
            }
            File.WriteAllBytes(file, picture);
        }

        /// <summary>
        /// Agrandit l'image par un coefficient
        /// </summary>
        /// <param name="coeff"> entier positif correspondant au degré d'agrandissement </param>
        public void Agrandissement(int coeff)
        {
            if (coeff <= 1)
            {
                Console.WriteLine("Pas de modification de l'image car coeff <= 1.");
            }
            else
            {
                Pixel[,] newImage = new Pixel[this.hauteur * coeff, this.largeur * coeff];

                for (int i = 0; i < this.hauteur; i++)
                {
                    for (int j = 0; j < this.largeur; j++)
                    {
                        for (int k = i * coeff; k < i * coeff + coeff; k++)
                        {
                            for (int l = j * coeff; l < j * coeff + coeff; l++)
                            {

                                newImage[k, l] = new Pixel(this.image[i, j]);
                            }
                        }
                    }
                }
                this.largeur *= coeff;
                this.hauteur *= coeff;
                this.tailleFichier = (this.hauteur * this.largeur  * this.bitsCouleur) / 8 + this.tailleOffset;
                this.image = newImage;
            }
        }

        /// <summary>
        /// Tourne l'image à un certain angle
        /// </summary>
        /// <param name="angle"> entier positif correspondant au degré de rotation </param>
        public void Rotation(int angle)  //uniquement angle positif, possible de le faire pour angle négatif, faut juste rajouter condition dans les if avec modulo
        {
            Pixel[,] newImage = this.image;
            if(angle < 0)
            {
                angle *= -1;
            }
            else if (angle % 360 == 0)
            {
                Console.WriteLine("Pas de modification sur l'image car angle multiple de 360°.");
            }
            else if (angle % 360 == 90)
            {
                newImage = new Pixel[this.largeur, this.hauteur];
                for (int i = 0; i < this.largeur; i++)
                {
                    for (int j = 0; j < this.hauteur; j++)
                    {
                        newImage[i, j] = new Pixel(this.image[j, i]);
                    }
                }
                (this.largeur, this.hauteur) = (this.hauteur, this.largeur);    //réaffection des largeur/hauteur en les inversant
            }
            else if (angle % 360 == 180)
            {
                newImage = new Pixel[this.hauteur, this.largeur];
                for (int i = 0; i < this.hauteur; i++)
                {
                    for (int j = 0; j < this.largeur; j++)
                    {
                        newImage[i, j] = new Pixel(this.image[this.hauteur - 1 - i, this.largeur - 1 - j]);
                    }
                }
            }
            else if (angle % 360 == 270)
            {
                newImage = new Pixel[this.largeur, this.hauteur];
                for (int i = 0; i < this.largeur; i++)
                {
                    for (int j = 0; j < this.hauteur; j++)
                    {
                        newImage[i, j] = new Pixel(this.image[this.hauteur - 1 - j, this.largeur - 1 - i]);
                    }
                }
                (this.largeur, this.hauteur) = (this.hauteur, this.largeur);
            }
            else
            {
                double angleRadian = (Math.PI * angle) / 180; //conversion en radian

                int largeurModif = (int)(largeur * Math.Abs(Math.Cos(angleRadian)) + hauteur * Math.Abs(Math.Sin(angleRadian)));
                int hauteurModif = (int)(largeur * Math.Abs(Math.Sin(angleRadian)) + hauteur * Math.Abs(Math.Cos(angleRadian)));
                while (largeurModif % 4 != 0) //largeur doit etre multiple de 4 pour le moment
                {
                    largeurModif++;
                }

                newImage = new Pixel[hauteurModif, largeurModif];
                for (int i = 0; i < hauteurModif; i++)
                {
                    for (int j = 0; j < largeurModif; j++)
                    {
                        newImage[i, j] = new Pixel(); //initialisé en noir

                        int posLargeur = (int)(this.largeur / 2 + Math.Cos(angleRadian) * (j - largeurModif / 2) + Math.Sin(angleRadian) * (i - hauteurModif / 2));
                        int posHauteur = (int)(this.hauteur / 2 + Math.Cos(angleRadian) * (i - hauteurModif / 2) - Math.Sin(angleRadian) * (j - largeurModif / 2));

                        if ((posLargeur >= 0 && posLargeur < largeur) && (posHauteur >= 0 && posHauteur < hauteur)) //condition pour pouvoir aller dans la matrice image
                        {
                            newImage[i, j] = new Pixel(this.image[posHauteur, posLargeur]);
                        }
                    }
                }
                largeur = largeurModif;
                hauteur = hauteurModif;
                this.tailleFichier = this.tailleOffset + (largeur*hauteur*bitsCouleur/8) ;
            }
            this.image = newImage;
        }        

        /// <summary>
        /// Permet le calcul de convolution de la matrice image aver la matrice filter
        /// </summary>
        /// <param name="filter"> matrice de double correspondant au filtre appliquée sur l'image </param>
        /// <param name="factor">  </param>
        /// <param name="bias">  </param>
        /// <returns> la matrice calculée </returns>
        public Pixel[,] Convolution(double[,] filter, double factor = 1.0, double bias = 0.0)
        {
            int filterHeight = filter.GetLength(0);
            int filterWidth = filter.GetLength(1);

            Pixel[,] newImage = new Pixel[this.hauteur, this.largeur];

            for (int x = 0; x < largeur; x++)
            {
                for (int y = 0; y < hauteur; y++)
                {
                    double red = 0.0, green = 0.0, blue = 0.0;

                    for (int filterY = 0; filterY < filterHeight; filterY++)
                    {
                        for (int filterX = 0; filterX < filterWidth; filterX++)
                        {
                            int imageX = (x - filterWidth / 2 + filterX + largeur) % largeur;
                            int imageY = (y - filterHeight / 2 + filterY + hauteur) % hauteur;
                            if (imageX >= 0 && imageY >= 0 && imageX < largeur && imageY < hauteur)
                            {
                                Pixel p = image[imageY, imageX];
                                red += p.Red * filter[filterY, filterX];
                                green += p.Green * filter[filterY, filterX];
                                blue += p.Blue * filter[filterY, filterX];
                            }
                        }
                    }
                    byte resultR = Convert.ToByte(Math.Min(Math.Abs((int)(factor*red + bias)), 255));
                    byte resultG = Convert.ToByte(Math.Min(Math.Abs((int)(factor * green + bias)), 255));
                    byte resultB = Convert.ToByte(Math.Min(Math.Abs((int)(factor * blue + bias)), 255));
                    newImage[y, x] = new Pixel(resultB, resultG, resultR);
                }
            }
            Pixel[,] finalImage = new Pixel[this.hauteur - 4, this.largeur - 4];
            for(int i = 0; i < finalImage.GetLength(0); i++)
            {
                for(int j = 0; j < finalImage.GetLength(1); j++)
                {
                    finalImage[i,j] = newImage[i + 2, j + 2];
                }
            }
            return finalImage;  
        }

        #region Les différents filtres
        /// <summary>
        /// Applique un léger effet flou à l'image
        /// </summary>
        public void Blur()
        {
            double[,] filter ={
                { 0.0, 0.2,  0.0 },
                { 0.2, 0.2,  0.2 },
                { 0.0, 0.2,  0.0 }
            };

            double factor = 1.0;
            double bias = 0.0;
            this.image = Convolution(filter,factor,bias);
            this.hauteur = image.GetLength(0);
            this.largeur = image.GetLength(1);
            this.tailleFichier = (bitsCouleur * hauteur * largeur / 8) + tailleOffset;
        }

        /// <summary>
        /// Applique un effet flou plus intense à l'image
        /// </summary>
        public void BiggerBlur()
        {
            double[,] filter = {
                { 0, 0, 1, 0, 0 },
                { 0, 1, 1, 1, 0 },
                { 1, 1, 1, 1, 1 },
                { 0, 1, 1, 1, 0 },
                { 0, 0, 1, 0, 0 }
            };

            double factor = 1.0 / 13.0;
            double bias = 0.0;
            this.image = Convolution(filter, factor, bias);
            this.hauteur = image.GetLength(0);
            this.largeur = image.GetLength(1);
            this.tailleFichier = (bitsCouleur * hauteur * largeur / 8) + tailleOffset;
        }

        /// <summary>
        /// Applique un effet flou uniforme à l'image
        /// </summary>
        public void UniformBlur()
        {
            double[,] filter ={
                { 1.0, 1.0,  1.0 },
                { 1.0, 1.0,  1.0 },
                { 1.0, 1.0,  1.0 }
            };

            double factor = 1.0/9.0;
            double bias = 0.0; //si je mets un bias à -1000 ça fait des trucs très stylés
            this.image = Convolution(filter, factor, bias);
            this.hauteur = image.GetLength(0);
            this.largeur = image.GetLength(1);
            this.tailleFichier = (bitsCouleur * hauteur * largeur / 8) + tailleOffset;
        }

        /// <summary>
        /// Applique un effet flou gaussian à l'image
        /// </summary>
        /// <param name="taille"> taille de la matrice du filtre appliquée </param>
        public void GaussianBlur(int taille)
        {
            double sigma = Math.Max(taille/4.0, 1);
            double[,] filter = NoyauGaussian(taille, sigma );
            double coeff = 0;
           
            for(int i =  0; i < taille; i++)
            {
                for(int j =  0; j < taille; j++)
                {
                    coeff += filter[i, j];
                }
            }
            double factor = 1.0 / coeff;
            double bias = 0.0;

            this.image = Convolution(filter, factor, bias);
            this.hauteur = image.GetLength(0);
            this.largeur = image.GetLength(1);
            this.tailleFichier = (bitsCouleur * hauteur * largeur / 8) + tailleOffset;
        }

        /// <summary>
        /// Permet de calculer la matrice gaussienne souhaitée pour le filtre flou gaussian
        /// </summary>
        /// <param name="taille"> entier positif : taille de la matrice souhaitée </param>
        /// <param name="sigma">  </param>
        /// <returns> une matrice de double correspondant à la matrice gaussienne souhaitée pour le filtre flou gaussian </returns>
        private double[,] NoyauGaussian(int taille, double sigma)
        {
            if(taille%2 == 0)
            {
                taille++;
            }
            double[,] noyau = new double[taille, taille];
            double sum = 0;

            // Calculer le noyau gaussien
            for (int x = -taille / 2; x <= taille / 2; x++)
            {
                for (int y = -taille / 2; y <= taille / 2; y++)
                {
                    double exponent = -((x * x + y * y) / (2 * sigma * sigma));
                    noyau[x + taille / 2, y + taille / 2] = Math.Exp(exponent) / (2 * Math.PI * sigma * sigma);
                    sum += noyau[x + taille / 2, y + taille / 2];
                }
            }

            // Normaliser le noyau
            for (int i = 0; i < taille; i++)
            {
                for (int j = 0; j < taille; j++)
                {
                    noyau[i, j] /= sum;
                }
            }

            return noyau;
        }

        /// <summary>
        /// Applique l'effet de contour des bords de Prewitt à l'image
        /// </summary>
        /// <param name="couleur"> booléen permettant de déterminer s'il faut rajouter un filtre Noir et Blanc à l'image </param>
        public void Prewitt(bool couleur = false)
        {
            if (couleur)
            {
                Black_White();
            }
            double[,] detectionVerticale ={
                { -1.0,  0.0,  1.0 },
                { -1.0,  0.0,  1.0 },
                { -1.0,  0.0,  1.0 }
            };

            double[,] detectioHorizontale ={
                { -1.0, -1.0, -1.0 },
                {  0.0,  0.0,  0.0 },
                {  1.0,  1.0,  1.0 }
            };

            double factor = 1.0 / 3.0;
            double bias = 0.0;

            Pixel[,] p1 = Convolution(detectionVerticale,factor,bias);
            Pixel[,] p2 = Convolution(detectioHorizontale, factor, bias);
            this.hauteur = p1.GetLength(0);
            this.largeur = p1.GetLength(1);
            this.tailleFichier = (bitsCouleur * hauteur * largeur / 8) + tailleOffset;

            this.image = p1;
            for (int i = 0; i < p1.GetLength(0); i++)
            {
                for (int j = 0; j < p1.GetLength(1); j++)
                {
                    this.image[i, j] = Pixel.Add(p1[i, j], p2[i, j]);
                }
            }
        }

        /// <summary>
        /// Applique l'effet de contour des bords de Roberts à l'image
        /// </summary>
        /// <param name="couleur"> booléen permettant de déterminer s'il faut rajouter un filtre Noir et Blanc à l'image </param>
        public void Roberts(bool couleur = false)
        {
            if (couleur)
            {
                Black_White();
            }
            double[,] detectionDiago1 ={
                {  0.0,  0.0,  0.0 },
                {  0.0,  0.0,  1.0 },
                {  0.0, -1.0,  0.0 }
            };

            double[,] detectionDiago2 ={
                {  0.0,  0.0,  0.0 },
                {  0.0, -1.0,  0.0 },
                {  0.0,  0.0,  1.0 }
            };

            double factor = 1.0 / 3.0;
            double bias = 0.0;

            Pixel[,] p1 = Convolution(detectionDiago1, factor, bias);
            Pixel[,] p2 = Convolution(detectionDiago2, factor, bias);
            this.hauteur = p1.GetLength(0);
            this.largeur = p1.GetLength(1);
            this.tailleFichier = (bitsCouleur * hauteur * largeur / 8) + tailleOffset;

            this.image = p1;
            for (int i = 0; i < p1.GetLength(0); i++)
            {
                for (int j = 0; j < p1.GetLength(1); j++)
                {
                    this.image[i, j] = Pixel.Add(p1[i, j], p2[i, j]);
                }
            }
        }

        /// <summary>
        /// Applique l'effet de contour des bords de Sobel à l'image
        /// </summary>
        /// <param name="couleur"> booléen permettant de déterminer s'il faut rajouter un filtre Noir et Blanc à l'image </param>
        public void Sobel(bool couleur = false)
        {
            if (couleur)
            {
                Black_White();
            }
            double[,] detectionHorizontale ={
                { -1.0,  0.0,  1.0 },
                { -1.0,  0.0,  2.0 },
                { -1.0,  0.0,  1.0 }
            };

            double[,] detectionVerticale ={
                { -1.0, -2.0, -1.0 },
                {  0.0,  0.0,  0.0 },
                {  1.0,  2.0,  1.0 }
            };

            double factor = 1.0 / 4.0;
            double bias = 0.0;

            Pixel[,] p1 = Convolution(detectionHorizontale, factor, bias);
            Pixel[,] p2 = Convolution(detectionVerticale, factor, bias);
            this.hauteur = p1.GetLength(0);
            this.largeur = p1.GetLength(1);
            this.tailleFichier = (bitsCouleur * hauteur * largeur / 8) + tailleOffset;

            this.image = p1;
            for (int i = 0; i < p1.GetLength(0); i++)
            {
                for (int j = 0; j < p1.GetLength(1); j++)
                {
                    this.image[i, j] = Pixel.Add(p1[i, j], p2[i, j]);
                }
            }
        }

        /// <summary>
        /// Applique  l'effet de contour des bords de Kirsch à l'image
        /// </summary>
        /// <param name="couleur"> booléen permettant de déterminer s'il faut rajouter un filtre Noir et Blanc à l'image </param>
        public void Kirsch(bool couleur = false)
        {
            if (couleur)
            {
                Black_White();
            }
            double[,] detectionHorizontale ={
                { -3.0, -3.0, -3.0 },
                { -3.0,  0.0, -3.0 },
                {  5.0,  5.0,  5.0 }
            };

            double[,] detectionVerticale ={
                { -3.0, -3.0,  5.0 },
                { -3.0,  0.0,  5.0 },
                { -3.0, -3.0,  5.0 }
            };

            double factor = 1.0 / 15.0;
            double bias = 0.0;

            Pixel[,] p1 = Convolution(detectionHorizontale, factor, bias);
            Pixel[,] p2 = Convolution(detectionVerticale, factor, bias);
            this.hauteur = p1.GetLength(0);
            this.largeur = p1.GetLength(1);
            this.tailleFichier = (bitsCouleur * hauteur * largeur / 8) + tailleOffset;

            this.image = p1;
            for (int i = 0; i < p1.GetLength(0); i++)
            {
                for (int j = 0; j < p1.GetLength(1); j++)
                {
                    this.image[i, j] = Pixel.Add(p1[i, j], p2[i, j]);
                }
            }
        }

        /// <summary>
        /// Applique l'effet de contour des bords de MDIF à l'image
        /// </summary>
        /// <param name="couleur"> booléen permettant de déterminer s'il faut rajouter un filtre Noir et Blanc à l'image </param>
        public void MDIF(bool couleur = false)
        {
            if (couleur)
            {
                Black_White();
            }
            double[,] detectionHorizontale ={
                {  0.0, -1.0, -1.0, -1.0,  0.0 },
                { -1.0, -2.0, -3.0, -2.0, -1.0 },
                {  0.0,  0.0,  0.0,  0.0,  0.0 },
                {  1.0,  2.0,  3.0,  2.0,  1.0 },
                {  0.0,  1.0,  1.0,  1.0,  1.0 } 
            };

            double[,] detectionVerticale ={
                {  0.0, -1.0,  0.0,  1.0,  0.0 },
                { -1.0, -2.0,  0.0,  2.0,  1.0 },
                { -1.0, -3.0,  0.0,  3.0,  1.0 },
                { -1.0, -2.0,  0.0,  2.0,  1.0 },
                {  0.0, -1.0,  0.0,  1.0,  0.0 } 
            };

            double factor = 1.0 / 12.0;
            double bias = 0.0;

            Pixel[,] p1 = Convolution(detectionHorizontale, factor, bias);
            Pixel[,] p2 = Convolution(detectionVerticale, factor, bias);
            this.hauteur = p1.GetLength(0);
            this.largeur = p1.GetLength(1);
            this.tailleFichier = (bitsCouleur * hauteur * largeur / 8) + tailleOffset;

            this.image = p1;
            for (int i = 0; i < p1.GetLength(0); i++)
            {
                for (int j = 0; j < p1.GetLength(1); j++)
                {
                    this.image[i, j] = Pixel.Add(p1[i, j], p2[i, j]);
                }
            }
        }

        /// <summary>
        /// Applique l'effet de renforcement des bords à l'image
        /// </summary>
        public void RenforcementBord()
        {
            double[,] filter ={
                {  0.0,  -1.0,  0.0 },
                { -1.0,   5.0, -1.0 },
                {  0.0,  -1.0,  0.0 }
            };


            double factor = 1.0;
            double bias = 0.0;
            this.image = Convolution(filter, factor, bias);
            this.hauteur = image.GetLength(0);
            this.largeur = image.GetLength(1);
            this.tailleFichier = (bitsCouleur * hauteur * largeur / 8) + tailleOffset;
        }

        /// <summary>
        /// Applique l'effet de repoussage des bords à l'image
        /// </summary>
        public void Repoussage()
        {
            double[,] filter ={
                { -1.0,  -1.0,  0.0 },
                { -1.0,   0.0,  1.0 },
                {  0.0,   1.0,  1.0 }
            };


            double factor = 1.0;
            double bias = 128.0;
            this.image = Convolution(filter, factor, bias);
            this.hauteur = image.GetLength(0);
            this.largeur = image.GetLength(1);
            this.tailleFichier = (bitsCouleur * hauteur * largeur / 8) + tailleOffset;
        }

        /// <summary>
        /// Transforme l'image en noir et blanc
        /// </summary>
        public void Black_White()
        {
            for (int i = 0; i < hauteur; i++)
            {
                for (int j = 0; j < largeur; j++)
                {
                    image[i, j].B_and_W();
                }
            }
        }
        #endregion

        /// <summary>
        /// Dessine une image fractale sur this
        /// </summary>
        /// <param name="coloree"> boolean pour déterminer si la fractale sera en noir et blanc ou colorée </param>
        public void Fractale(bool coloree)
        {
            double largeurMin = -2.1;
            double largeurMax = 0.6;

            double hauteurMin = -1.2;
            double hauteurMax = 1.2;

            int zoom = 1000;
            int iterationMax = 100;

            int imageLargeur = (int)(zoom * (largeurMax - largeurMin));
            int imageHauteur = (int)(zoom * (hauteurMax - hauteurMin));

            while (imageHauteur % 4 != 0) //hauteur et largeur doivent etre multiples de 4 
            {
                imageHauteur--;
            }

            while (imageLargeur % 4 != 0) 
            {
                imageLargeur--;              
            }


            Pixel[,] newImage = new Pixel[imageHauteur, imageLargeur];

            for(int i = 0; i <  imageHauteur; i++)
            {
                for(int j = 0; j < imageLargeur; j++)
                {
                    newImage[i, j] = new Pixel(255,255,255);

                    double cReel = (double)j / zoom + largeurMin;
                    double cImaginaire = (double)i / zoom + hauteurMin;

                    double zReel = 0;
                    double zImaginaire = 0;

                    int index = 0;

                    do
                    {
                        double tmp = zReel;
                        zReel = zReel * zReel - zImaginaire * zImaginaire + cReel;
                        zImaginaire = 2 * zImaginaire * tmp + cImaginaire;
                        index++;

                    }
                    while (index < iterationMax && (zReel * zReel + zImaginaire * zImaginaire < 4));
                   
                    
                    if (index == iterationMax)
                    {
                        newImage[i, j] = new Pixel();
                    }
                    else if(coloree)
                    {
                        newImage[i, j] = new Pixel(Convert.ToByte(index * 255 / iterationMax), 0, Convert.ToByte(index * 255 / iterationMax));
                    }
                    
                   
                }
            }
            this.image = newImage;
            this.hauteur = imageHauteur;
            this.largeur = imageLargeur;
            this.tailleFichier = this.largeur * this.hauteur * this.bitsCouleur / 8 + this.tailleOffset;

        }

        /// <summary>
        /// Code une image cachée dans l'instance this
        /// </summary>
        /// <param name="image2"> instance de MyImage à cacher dans this </param>
        public void CoderImage(MyImage image2)
        {
            if (image2.hauteur > this.hauteur || image2.largeur > this.largeur)
            {
                Console.WriteLine("Impossible de cacher cette image car ses dimensions sont plus grandes que celles d'origine.");
            }
            else
            {
                Pixel[,] newImage = new Pixel[this.hauteur, this.largeur];

                for (int i = 0; i < hauteur; i++)
                {
                    for (int j = 0; j < largeur; j++)
                    {
                        newImage[i, j] = new Pixel();
                        string pixelRed = "00000000";
                        string pixelGreen = "00000000";
                        string pixelBlue = "00000000";

                        if (i < image2.hauteur && j < image2.largeur)
                        {
                            pixelRed = Convert.ToString(this.image[i, j].Red, 2).PadLeft(8, '0').Substring(0, 4) + Convert.ToString(image2.image[i, j].Red, 2).PadLeft(8, '0').Substring(0, 4);
                            pixelGreen = Convert.ToString(this.image[i, j].Green, 2).PadLeft(8, '0').Substring(0, 4) + Convert.ToString(image2.image[i, j].Green, 2).PadLeft(8, '0').Substring(0, 4);
                            pixelBlue = Convert.ToString(this.image[i, j].Blue, 2).PadLeft(8, '0').Substring(0, 4) + Convert.ToString(image2.image[i, j].Blue, 2).PadLeft(8, '0').Substring(0, 4);
                        }
                        else
                        {
                            pixelRed = Convert.ToString(image[i, j].Red, 2).PadLeft(8, '0').Substring(0, 4).PadRight(8, '0');
                            pixelGreen = Convert.ToString(image[i, j].Green, 2).PadLeft(8, '0').Substring(0, 4).PadRight(8, '0');
                            pixelBlue = Convert.ToString(image[i, j].Blue, 2).PadLeft(8, '0').Substring(0, 4).PadRight(8, '0');
                        }
                        newImage[i, j].Red = Convert.ToByte(pixelRed, 2);
                        newImage[i, j].Green = Convert.ToByte(pixelGreen, 2);
                        newImage[i, j].Blue = Convert.ToByte(pixelBlue, 2);
                    }
                }
                this.image = newImage;
            }
        }

        /// <summary>
        /// Décode une image cachée dans l'instance this
        /// </summary>
        /// <returns> MyImage : l'image cachée </returns>
        public MyImage DecoderImage()
        {
            MyImage imageCachee = new MyImage(this);
            Pixel[,] oldImage = new Pixel[hauteur, largeur];
            Pixel[,] hiddenImage = new Pixel[hauteur, largeur];
            
            for (int i = 0; i < hauteur; i++)
            {
                for(int j = 0; j < largeur; j++)
                { 
                    string pixelRed = Convert.ToString(this.image[i, j].Red, 2).PadLeft(8, '0');
                    string pixelGreen = Convert.ToString(this.image[i, j].Green, 2).PadLeft(8, '0');
                    string pixelBlue = Convert.ToString(this.image[i, j].Blue, 2).PadLeft(8, '0');

                    byte Red = Convert.ToByte(pixelRed.Substring(0, 4).PadRight(8, '0'), 2);
                    byte Green = Convert.ToByte(pixelGreen.Substring(0, 4).PadRight(8, '0'), 2);
                    byte Blue = Convert.ToByte(pixelBlue.Substring(0, 4).PadRight(8, '0'), 2);

                    oldImage[i, j] = new Pixel(Blue, Green, Red);

                    Red = Convert.ToByte(pixelRed.Substring(4,4).PadRight(8, '0'), 2);
                    Green = Convert.ToByte(pixelGreen.Substring(4,4).PadRight(8, '0'), 2);
                    Blue = Convert.ToByte(pixelBlue.Substring(4,4).PadRight(8, '0'), 2);

                    hiddenImage[i,j] = new Pixel(Blue, Green, Red);
                }
            }
            this.image = oldImage;
            imageCachee.image = hiddenImage;
            return imageCachee;
        }

        /// <summary>
        /// Retourne la matrice de bytes image sous la forme d'un string
        /// </summary>
        /// <returns> string : la matrice de bytes image </returns>
        public string toStringImage()
        {
            string result = "";
            for(int i = 0; i < hauteur; i++)
            {
                for(int j = 0; j < largeur; j++)
                {
                    result += image[i, j].toStringGBR() + " ";
                }
                result += "\n";
            }
            return result;
        }

        public void CompressionJPEG(int[,] quantification)
        {
            int [,][] imageModif = new int[hauteur, largeur][];
            Pixel p;

            #region Transformation de couleurs
            for (int i = 0; i < hauteur; i++)
            {
                for(int j = 0; j < largeur; j++)
                {
                    p = image[i,j];
                    int Y = (int)Math.Max(Math.Min(0.299 * p.Red + 0.087 * p.Green + 0.114 * p.Blue, Byte.MaxValue), Byte.MinValue);
                    int Cb = (int)Math.Max(Math.Min(-0.1687 *p.Red - 0.3313 * p.Green + 0.5 * p.Blue + 128, Byte.MaxValue), Byte.MinValue);
                    int Cr = (int)Math.Max(Math.Min(0.5 * p.Red - 0.4187 * p.Green - 0.0813 * p.Blue + 128, Byte.MaxValue), Byte.MinValue);

                    imageModif[i,j] = new int[3] { Y, Cb, Cr };
                }
            }
            #endregion

            #region Sous-échantillonage 4:2:0
            for (int i = 1; i < hauteur; i*=2)
            {
                for(int j = 1; j < largeur; j*=4)
                {
                    int moyCb = (int)Math.Max(Math.Min((imageModif[i - 1, j - 1][1] + imageModif[i, j][1] + imageModif[i + 1, j + 1][1] + imageModif[i + 2, j + 2][1]) / 4, Byte.MaxValue), Byte.MinValue);
                    int moyCr = (int)Math.Max(Math.Min((imageModif[i - 1, j - 1][2] + imageModif[i, j][2] + imageModif[i + 1, j + 1][2] + imageModif[i + 2, j + 2][2]) / 4, Byte.MaxValue), Byte.MinValue);
                    
                    imageModif[i - 1, j - 1][1] = moyCb;
                    imageModif[i - 1, j - 1][2] = moyCr;
                    
                    imageModif[i, j][1] = 0;
                    imageModif[i, j][2] = 0;
                    
                    imageModif[i + 1, j + 1][1] = 0;
                    imageModif[i + 1, j + 1][2] = 0;
                        
                    imageModif[i + 2, j + 2][1] = 0;
                    imageModif[i + 2, j + 2][2] = 0;
                }
            }
            #endregion

            #region Découpage 8 par 8 && DCT && Quantification

            int hauteurModif = hauteur;
            int largeurModif = largeur;
            
            while(hauteurModif % 8 != 0)
            {
                hauteurModif++;
            }
            while (largeurModif % 8 != 0)
            {
                largeurModif++;
            }
            
            int nbrMatriceHauteur = hauteurModif / 8;
            int nbrMatriceLargeur = largeurModif / 8;
            int nbrMatriceTotale = nbrMatriceHauteur * nbrMatriceLargeur;
           
            int[][,][] matriceDecoupage = new int[nbrMatriceTotale][,][];
            int[][,][] matriceDCT = new int[nbrMatriceTotale][,][];
            int[][,][] matriceQuantifiee = new int[nbrMatriceTotale][,][];


            for (int i = 0; i < nbrMatriceTotale; i++)
            {
                matriceDecoupage[i] = new int[8, 8][];
                matriceDCT[i] = new int[8, 8][];
                matriceQuantifiee[i] = new int[8, 8][];
                
                //Remplissage matrice découpée
                for(int j  = 0; j < 8; j++)
                {
                    for(int k = 0; k < 8; k++)
                    {
                        if (8 * i - 1 + j < hauteur && 8 * i - 1 + k < largeur)
                        {
                            matriceDecoupage[i][j, k] = imageModif[8 * i - 1 + j, 8 * i - 1 + k];
                        }
                        else
                        {
                            matriceDecoupage[i][j, k] = new int[3] { imageModif[8 * i - 1 + j, 8 * i - 1 + k][0], 0, 0 };
                        }
                    }
                }

                //Calcul DCT 
                for (int l = 0; l < 3; l++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        for (int k = 0; k < 8; k++)
                        {
                            for(int x = 0; x < 8; x++)
                            {
                                for (int y = 0; y < 8; y++)
                                {
                                    if (x == 0 && y == 0)
                                    {
                                        matriceDCT[i][j, k][l] += (int)(0.25 * matriceDecoupage[i][x, y][l] * Math.Cos((2 * x + 1) * j * Math.PI / 16) * Math.Cos((2 * y + 1) * k * Math.PI / 16) * 1/2); //rajouter c(x)c(y)
                                    }
                                    else if(x == 0 || y == 0)
                                    {
                                        matriceDCT[i][j, k][l] += (int)(0.25 * matriceDecoupage[i][x, y][l] * Math.Cos((2 * x + 1) * j * Math.PI / 16) * Math.Cos((2 * y + 1) * k * Math.PI / 16) * 1 /(Math.Sqrt(2))); //rajouter c(x)c(y)
                                    }
                                    else
                                    {
                                        matriceDCT[i][j, k][l] += (int)(0.25 * matriceDecoupage[i][x, y][l] * Math.Cos((2 * x + 1) * j * Math.PI / 16) * Math.Cos((2 * y + 1) * k * Math.PI / 16)); //rajouter c(x)c(y)
                                    }
                                }
                            }
                        }
                    }
                }
                
                //Calcul quantifiée
                for(int l = 0; l < 3; l++)
                {
                    for(int j = 0; j < 8; j++)
                    {
                        for(int k = 0; k < 8; k++)
                        {
                            matriceQuantifiee[i][j, k][l] = (int)(matriceDCT[i][j, k][l] + (int)(matriceQuantifiee[i][j, k][l] / 2) / matriceQuantifiee[i][j, k][l]);
                        }  
                    }
                }

                #endregion

            



            }
        }
    }
}

