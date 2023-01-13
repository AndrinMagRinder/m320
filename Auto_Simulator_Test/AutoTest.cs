using Auto_Simulator_form;
using System.ComponentModel;

namespace Auto_Simulator_Test
{
    public class Tests
    {
        [Test]
        public void ObjectCreationTest()
        {
            // arrange
            Auto auto = new Auto("Auto", 2);

            // assert
            Assert.AreEqual("Auto", auto.name);
            Assert.AreEqual(2, auto.hp);

        }
        public class AccelerateTest
        {
            [Test]
            public void DoesntAccelerateWhenTurnedOffTest()
            {
                // arrange 
                Auto auto = new Auto("Auto", 600);

                // act
                auto.Accelerate();

                // assert
                Assert.AreEqual(0, auto.speed);
            }

            [Test]
            public void DoesntAccelerateWhenTurnedOnTest()
            {
                // arrange 
                Auto auto = new Auto("Auto", 600);
                auto.status = 1;
                auto.speed = 400;
                // act
                auto.Accelerate();
                // assert
                Assert.AreEqual(400, auto.speed);

            }
            [Test]
            public void DoesAccelerateWhenTurnedOnTest()
            {
                // arrange 
                Auto auto = new Auto("Auto", 600);
                auto.status = 1;
                auto.speed = 200;
                // act
                auto.Accelerate();
                // assert
                Assert.AreEqual(203, auto.speed);

            }

        }

        public class BrakeTest
        {
            [Test]
            public void DoesntBrakeWhenTurnedOffTest()
            {
                // arrange 
                Auto auto = new Auto("Auto", 600);
                auto.speed = 100;
                // act
                auto.Brake();

                // assert
                Assert.AreEqual(100, auto.speed);

            }
            [Test]
            public void DoesntBrakeWhenTurnedOnTest()
            {
                // arrange 
                Auto auto = new Auto("Auto", 600);
                auto.status = 1;

                // act
                auto.Brake();

                // assert
                Assert.AreEqual(0, auto.speed);

            }
            [Test]
            public void DoesBrakeWhenTurnedOnTest()
            {
                // arrange 
                Auto auto = new Auto("Auto", 600);
                auto.status = 1;
                auto.speed = 100;

                // act
                auto.Brake();

                // assert
                Assert.AreEqual(94, auto.speed);

            }
            [Test]
            public void SetSpeedToZeroNotToMinus()
            {
                // arrange 
                Auto auto = new Auto("Auto", 600);
                auto.status = 1;
                auto.speed = 1;

                // act
                auto.Brake();

                // assert
                Assert.AreEqual(0, auto.speed);

            }




        }
        [Test]
        public void StartEngine()
        {
            // Arrange
            Auto auto = new Auto("Auto", 600);
            
            // Act
            auto.StartEngine();

            // Assert
            Assert.AreEqual(1, auto.status);
            Assert.AreEqual(1, auto.gear);


        }

        [Test]
        public void StopEngine()
        {
            // Arrange
            Auto auto = new Auto("Auto", 600);
            auto.status = 1;
            auto.gear = 1;
            auto.speed = 1;
            // Act
            auto.StopEngine();
            // Assert
            Assert.AreEqual(0, auto.status);
            Assert.AreEqual(0, auto.gear);
            Assert.AreEqual(0, auto.speed);

        }
        public class GearTest
        {
            [Test]
            public void SetGearCase1()
            {
                // Arrange
                Auto auto = new Auto("Auto", 600);
                auto.speed = 1;
                // Act
                auto.SetGear();
                // Assert
                Assert.AreEqual(1, auto.gear);

            }
            [Test]
            public void SetGearCase2()
            {
                // Arrange
                Auto auto = new Auto("Auto", 600);
                auto.speed = 43;
                // Act
                auto.SetGear();
                // Assert
                Assert.AreEqual(2, auto.gear);

            }
            [Test]

            public void SetGearCase3()
            {
                // Arrange
                Auto auto = new Auto("Auto", 600);
                auto.speed = 86;
                // Act
                auto.SetGear();
                // Assert
                Assert.AreEqual(3, auto.gear);

            }
            [Test]

            public void SetGearCase4()
            {
                // Arrange
                Auto auto = new Auto("Auto", 600);
                auto.speed = 129;
                // Act
                auto.SetGear();
                // Assert
                Assert.AreEqual(4, auto.gear);

            }
            [Test]

            public void SetGearCase5()
            {
                // Arrange
                Auto auto = new Auto("Auto", 600);
                auto.speed = 186;
                // Act
                auto.SetGear();
                // Assert
                Assert.AreEqual(5, auto.gear);

            }
            [Test]

            public void SetGearCase6()
            {
                // Arrange
                Auto auto = new Auto("Auto", 600);
                auto.speed = 215;
                // Act
                auto.SetGear();
                // Assert
                Assert.AreEqual(6, auto.gear);

            }

        }
    }
       



    }
