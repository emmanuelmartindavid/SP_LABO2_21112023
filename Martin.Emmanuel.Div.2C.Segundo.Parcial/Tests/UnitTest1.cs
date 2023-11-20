using Entities.Controllers;
using Entities.Exceptions;
using Entities.Models;
using Entities.Validators;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task ShouldGetGuestIfDniExistsInDataBase()
        {
            var guestController = new GuestController();
            var guests = await guestController.GetAllGuests();

            foreach (var item in guests)
            {
                var guest = await guestController.GetGuestByDni(item.Dni);

                Assert.AreEqual(guest.Dni, item.Dni);
                Assert.AreEqual(guest.Name, item.Name);
                Assert.AreEqual(guest.LastName, item.LastName);
                Assert.AreEqual(guest.PhoneNumber, item.PhoneNumber);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(WrongGuestDniException))]
        public void IfDniIsNegativeShouldGetError()
        {
            var validator = new DataEntryValidator();
            validator.ValidateDniGuest("-90");
        }
        
        [TestMethod]
        [ExpectedException(typeof(WrongGuestNameException))]
        public void IfNameOrLastNameIsWrongShouldGetError()
        {
            var validator = new DataEntryValidator();
            validator.ValidateNameGuest("e", "roca");
            validator.ValidateNameGuest("julio", "ro");
        }

    }
}