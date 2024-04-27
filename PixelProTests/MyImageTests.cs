using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PixelPro;
using static System.Net.Mime.MediaTypeNames;

namespace PixelProTests
{
    [TestClass]
    public class MyImageTests
    {
        [TestMethod]
        public void TestConstructeurAvecFichier()
        {
            string filePath = "./Images/Test.bmp";
            MyImage image = new MyImage(filePath);

            Assert.AreEqual("BM", image.TypeImage);

            Assert.AreEqual(54, image.TailleOffset);
            Assert.AreEqual(1254, image.TailleFichier);

            Assert.AreEqual(20, image.Largeur);
            Assert.AreEqual(20, image.Hauteur);
            Assert.AreEqual(24, image.BitsCouleur);
            Assert.AreEqual(filePath, image.NomImage);
        }

        [TestMethod]
        public void TestConstructeurAvecImage()
        {
            MyImage imageTest = new MyImage("./Images/Test.bmp");
            MyImage imageTestee = new MyImage(imageTest);

            Assert.AreEqual(imageTest.TypeImage, imageTestee.TypeImage);

            Assert.AreEqual(imageTest.TailleOffset, imageTestee.TailleOffset);
            Assert.AreEqual(imageTest.TailleFichier, imageTestee.TailleFichier);

            Assert.AreEqual(imageTest.Largeur, imageTestee.Largeur);
            Assert.AreEqual(imageTest.Hauteur, imageTestee.Hauteur);
            Assert.AreEqual(imageTest.BitsCouleur, imageTestee.BitsCouleur);
            Assert.AreEqual(imageTest.NomImage, imageTestee.NomImage);

            Assert.AreEqual(imageTest.Image, imageTestee.Image);
        }

        [TestMethod]
        public void TestConstructeurVide() 
        {
            MyImage imageTest = new MyImage();
            
            Assert.IsNotNull(imageTest);
        }

        [TestMethod]
        public void TestConvertir_Endian_To_Int()
        {
            byte[] b = new byte[] { 0, 40, 3, 10 };
            int resultatAttendu = (int)(b[0] * 1 + b[1] * 256 + b[2] * Math.Pow(256, 2) + b[3] * Math.Pow(256, 3));

            int resultat = MyImage.Convertir_Endian_To_Int(b);
            
            Assert.AreEqual(resultatAttendu, resultat);
        }

        [TestMethod]
        public void TestConvertir_Int_To_Endian()
        {
            int nb = 167979008;
            byte[] resultatAttendu = new byte[] { 0, 40, 3, 10 };

            byte[] resultat = MyImage.Convertir_Int_To_Endian(nb);

            Assert.AreEqual(resultatAttendu[0], resultat[0]);
            Assert.AreEqual(resultatAttendu[1], resultat[1]);
            Assert.AreEqual(resultatAttendu[2], resultat[2]);
            Assert.AreEqual(resultatAttendu[3], resultat[3]);
        }

        [TestMethod]
        public void TestAgrandissement()
        {
            MyImage image = new MyImage("./Images/Test.bmp");
            int coefficient = 2;

            int largeurAttendue = image.Largeur * coefficient;
            int hauteurAttendue = image.Hauteur * coefficient;
            int tailleFichierAttendue = (image.Hauteur * coefficient * image.Largeur * coefficient * image.BitsCouleur ) / 8 + image.TailleOffset;

            image.Agrandissement(coefficient);

            Assert.AreEqual(largeurAttendue, image.Largeur);
            Assert.AreEqual(hauteurAttendue, image.Hauteur);
            Assert.AreEqual(tailleFichierAttendue, image.TailleFichier);
        }

        [TestMethod]
        public void TestRotation90()
        {
            MyImage image = new MyImage("./Images/Test.bmp");
            int hauteurAttendue = image.Largeur;
            int largeurAttendue = image.Hauteur;

            Pixel p1 = new Pixel(image.Image[0, 0]);
            Pixel p2 = new Pixel(image.Image[0, image.Largeur - 1]);
            Pixel p3 = new Pixel(image.Image[image.Hauteur - 1, 0]);
            Pixel p4 = new Pixel(image.Image[image.Hauteur - 1, image.Largeur - 1]);
            
            image.Rotation(90);

            Assert.AreEqual(largeurAttendue, image.Largeur); 
            Assert.AreEqual(hauteurAttendue, image.Hauteur);

            Assert.AreEqual(p1.Red, image.Image[0, image.Largeur - 1].Red);
            Assert.AreEqual(p1.Green, image.Image[0, image.Largeur - 1].Green);
            Assert.AreEqual(p1.Blue, image.Image[0, image.Largeur - 1].Blue);

            Assert.AreEqual(p2.Red, image.Image[image.Hauteur - 1, image.Largeur - 1].Red);
            Assert.AreEqual(p2.Green, image.Image[image.Hauteur - 1, image.Largeur - 1].Green);
            Assert.AreEqual(p2.Blue, image.Image[image.Hauteur - 1, image.Largeur - 1].Blue);

            Assert.AreEqual(p3.Red, image.Image[0, 0].Red);
            Assert.AreEqual(p3.Green, image.Image[0, 0].Green);
            Assert.AreEqual(p3.Blue, image.Image[0, 0].Blue);

            Assert.AreEqual(p4.Red, image.Image[image.Hauteur - 1, 0].Red);
            Assert.AreEqual(p4.Green, image.Image[image.Hauteur - 1, 0].Green);
            Assert.AreEqual(p4.Blue, image.Image[image.Hauteur - 1, 0].Blue);
        }

