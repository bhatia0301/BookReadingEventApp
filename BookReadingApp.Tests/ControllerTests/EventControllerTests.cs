using BookReadingApp.Application.Interfaces;
using BookReadingApp.Core.Modals;
using BookReadingApp.Web.Controllers;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookReadingApp.Tests.ControllerTests
{
    public class EventControllerTests
    {
        private EventController _eventController;
        private IEventRepository _eventPageService;
        private ICommentRepository _commentPageService;

        public EventControllerTests()
        {
            // because we don't want to go actually into the repository we just want to mock it dependencies

            _eventPageService = A.Fake<IEventRepository>();
            _commentPageService = A.Fake<ICommentRepository>();


            // we need to pass these fake dependencies otherwise it will not work

            _eventController = new EventController(_eventPageService, _commentPageService);
        }

        [Fact]
        public void EventController_GetEvents_ReturnSuccess()
        {
            //Arrange
            var eventList = A.Fake<IList<Event>>();
            A.CallTo(() => _eventPageService.GetEvents()).Returns(eventList);
            //Act
            var result =_eventController.GetEvents();
            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void EventController_ViewDetails_ReturnSuccess()
        {
            //Arrange
            var id = 1;
            var details = A.Fake<Event>();
            A.CallTo(() => _eventPageService.ViewDetails(id)).Returns(details);
            //Act
            var result = _eventController.ViewDetails(id);
            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }
        [Fact]
        public void EventController_EventsInvitedTo_ReturnSuccess()
        {
            //Arrange
            var eventList = A.Fake<IList<Event>>();
            A.CallTo(() => _eventPageService.GetEvents()).Returns(eventList);
            //Act
            var result = _eventController.GetEvents();
            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }
    }
}
