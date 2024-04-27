using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.ComponentModel;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace PixelPro
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
            Console.ReadKey();

            #region Test Coder/décoder et Fractale
            //String fichierEntree = "./Images/coco.bmp";
            //MyImage coco = new MyImage("./Images/coco.bmp");
            //Console.WriteLine(coco.nomImage);
            //MyImage lac = new MyImage("./Images/lac.bmp");


            //lac.CoderImage(coco);
            //lac.From_Image_To_File("./Images/TestCacher.bmp");

            //MyImage imageDecodee = lac.DecoderImage();
            //lac.From_Image_To_File("./Images/TestDecoder1.bmp");
            //imageDecodee.From_Image_To_File("./Images/TestDecoder2.bmp");

            //lac.Fractale(false);
            //lac.From_Image_To_File("./Images/Fractale.bmp");
            //lac.Fractale(true);
            //lac.From_Image_To_File("./Images/FractaleColoreeMegaStylax.bmp");
            #endregion

            #region Test Contour
            //string fichierEntree = "./Images/lena.bmp";

            //MyImage image = new MyImage(fichierEntree);
            //image.Prewitt(true);
            //image.From_Image_To_File("./Images/Contour/LennaPrewitt.bmp");

            //image = new MyImage(fichierEntree);
            //image.Roberts(true);
            //image.From_Image_To_File("./Images/Contour/LennaRoberts.bmp");

            //image = new MyImage(fichierEntree);
            //image.Sobel(true);
            //image.From_Image_To_File("./Images/Contour/LennaSobel.bmp");

            //image = new MyImage(fichierEntree);
            //image.Kirsch(true);
            //image.From_Image_To_File("./Images/Contour/LennaKirsch.bmp");

            //image = new MyImage(fichierEntree);
            //image.MDIF(true);
            //image.From_Image_To_File("./Images/Contour/LennaMDIF.bmp");


            //fichierEntree = "./Images/Test.bmp";

            //image = new MyImage(fichierEntree);
            //image.Prewitt();
            //image.From_Image_To_File("./Images/Contour/TestPrewitt.bmp");

            //image = new MyImage(fichierEntree);
            //image.Roberts();
            //image.From_Image_To_File("./Images/Contour/TestRoberts.bmp");

            //image = new MyImage(fichierEntree);
            //image.Sobel();
            //image.From_Image_To_File("./Images/Contour/TestSobel.bmp");

            //image = new MyImage(fichierEntree);
            //image.Kirsch();
            //image.From_Image_To_File("./Images/Contour/TestKirsch.bmp");

            //image = new MyImage(fichierEntree);
            //image.MDIF();
            //image.From_Image_To_File("./Images/Contour/TestMDIF.bmp");


            //fichierEntree = "./Images/lac.bmp";

            //image = new MyImage(fichierEntree);
            //image.Prewitt(true);
            //image.From_Image_To_File("./Images/Contour/lacPrewitt.bmp");

            //image = new MyImage(fichierEntree);
            //image.Roberts(true);
            //image.From_Image_To_File("./Images/Contour/lacRoberts.bmp");

            //image = new MyImage(fichierEntree);
            //image.Sobel(true);
            //image.From_Image_To_File("./Images/Contour/lacSobel.bmp");

            //image = new MyImage(fichierEntree);
            //image.Kirsch(true);
            //image.From_Image_To_File("./Images/Contour/lacKirsch.bmp");

            //image = new MyImage(fichierEntree);
            //image.MDIF(true);
            //image.From_Image_To_File("./Images/Contour/lacMDIF.bmp");


            //fichierEntree = "./Images/coco.bmp";

            //image = new MyImage(fichierEntree);
            //image.Prewitt(true);
            //image.From_Image_To_File("./Images/Contour/cocoPrewitt.bmp");

            //image = new MyImage(fichierEntree);
            //image.Roberts(true);
            //image.From_Image_To_File("./Images/Contour/cocoRoberts.bmp");

            //image = new MyImage(fichierEntree);
            //image.Sobel(true);
            //image.From_Image_To_File("./Images/Contour/cocoSobel.bmp");

            //image = new MyImage(fichierEntree);
            //image.Kirsch(true);
            //image.From_Image_To_File("./Images/Contour/cocoKirsch.bmp");

            //image = new MyImage(fichierEntree);
            //image.MDIF(true);
            //image.From_Image_To_File("./Images/Contour/cocoMDIF.bmp");
            #endregion

            #region Test Renforcement & Repoussage
            //fichierEntree = "./Images/Test.bmp";

            //image = new MyImage(fichierEntree);
            //image.RenforcementBord();
            //image.From_Image_To_File("./Images/Renforce/TestRenforcement.bmp");

            //image = new MyImage(fichierEntree);
            //image.Repoussage();
            //image.From_Image_To_File("./Images/Repousse/TestRepoussage.bmp");


            //fichierEntree = "./Images/lac.bmp";

            //image = new MyImage(fichierEntree);
            //image.RenforcementBord();
            //image.From_Image_To_File("./Images/Renforce/lacRenforcement.bmp");

            //image = new MyImage(fichierEntree);
            //image.Repoussage();
            //image.From_Image_To_File("./Images/Repousse/lacRepoussage.bmp");


            //fichierEntree = "./Images/coco.bmp";

            //image = new MyImage(fichierEntree);
            //image.RenforcementBord();
            //image.From_Image_To_File("./Images/Renforce/cocoRenforcement.bmp");

            //image = new MyImage(fichierEntree);
            //image.Repoussage();
            //image.From_Image_To_File("./Images/Repousse/cocoRepoussage.bmp");
            #endregion

            #region Test Flou
            //fichierEntree = "./Images/Test.bmp";

            //image = new MyImage(fichierEntree);
            //image.Blur();
            //image.From_Image_To_File("./Images/Flou/TestBlur.bmp");

            //image = new MyImage(fichierEntree);
            //image.BiggerBlur();
            //image.From_Image_To_File("./Images/Flou/TestBlurBigger.bmp");

            //image = new MyImage(fichierEntree);
            //image.UniformBlur();
            //image.From_Image_To_File("./Images/Flou/TestUniformBlur.bmp");

            //image = new MyImage(fichierEntree);
            //image.GaussianBlur(3);
            //image.From_Image_To_File("./Images/Flou/TestGaussianBlur.bmp");


            //fichierEntree = "./Images/coco.bmp";

            //image = new MyImage(fichierEntree);
            //image.Blur();
            //image.From_Image_To_File("./Images/Flou/cocoBlur.bmp");

            //image = new MyImage(fichierEntree);
            //image.BiggerBlur();
            //image.From_Image_To_File("./Images/Flou/cocoBlurBigger.bmp");

            //image = new MyImage(fichierEntree);
            //image.UniformBlur();
            //image.From_Image_To_File("./Images/Flou/cocoUniformBlur.bmp");

            //image = new MyImage(fichierEntree);
            //image.GaussianBlur(3);
            //image.From_Image_To_File("./Images/Flou/cocoGaussianBlur.bmp");


            //fichierEntree = "./Images/lac.bmp";

            //image = new MyImage(fichierEntree);
            //image.Blur();
            //image.From_Image_To_File("./Images/Flou/lacBlur.bmp");

            //image = new MyImage(fichierEntree);
            //image.BiggerBlur();
            //image.From_Image_To_File("./Images/Flou/lacBlurBigger.bmp");

            //image = new MyImage(fichierEntree);
            //image.UniformBlur();
            //image.From_Image_To_File("./Images/Flou/lacUniformBlur.bmp");

            //image = new MyImage(fichierEntree);
            //image.GaussianBlur(3);
            //image.From_Image_To_File("./Images/Flou/lacGaussianBlur.bmp");
            #endregion

            #region Test Agrandissement

            //fichierEntree = "./Images/Test.bmp";

            //image = new MyImage(fichierEntree);
            //image.Agrandissement(2);
            //image.From_Image_To_File("./Images/Agrandissement/testAgrandit.bmp");


            //fichierEntree = "./Images/lac.bmp";

            //image = new MyImage(fichierEntree);
            //image.Agrandissement(2);
            //image.From_Image_To_File("./Images/Agrandissement/lacAgrandit.bmp");


            //fichierEntree = "./Images/coco.bmp";

            //image = new MyImage(fichierEntree);
            //image.Agrandissement(2);
            //image.From_Image_To_File("./Images/Agrandissement/cocoAgrandit.bmp");
            #endregion

            #region Test Rotation

            //fichierEntree = ("./Images/test.bmp");

            //image = new MyImage(fichierEntree);
            //image.Rotation(90);
            //image.From_Image_To_File("./Images/Rotation/testRot90.bmp");

            //image = new MyImage(fichierEntree);
            //image.Rotation(180);
            //image.From_Image_To_File("./Images/Rotation/testRot180.bmp");

            //image = new MyImage(fichierEntree);
            //image.Rotation(270);
            //image.From_Image_To_File("./Images/Rotation/testRot270.bmp");

            //image = new MyImage(fichierEntree);
            //image.Rotation(40);
            //image.From_Image_To_File("./Images/Rotation/testRot40.bmp");

            //image = new MyImage(fichierEntree);
            //image.Rotation(230);
            //image.From_Image_To_File("./Images/Rotation/testRot230.bmp");


            //fichierEntree = "./Images/lac.bmp";

            //image = new MyImage(fichierEntree);
            //image.Rotation(90);
            //image.From_Image_To_File("./Images/Rotation/lacRot90.bmp");

            //image = new MyImage(fichierEntree);
            //image.Rotation(180);
            //image.From_Image_To_File("./Images/Rotation/lacRot180.bmp");

            //image = new MyImage(fichierEntree);
            //image.Rotation(270);
            //image.From_Image_To_File("./Images/Rotation/lacRot270.bmp");

            //image = new MyImage(fichierEntree);
            //image.Rotation(40);
            //image.From_Image_To_File("./Images/Rotation/lacRot40.bmp");

            //image = new MyImage(fichierEntree);
            //image.Rotation(230);
            //image.From_Image_To_File("./Images/Rotation/lacRot230.bmp");


            //fichierEntree = "./Images/coco.bmp";

            //image = new MyImage(fichierEntree);
            //image.Rotation(90);
            //image.From_Image_To_File("./Images/Rotation/cocoRot90.bmp");

            //image = new MyImage(fichierEntree);
            //image.Rotation(180);
            //image.From_Image_To_File("./Images/Rotation/cocoRot180.bmp");

            //image = new MyImage(fichierEntree);
            //image.Rotation(270);
            //image.From_Image_To_File("./Images/Rotation/cocoRot270.bmp");

            //image = new MyImage(fichierEntree);
            //image.Rotation(40);
            //image.From_Image_To_File("./Images/Rotation/cocoRot40.bmp");

            //image = new MyImage(fichierEntree);
            //image.Rotation(230);
            //image.From_Image_To_File("./Images/Rotation/cocoRot230.bmp");
            #endregion

        }

        private static void Menu()
        {
            Console.WriteLine(" ______  __                __  ______" +
                           "\r\n|   __ \\|__|.--.--..-----.|  ||   __ \\.----..-----." +
                           "\r\n|    __/|  ||_   _||  -__||  ||    __/|   _||  _  |" +
                           "\r\n|___|   |__||__.__||_____||__||___|   |__|  |_____|" +
                          "\r\n\r\n");
            Console.WriteLine("- réalisé par Camille Espieux, Chiara Godet, Laura Labarthe - TD i A2 Esilv 2024");
            Thread.Sleep(2000);
            Console.Clear();

            Console.WriteLine("Choix de l'image\n\n");
            Console.WriteLine("Choissisez un nombre associé à une option du menu :" +
                "\n 1) Coco" +
                "\n 2) Lena" +
                "\n 3) Lac" +
                "\n 4) Test" +
                "\n 5) Importer sa propre image");
            int saisieImage = Verif_Int(Console.ReadLine());
            saisieImage = Verif_Intervalle(saisieImage, 1, 5);
            MyImage image = new MyImage();

            switch (saisieImage)
            {
                case 1:
                    Console.WriteLine("Vous avez choisi l'image Coco.");
                    image = new MyImage("./Images/coco.bmp");
                    break;
                case 2:
                    Console.WriteLine("Vous avez choisi l'image Lena.");
                    image = new MyImage("./Images/lena.bmp");

                    break;
                case 3:
                    Console.WriteLine("Vous avez choisi l'image Lac.");
                    image = new MyImage("./Images/lac.bmp");
                    break;
                case 4:
                    Console.WriteLine("Vous avez choisi l'image Test.");
                    image = new MyImage("./Images/Test.bmp");
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Vous avez décidé d'importer une de vos images.");
                    Console.WriteLine("Veuillez écrire le chemin d'accès de votre image (sans écrire \".bmp\") : ");
                    string imageAcces = Console.ReadLine() + ".bmp";
                    if (File.Exists(imageAcces))
                    {
                        image = new MyImage(imageAcces);
                    }
                    else
                    {
                        int saisieIncorrecte = 0;
                        while (!File.Exists(imageAcces) && saisieIncorrecte < 3)
                        {
                            Console.Write("Veuillez resaisir le nom EXACT du chemin d'accès de l'image (sans écrire \".bmp\"), il vous reste " + (3 - saisieIncorrecte - 1) + " tentative(s) : ");
                            imageAcces = Console.ReadLine() + ".bmp";
                            saisieIncorrecte++;
                        }
                        if (File.Exists(imageAcces))
                        {
                            image = new MyImage(imageAcces);
                        }
                        else
                        {
                            Console.WriteLine("Nombre de tentatives dépassé. Impossible de trouver l'image souhaitée. Fermeture du programme...");
                            Thread.Sleep(500);
                            Environment.Exit(0);
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Erreur : option n'appartenant pas au menu.");
                    break;
            }

            bool finProgramme = false;
            while (!finProgramme)
            {
                Console.Clear();
                Console.WriteLine("Choix de l'option\n\n");
                Console.WriteLine("Choissisez un nombre associé à une option du menu :" +
                    "\n 1) Agrandissement" +
                    "\n 2) Rotation" +
                    "\n 3) Filtre" +
                    "\n 4) Fractale" +
                    "\n 5) Cacher une image" +
                    "\n 6) Décoder une image cachée" +
                    "\n 7) Compression JPEG");
                int saisieOption = Verif_Int(Console.ReadLine());
                saisieOption = Verif_Intervalle(saisieOption, 1, 7);
                Console.Clear();
            
                switch (saisieOption)
                {
                    case 1:
                        Console.WriteLine("Vous avez choisi l'agrandissement.\n\n");
                        Console.WriteLine("Sélectionner un entier supérieur à 1 : ");
                        int saisie3 = Verif_Int(Console.ReadLine());
                        saisie3 = Verif_Intervalle(saisie3, 1, int.MaxValue);

                        Console.WriteLine("\nProcessus en cours...");
                        image.Agrandissement(saisie3);
                        Console.WriteLine("\nProcessus terminé.\n");

                        finProgramme = DemandeFinProgramme();
                        break;
                   
                    case 2:
                        Console.WriteLine("Vous avez choisi la rotation.\n\n");
                        Console.WriteLine("Sélectionner un nombre entier : ");
                        saisie3 = Verif_Int(Console.ReadLine());

                        Console.WriteLine("\nProcessus en cours...");
                        image.Rotation(saisie3);
                        Console.WriteLine("\nProcessus terminé.\n");

                        finProgramme = DemandeFinProgramme();
                        break;
                    
                    case 3:
                        Console.WriteLine("Vous avez choisi d'appliquer un filtre.\n\n");
                        Console.WriteLine("Sélectionner un nombre associé à une option du menu : " +
                            "\n 1) Léger floutement" +
                            "\n 2) Floutement intense" +
                            "\n 3) Flou uniforme" +
                            "\n 4) Flou gaussian" +
                            "\n 5) Contour des bords : méthode Prewitt" +
                            "\n 6) Contour des bords : méthode Roberts" +
                            "\n 7) Contour des bords : méthode Sobel" +
                            "\n 8) Contour des bords : méthode Kirsch" +
                            "\n 9) Contour des bords : méthode MDIF" +
                            "\n 10) Renforcement des bords" +
                            "\n 11) Repoussage des bords" +
                            "\n 12) Noir et Blanc" +
                            "\n 13) Appliquer son propre filtre");
                        saisie3 = Verif_Int(Console.ReadLine());
                        saisie3 = Verif_Intervalle(saisie3, 1, 12);

                        Console.Clear();
                        switch (saisie3)
                        {
                            case 1:
                                Console.WriteLine("Vous avez choisi un léger floutement.");
                           
                                Console.WriteLine("\nProcessus en cours...");
                                image.Blur();
                                Console.WriteLine("\nProcessus terminé.\n");
                                break;
                            case 2:
                                Console.WriteLine("Vous avez choisi un floutement plus intense.");

                                Console.WriteLine("\nProcessus en cours...");
                                image.BiggerBlur();
                                Console.WriteLine("\nProcessus terminé.\n");
                                break;
                            case 3:
                                Console.WriteLine("Vous avez choisi un floutement uniforme.");

                                Console.WriteLine("\nProcessus en cours...");
                                image.UniformBlur();
                                Console.WriteLine("\nProcessus terminé.\n");
                                break;
                            case 4:
                                Console.WriteLine("Vous avez choisi un floutement gaussian.\n\n");

                                Console.WriteLine("Veuillez sélectionner une taille pour la matrice gaussienne appliquée à l'image : ");
                                int tailleMatrice = Verif_Int(Console.ReadLine());
                                tailleMatrice = Verif_Intervalle(tailleMatrice, 1, int.MaxValue);

                                Console.WriteLine("\nProcessus en cours...");
                                image.GaussianBlur(tailleMatrice);
                                Console.WriteLine("\nProcessus terminé.\n");
                                break;
                            case 5:
                                Console.WriteLine("Vous avez choisi le contour des bords : méthode Prewitt.");

                                Console.WriteLine("\nProcessus en cours...");
                                image.Prewitt(DemandeImageCouleur());
                                Console.WriteLine("\nProcessus terminé.\n");
                                break;
                            case 6:
                                Console.WriteLine("Vous avez choisi le contour des bords : méthode Roberts.");

                                Console.WriteLine("\nProcessus en cours...");
                                image.Roberts(DemandeImageCouleur());
                                Console.WriteLine("\nProcessus terminé.\n");
                                break;
                            case 7:
                                Console.WriteLine("Vous avez choisi le contour des bords : méthode Sobel.");

                                Console.WriteLine("\nProcessus en cours...");
                                image.Sobel(DemandeImageCouleur());
                                Console.WriteLine("\nProcessus terminé.\n");
                                break;
                            case 8:
                                Console.WriteLine("Vous avez choisi le contour des bords : méthode Kirsch.");

                                Console.WriteLine("\nProcessus en cours...");
                                image.Kirsch(DemandeImageCouleur());
                                Console.WriteLine("\nProcessus terminé.\n");
                                break;
                            case 9:
                                Console.WriteLine("Vous avez choisi le contour des bords : méthode MDIF.");
                                
                                Console.WriteLine("\nProcessus en cours...");
                                image.MDIF(DemandeImageCouleur());
                                Console.WriteLine("\nProcessus terminé.\n");
                                break;
                            case 10:
                                Console.WriteLine("Vous avez choisi le renforcement des bords.");
                                
                                Console.WriteLine("\nProcessus en cours...");
                                image.RenforcementBord();
                                Console.WriteLine("\nProcessus terminé.\n");
                                break;
                            case 11:
                                Console.WriteLine("Vous avez choisi le repoussage des bords.");
                                
                                Console.WriteLine("\nProcessus en cours...");
                                image.Repoussage();
                                Console.WriteLine("\nProcessus terminé.\n");
                                break;
                            case 12:
                                Console.WriteLine("Vous avez choisi le Noir et Blanc.");

                                Console.WriteLine("\nProcessus en cours...");
                                image.Black_White();
                                Console.WriteLine("\nProcessus terminé.\n");
                                break;
                            case 13:
                                Console.WriteLine("Vous avez choisi l'option d'utiliser votre propre filtre.\n\n");
                                Console.WriteLine("Veuillez sélectionner la taille de la matrice (carrée) correspondant à votre filtre : ");

                                tailleMatrice = Verif_Int(Console.ReadLine());
                                tailleMatrice = Verif_Intervalle(tailleMatrice, 1, int.MaxValue);
                                double[,] filtre = new double[tailleMatrice, tailleMatrice];
                                                                
                                for(int i = 0; i < tailleMatrice; i++)
                                {
                                    Console.WriteLine("\n\nRemplissage de la matrice\n\n");
                                    Console.WriteLine("Ligne n°" + (i+1));
                                    for(int j = 0; j< tailleMatrice; j++)
                                    {
                                        Console.WriteLine("Colonne n°" + (j + 1) + "\nValeur ? ");
                                        filtre[i,j] = Verif_Double(Console.ReadLine());
                                    }
                                    Console.Clear();
                                }
                                Console.WriteLine("\nProcessus en cours...");
                                image.Convolution(filtre);
                                Console.WriteLine("\nProcessus terminé.\n");
                                break;
                            
                            default:
                                Console.WriteLine("Erreur : option non valide.");
                                break;
                        }
                        finProgramme = DemandeFinProgramme();
                        break;

                    case 4:
                        Console.WriteLine("Vous avez choisi l'option de faire une fractale.\n\n");
                        Console.WriteLine("Voulez-vous qu'elle soit colorée ? (\"oui\" ou \"non\")");

                        string saisie5 = Console.ReadLine().ToLower();
                        while (saisie5 != "oui" && saisie5 != "non")
                        {
                            Console.WriteLine("Saisir \"oui\" ou \"non\"");
                            saisie5 = Console.ReadLine().ToLower();
                        }
                        Console.WriteLine("\nProcessus en cours...");
                        image.Fractale(saisie5 == "oui");
                        Console.WriteLine("\nProcessus terminé.\n");

                        finProgramme = DemandeFinProgramme();
                        break;
                   
                    case 5:
                        Console.WriteLine("Vous avez choisi de cacher une image dans votre image d'origine.\n\n");
                        Console.WriteLine("Choix de l'image à cacher\n\n");
                        Console.WriteLine("Choissisez un nombre associé à une option du menu :" +
                            "\n 1) Coco" +
                            "\n 2) Lena" +
                            "\n 3) Lac" +
                            "\n 4) Test" +
                            "\n 5) Importer sa propre image");
                        int saisie6 = Verif_Int(Console.ReadLine());
                        saisie6 = Verif_Intervalle(saisie6, 1, 5);
                        while (saisie6 == saisieImage && saisie6 != 5)
                        {
                            Console.WriteLine("Erreur, vous ne pouvez pas choisir la même image. Veuillez changer d'option : ");
                            saisie6 = Verif_Int(Console.ReadLine());
                            saisie6 = Verif_Intervalle(saisie6, 1, 5);
                        }

                        MyImage image2 = new MyImage();
                        switch (saisie6)
                        {
                            case 1:
                                Console.WriteLine("Vous avez choisi l'image Coco");
                                image2 = new MyImage("./Images/coco.bmp");
                                break;
                            case 2:
                                Console.WriteLine("Vous avez choisi l'image Lena");
                                image2 = new MyImage("./Images/lena.bmp");

                                break;
                            case 3:
                                Console.WriteLine("Vous avez choisi l'image Lac");
                                image2 = new MyImage("./Images/lac.bmp");
                                break;
                            case 4:
                                Console.WriteLine("Vous avez choisi l'image Test");
                                image2 = new MyImage("./Images/Test.bmp");
                                break;
                            case 5:
                                Console.WriteLine("Vous avez décidé d'importer une de vos images.\n\n");
                                Console.WriteLine("Veuillez écrire le chemin d'accès de votre image (sans écrire \".bmp\") : ");
                                string imageAcces = Console.ReadLine() + ".bmp";

                                if (File.Exists(imageAcces) && imageAcces != image.NomImage)
                                {
                                    image2 = new MyImage(imageAcces);
                                }
                                else
                                {
                                    int saisieIncorrecte = 0;
                                    while ((!File.Exists(imageAcces)  || imageAcces == image.NomImage) && saisieIncorrecte < 3)
                                    {
                                        Console.WriteLine("L'image n'existe pas ou alors vous essayez de réuitiliser la même image");
                                        Console.WriteLine("Veuillez resaisir le nom EXACT de chemin d'accès de votre image (sans écrire \".bmp\"), il vous reste " + (3 - saisieIncorrecte - 1) + " tentative(s) : ");
                                        imageAcces = Console.ReadLine() + ".bmp";
                                        saisieIncorrecte++;
                                    }
                                    if (File.Exists(imageAcces) && imageAcces != image.NomImage)
                                    {
                                        image2 = new MyImage(imageAcces);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Nombre de tentatives dépassé. Impossible de trouver l'image souhaitée. Fermeture du programme...");
                                        Thread.Sleep(500);
                                        Environment.Exit(0);
                                    }
                                }
                                break;
                            default:
                                Console.WriteLine("Erreur");
                                Thread.Sleep(500);
                                Environment.Exit(0);
                                break;
                        }
                        Console.WriteLine("\nProcessus en cours...");
                        image.CoderImage(image2);
                        Console.WriteLine("\nProcessus terminé.\n");
                        
                        finProgramme = DemandeFinProgramme();
                        break;

                    case 6: 
                        Console.WriteLine("Vous avez choisi de décoder une image cachée depuis votre image d'origine.\n\n");

                        Console.WriteLine("\nProcessus en cours...");
                        image = new MyImage(image.DecoderImage());
                        Console.WriteLine("Image décodée avec succès.");

                        finProgramme = DemandeFinProgramme();
                        break;

                    case 7:     
                        Console.WriteLine("Vous avez choisi de compresser votre image en format JPEG.\n\n");
                        Console.WriteLine("Option en cours d'écriture...");

                        finProgramme = DemandeFinProgramme();
                        break;

                    default:
                        Console.WriteLine("Erreur : option non disponible.");
                        finProgramme = DemandeFinProgramme();
                        break;
                }
            }
            Console.Clear();
            Console.WriteLine("Export de l'image en format BMP\n\n");
            Console.WriteLine("Veuillez saisir le nom de l'image modifiée pour son exportation (sans \".bmp\")");
            string saisieNom = Console.ReadLine() + ".bmp";

            Console.WriteLine("\nProcessus en cours...");
            image.From_Image_To_File(saisieNom);
            Console.WriteLine("Image exportée avec succès, vous pourrez la retrouver dans vos fichiers au chemin d'accès précisé juste avant.");
        }

        /// <summary>
        /// Détermine si l'utilisateur veut arrêter d'utiliser le programme.
        /// </summary>
        /// <returns></returns>
        private static bool DemandeFinProgramme()
        {
            Console.WriteLine("Voulez vous continuer à modifier votre image ? (\"oui\" ou \"non\")");
            string saisie = Console.ReadLine().ToLower();
            while (saisie != "oui" && saisie != "non")
            {
                Console.WriteLine("Saisir \"oui\" ou \"non\"");
                saisie = Console.ReadLine().ToLower();
            }
            return saisie != "oui";
        }

        /// <summary>
        /// Vérifie si le string passé en paramètres est un entier
        /// </summary>
        /// <param name="saisie"> string : chaîne de caractères dont on cherche à vérifier si elle est un entier </param>
        /// <returns> int : retourne un entier après vérification que le string correspond à un entier </returns>
        public static int Verif_Int(string saisie)
        {
            int rep;
            while (!int.TryParse(saisie, out rep))
            {
                Console.WriteLine("Veuillez saisir un nombre entier : ");
                saisie = Console.ReadLine();
                Console.WriteLine();
            }
            return rep;
        }

        /// <summary>
        /// Vérifie si le string passé en paramètres est un double
        /// </summary>
        /// <param name="saisie"> string : chaîne de caractères dont on cherche à vérifier si elle est un double </param>
        /// <returns> double : retourne un double après vérification que le string correspond à un double </returns>
        public static double Verif_Double(string saisie)
        {
            double rep;
            while (!double.TryParse(saisie, out rep))
            {
                Console.WriteLine("Veuillez saisir un nombre double : ");
                saisie = Console.ReadLine();
                Console.WriteLine();
            }
            return rep;
        }

        public static int Verif_Intervalle(int n, int min, int max)
        {
            while (n < min || n > max)
            {
                Console.WriteLine("Veuillez saisir un nombre entre " + min + " et " + max + " : ");
                n = Verif_Int(Console.ReadLine());
            }
            return n;
        }

        public static bool DemandeImageCouleur()
        {
            Console.WriteLine("Votre image est elle en couleur ? (\"oui\" ou \"non\")");
            string B_W = Console.ReadLine().ToLower();
            while (B_W != "oui" && B_W != "non")
            {
                Console.WriteLine("Saisir \"oui\" ou \"non\"");
                B_W = Console.ReadLine().ToLower();
            }
            return B_W == "oui";
        }
    }
}