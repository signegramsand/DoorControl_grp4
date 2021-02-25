using NUnit.Framework;
using DoorControl;
using NSubstitute;

namespace DoorControl_test
{
    [TestFixture]
    public class Tests
    {
        private IAlarm _alarm;
        private IDoor _door;
        private IEntryNotification _entryNotification;
        private IUserValidation _userValidation;
        private DoorControl.DoorControl uut;

        [SetUp]
        public void Setup()
        {
            uut = new DoorControl.DoorControl();

            _alarm = Substitute.For<IAlarm>();
            _door = Substitute.For<IDoor>();
            _entryNotification = Substitute.For<IEntryNotification>();
            _userValidation = Substitute.For<IUserValidation>();

            uut.alarm = _alarm;
            uut.door = _door;
            uut.entryNotification = _entryNotification;
            uut.userValidation = _userValidation;
        }

        [TestCase(DoorControl.DoorControl.Doorstate.DoorOpening, 0)]        
        [TestCase(DoorControl.DoorControl.Doorstate.DoorBreached, 0)]
        [TestCase(DoorControl.DoorControl.Doorstate.DoorClosed, 1)]
        [TestCase(DoorControl.DoorControl.Doorstate.DoorClosing, 0)]
        public void RequestEntry_DoorClosed_ValidateEntryCalledOnUserValidation(DoorControl.DoorControl.Doorstate state, int amountRecieved)
        {
            //Arrange
            uut.state = state;

            //Act 
            uut.RequestEntry("test");

            //Assert 
            _userValidation.Received(amountRecieved).ValidateEntryRequest("test");
        }

        [TestCase(DoorControl.DoorControl.Doorstate.DoorOpening, 0)]
        [TestCase(DoorControl.DoorControl.Doorstate.DoorBreached, 0)]
        [TestCase(DoorControl.DoorControl.Doorstate.DoorClosed, 1)]
        [TestCase(DoorControl.DoorControl.Doorstate.DoorClosing, 0)]

        public void RequestEntry_DoorClosed_OpenCalledOnDoor(DoorControl.DoorControl.Doorstate state, int amount)
        {
            //Arrange
            uut.state = state;
            _userValidation.ValidateEntryRequest("test").Returns(true);

            //Act 
            uut.RequestEntry("test");

            //Assert 
            _door.Received(amount).Open();
        }

        [TestCase(DoorControl.DoorControl.Doorstate.DoorOpening, 0)]
        [TestCase(DoorControl.DoorControl.Doorstate.DoorBreached, 0)]
        [TestCase(DoorControl.DoorControl.Doorstate.DoorClosed, 1)]
        [TestCase(DoorControl.DoorControl.Doorstate.DoorClosing, 0)]
        public void RequestEntry_DoorClosed_NotifyGrantedCalledOnEntryNotification(DoorControl.DoorControl.Doorstate state, int amount)
        {
            //Arrange
            uut.state = state;
            _userValidation.ValidateEntryRequest("test").Returns(true);

            //Act 
            uut.RequestEntry("test");

            //Assert 
            _entryNotification.Received(amount).NotifyEntryGranted("test");

        }


    }
}