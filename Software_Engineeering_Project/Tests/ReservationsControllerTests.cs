//using Microsoft.AspNetCore.Mvc;
//using System;
//using Microsoft.EntityFrameworkCore;
//using System.Threading.Tasks;
//using TrainingReservationService.Controllers;
//using TrainingReservationService.Data;
//using TrainingReservationService.Models;
//using Xunit;


//namespace TrainingReservationService.Tests
//{
//    public class ReservationsControllerTests
//    {
//        private TrainingDbContext GetDbContext()
//        {
//            var options = new DbContextOptionsBuilder<TrainingDbContext>()
//                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
//                .Options;

//            var context = new TrainingDbContext(options);
//            context.Reservations.Add(new Reservation
//            {
//                Id = 1,
//                ClientName = "Anna",
//                TrainerName = "Tomasz",
//                TrainingDate = DateTime.Now.AddDays(1),
//                Confirmed = true
//            });
//            context.SaveChanges();
//            return context;
//        }

//        [Fact]
//        public async Task GetAll_ReturnsList()
//        {
//            var context = GetDbContext();
//            var controller = new ReservationsController(context);

//            var result = await controller.GetAll();

//            var okResult = Assert.IsType<OkObjectResult>(result);
//            var list = Assert.IsAssignableFrom<System.Collections.Generic.List<Reservation>>(okResult.Value);
//            Assert.Single(list);
//        }

//        [Fact]
//        public async Task GetById_ExistingId_ReturnsReservation()
//        {
//            var context = GetDbContext();
//            var controller = new ReservationsController(context);

//            var result = await controller.GetById(1);

//            var okResult = Assert.IsType<OkObjectResult>(result);
//            var reservation = Assert.IsType<Reservation>(okResult.Value);
//            Assert.Equal("Anna", reservation.ClientName);
//        }

//        [Fact]
//        public async Task GetById_NonExistingId_ReturnsNotFound()
//        {
//            var context = GetDbContext();
//            var controller = new ReservationsController(context);

//            var result = await controller.GetById(999);

//            Assert.IsType<NotFoundResult>(result);
//        }

//        [Fact]
//        public async Task Create_AddsNewReservation_ReturnsCreatedAt()
//        {
//            var context = GetDbContext();
//            var controller = new ReservationsController(context);

//            var newReservation = new Reservation
//            {
//                ClientName = "Jan",
//                TrainerName = "Magda",
//                TrainingDate = DateTime.Now.AddDays(2),
//                Confirmed = false
//            };

//            var result = await controller.Create(newReservation);

//            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
//            var created = Assert.IsType<Reservation>(createdResult.Value);
//            Assert.Equal("Jan", created.ClientName);
//        }

//        [Fact]
//        public async Task Update_ExistingId_UpdatesReservation()
//        {
//            var context = GetDbContext();
//            var controller = new ReservationsController(context);

//            var updated = new Reservation
//            {
//                ClientName = "Updated",
//                TrainerName = "UpdatedTrainer",
//                TrainingDate = DateTime.Now.AddDays(3),
//                Confirmed = true
//            };

//            var result = await controller.Update(1, updated);

//            Assert.IsType<NoContentResult>(result);

//            var res = await context.Reservations.FindAsync(1);
//            Assert.Equal("Updated", res.ClientName);
//        }

//        [Fact]
//        public async Task Update_NonExistingId_ReturnsNotFound()
//        {
//            var context = GetDbContext();
//            var controller = new ReservationsController(context);

//            var updated = new Reservation
//            {
//                ClientName = "NonExistent",
//                TrainerName = "None",
//                TrainingDate = DateTime.Now,
//                Confirmed = false
//            };

//            var result = await controller.Update(999, updated);

//            Assert.IsType<NotFoundResult>(result);
//        }

//        [Fact]
//        public async Task Delete_ExistingId_RemovesReservation()
//        {
//            var context = GetDbContext();
//            var controller = new ReservationsController(context);

//            var result = await controller.Delete(1);

//            Assert.IsType<NoContentResult>(result);
//            Assert.Null(await context.Reservations.FindAsync(1));
//        }

//        [Fact]
//        public async Task Delete_NonExistingId_ReturnsNotFound()
//        {
//            var context = GetDbContext();
//            var controller = new ReservationsController(context);

//            var result = await controller.Delete(999);

//            Assert.IsType<NotFoundResult>(result);
//        }
//    }
//}