        [TestMethod]
        public void TestRotation180()
        {
            MyImage image = new MyImage("./Images/Test.bmp");
            int hauteurAttendue = image.Hauteur;
            int largeurAttendue = image.Largeur;

            Pixel p1 = new Pixel(image.Image[0, 0]);
            Pixel p2 = new Pixel(image.Image[0, image.Largeur - 1]);
            Pixel p3 = new Pixel(image.Image[image.Hauteur - 1, 0]);
            Pixel p4 = new Pixel(image.Image[image.Hauteur - 1, image.Largeur - 1]);

            image.Rotation(90);

            Assert.AreEqual(largeurAttendue, image.Largeur);
            Assert.AreEqual(hauteurAttendue, image.Hauteur);

            Assert.AreEqual(p3.Red, image.Image[0, image.Largeur - 1].Red);
            Assert.AreEqual(p3.Green, image.Image[0, image.Largeur - 1].Green);
            Assert.AreEqual(p3.Blue, image.Image[0, image.Largeur - 1].Blue);

            Assert.AreEqual(p1.Red, image.Image[image.Hauteur - 1, image.Largeur - 1].Red);
            Assert.AreEqual(p1.Green, image.Image[image.Hauteur - 1, image.Largeur - 1].Green);
            Assert.AreEqual(p1.Blue, image.Image[image.Hauteur - 1, image.Largeur - 1].Blue);

            Assert.AreEqual(p4.Red, image.Image[0, 0].Red);
            Assert.AreEqual(p4.Green, image.Image[0, 0].Green);
            Assert.AreEqual(p4.Blue, image.Image[0, 0].Blue);

            Assert.AreEqual(p2.Red, image.Image[image.Hauteur - 1, 0].Red);
            Assert.AreEqual(p2.Green, image.Image[image.Hauteur - 1, 0].Green);
            Assert.AreEqual(p2.Blue, image.Image[image.Hauteur - 1, 0].Blue);
        }

        [TestMethod]
        public void TestRotation270()
        {
            MyImage image = new MyImage("./Images/Test.bmp");
            int hauteurAttendue = image.Largeur;
            int largeurAttendue = image.Hauteur;

            Pixel p1 = new Pixel(image.Image[0, 0]);
            Pixel p2 = new Pixel(image.Image[0, image.Largeur - 1]);
            Pixel p3 = new Pixel(image.Image[image.Hauteur - 1, 0]);
            Pixel p4 = new Pixel(image.Image[image.Hauteur - 1, image.Largeur - 1]);

            image.Rotation(90);

            Assert.AreEqual(largeurAttendue, image.Largeur);
            Assert.AreEqual(hauteurAttendue, image.Hauteur);

            Assert.AreEqual(p4.Red, image.Image[0, image.Largeur - 1].Red);
            Assert.AreEqual(p4.Green, image.Image[0, image.Largeur - 1].Green);
            Assert.AreEqual(p4.Blue, image.Image[0, image.Largeur - 1].Blue);

            Assert.AreEqual(p3.Red, image.Image[image.Hauteur - 1, image.Largeur - 1].Red);
            Assert.AreEqual(p3.Green, image.Image[image.Hauteur - 1, image.Largeur - 1].Green);
            Assert.AreEqual(p3.Blue, image.Image[image.Hauteur - 1, image.Largeur - 1].Blue);

            Assert.AreEqual(p2.Red, image.Image[0, 0].Red);
            Assert.AreEqual(p2.Green, image.Image[0, 0].Green);
            Assert.AreEqual(p2.Blue, image.Image[0, 0].Blue);

            Assert.AreEqual(p1.Red, image.Image[image.Hauteur - 1, 0].Red);
            Assert.AreEqual(p1.Green, image.Image[image.Hauteur - 1, 0].Green);
            Assert.AreEqual(p1.Blue, image.Image[image.Hauteur - 1, 0].Blue);
        }
    }


}
