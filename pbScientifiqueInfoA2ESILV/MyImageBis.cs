using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelPro
{
    public class MyImageBis
    {
        private string typeImage;
        private int tailleFichier;
        private int tailleOffset;
        private int largeur;
        private int hauteur;
        private int bitsCouleur;

        private byte[,] image;

        public MyImageBis(string myfile)
        {
            byte[] file = File.ReadAllBytes(myfile);

            this.typeImage = Convert.ToChar(file[0]).ToString() + Convert.ToChar(file[1]).ToString();

            this.tailleFichier = Convertir_Endian_To_Int(new byte[] { file[2], file[3], file[4], file[5] });
            this.tailleOffset = Convertir_Endian_To_Int(new byte[] { file[10], file[11], file[12], file[13] });
            
            this.largeur = Convertir_Endian_To_Int(new byte[] { file[18], file[19], file[20], file[21] });
            this.hauteur = Convertir_Endian_To_Int(new byte[] { file[22], file[23], file[24], file[25] });
            this.bitsCouleur = Convertir_Endian_To_Int(new byte[] { file[28], file[29] });

            this.image = new byte[hauteur, largeur * 3];
            int index = 54;
            for (int i = 0; i < image.GetLength(0); i++)
            {
                for (int j = 0; j < image.GetLength(1); j++)
                {
                    this.image[i, j] = file[index];
                    index++;
                    if (image[i, j] > 9)
                    {
                        Console.Write(image[i, j] + " ");
                    }
                    else
                    {
                        Console.Write(image[i, j] + "   ");
                    }
                }
                Console.WriteLine();
            }
            //for (int j = 0; j < image.GetLength(1); j++)
            //{
            //    Console.Write(image[0, j] + "  ");
            //}
            //Console.WriteLine("Temoin");
            //for (int i = 0; i < 14; i++)
            //{
            //    Console.Write(file[i] + " ");
            //}

            //Console.WriteLine("\n\nHEADER INFO");
            //for (int i = 14; i < 54; i++)
            //{
            //    Console.Write(file[i] + " ");
            //}
        }
        public void From_Image_To_File(string file)
        {
            int longueur = largeur*hauteur*3;
 
            byte[] picture = new byte[tailleFichier + 54];
            byte[] tailleFichierB = Convertir_Int_To_Endian(tailleFichier);
            byte[] offsetB = Convertir_Int_To_Endian(tailleOffset);
            byte[] largeurB = Convertir_Int_To_Endian(largeur);
            byte[] hauteurB = Convertir_Int_To_Endian(hauteur);
            byte[] bitsCouleurB = Convertir_Int_To_Endian(bitsCouleur);
            byte[] longueurB = Convertir_Int_To_Endian(longueur);
            
            picture[0] = 66;
            picture[1] = 77;
            for (int i = 2; i < 6; i++)
            {
                picture[i] = tailleFichierB[i - 2];
            }
            //for (int i = 6; i < 10; i++)
            //{
            //    picture[i] = 0;
            //}            
            for(int i = 10; i < 14; i++)
            {
                picture[i] = offsetB[i - 10];
            }
            picture[14] = 40;
            //picture[15] = 0;
            //picture[16] = 0;
            //picture[17] = 0;
            for (int i = 18; i < 22; i++)
            {
                picture[i] = largeurB[i - 18];
            }
            for (int i = 22; i < 26; i++)
            {
                picture[i] = hauteurB[i - 22];
            }
            picture[26] = 1;
            //picture[27] = 0;
            for (int i = 28; i < 30; i++)
            {
                picture[i] = bitsCouleurB[i - 28];
                
            }
            //for (int i = 30; i < 54; i++)
            //{
            //    picture[i] = 0;
            //}
            for(int i = 34; i < 38; i++)
            {
                picture[i] = longueurB[i - 34];
            }

            //Console.WriteLine("\nConversion");
            //for (int i = 0; i < 14; i++)
            //{
            //    Console.Write(picture[i] + " ");
            //}

            //Console.WriteLine("\n\nHEADER INFO");
            //for (int i = 14; i < 54; i++)
            //{
            //    Console.Write(picture[i] + " ");
            //}
            int index = 54;
            foreach(byte b in image)
            {
                picture[index] = b;
                index++;
            }
            File.WriteAllBytes(file, picture);
        }

        public int Convertir_Endian_To_Int(byte[] tab)
        {
            int calcul = 0;
            if(tab != null)
            {
                for(int i = 0; i < tab.Length; i++)
                {
                    calcul += (int)(tab[i] * Math.Pow(256, i));
                }
            }
            return calcul;
        }

        public byte[] Convertir_Int_To_Endian(int val)
        {
            byte[] calcul = new byte[4]{ 0, 0, 0, 0 };
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

        public void Agrandissement(int coeff) //à modifier, il faut que ça repete les données par groupe de 3 pour respecter les RGB de l'image
        {
            if(coeff <= 1)
            {
                Console.WriteLine("Pas de modification de l'image");
            }
            else
            {
                byte[,] newImage = new byte[hauteur * coeff, largeur * coeff * 3];
                for(int i = 0; i < hauteur; i++)
                {
                    for(int j = 0; j < largeur*3; j++)
                    {
                        for (int k = i * coeff; k < i * coeff + coeff; k++) //Augmente mais mauvaises couleurs
                        {
                            for (int l = j * coeff; l < j * coeff + coeff; l++)
                            {
                                newImage[k, l] = image[i, j];

                            }

                        }
                        //for (int k = i * coeff; k < i * coeff + coeff; k++)  //Dédouble image
                        //{
                        //    for(int l = 0; l < coeff; l ++)
                        //    {
                        //        newImage[k, j + largeur * 3 * l] = image[i, j];
                        //    }

                        //}
                        //for (int k = i * coeff; k < i * coeff + coeff; k++) 
                        //{
                        //    for (int l = 0; l < coeff; l++)
                        //    {
                        //        newImage[k, j + 3 * l] = image[i, j];
                        // }
                        //}
                    }
                }
                this.largeur *= coeff;
                this.hauteur *= coeff;
                this.tailleFichier = hauteur * coeff * largeur * coeff;

                Console.WriteLine("\n\nnew matrix\n\n");
                for (int i = 0; i < newImage.GetLength(0); i++)
                {
                    for (int j = 0; j < newImage.GetLength(1); j++)
                    {
                        //Console.Write(newImage[i, j] + " ");
                        if (newImage[i, j] > 9)
                        {
                            Console.Write(newImage[i, j] + " ");
                        }
                        else
                        {
                            Console.Write(newImage[i, j] + "   ");
                        }
                    }
                    Console.WriteLine();
                }
                for (int j = 0; j < newImage.GetLength(1); j++)
                {
                    Console.Write(newImage[0, j] + "  ");
                }
                this.image = newImage;

            }
        }
    }
}
