using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PixelPro;

namespace PixelProTests
{
    [TestClass]
    public class PixelTests
    {
        [TestMethod]
        public void TestConstructeurAvecValeurs()
        {
            byte expectedRed = 1;
            byte expectedGreen = 2;
            byte expectedBlue = 3;

            Pixel pixel = new Pixel(expectedBlue, expectedGreen, expectedRed);

            Assert.AreEqual(expectedBlue, pixel.Blue);
            Assert.AreEqual(expectedGreen, pixel.Green);
            Assert.AreEqual(expectedRed, pixel.Red);
        }

        [TestMethod]
        public void TestConstructeurAvecPixel()
        {
            Pixel pixel = new Pixel(1, 2, 3);
            Pixel pixel2 = new Pixel(pixel);

            Assert.AreEqual(pixel.Blue, pixel2.Blue);
            Assert.AreEqual(pixel.Green, pixel2.Green);
            Assert.AreEqual(pixel.Red, pixel2.Red);
        }

        [TestMethod]
        public void TestAdd()
        {
            Pixel pixel1 = new Pixel(1, 2, 3);
            Pixel pixel2 = new Pixel(5, 6, 7);

            Pixel result = Pixel.Add(pixel1, pixel2);

            Assert.AreEqual(6, result.Blue);
            Assert.AreEqual(8, result.Green);
            Assert.AreEqual(10, result.Red);
        }

        [TestMethod]
        public void TestBAndWMethod()
        {
            Pixel pixel = new Pixel(10, 20, 30);
            pixel.B_and_W();

            Assert.AreEqual(21, pixel.Blue);
            Assert.AreEqual(21, pixel.Green);
            Assert.AreEqual(21, pixel.Red);
        }

        [TestMethod]
        public void TestToStringGBRMethod()
        {
            Pixel pixel = new Pixel(9, 20, 30);
            string result = pixel.toStringGBR();

            Assert.AreEqual("9  20 30", result);
        }
    }
}
