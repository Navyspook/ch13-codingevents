using CodingEvents.Data;
using CodingEvents.Models;
using CodingEvents.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {
        
        public IActionResult Index()
        {
            List<Event> events = new List<Event>(EventData.GetAll());

            return View(events);
        }


        public IActionResult Add()
        {
            AddEventViewModel addEventViewModel = new AddEventViewModel();

            return View(addEventViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddEventViewModel addEventViewModel)
        {
            if(ModelState.IsValid)
            {
                Event newEvent = new Event
                {
                    Name = addEventViewModel.Name,
                    Description = addEventViewModel.Description,
                    Location = addEventViewModel.Location,
                    Attendees = addEventViewModel.Attendees,
                    ContactEmail = addEventViewModel.ContactEmail
                };

                EventData.Add(newEvent);

                return Redirect("/Events");
            }

            return View(addEventViewModel);

        }

        public IActionResult Delete()
        {
            ViewBag.events = EventData.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach(int eventId in eventIds)
            {
                EventData.Remove(eventId);
            }

            return Redirect("/Events");
        }

        [Route("Events/Edit/{eventId?}")]
        public IActionResult Edit(int eventId)
        {
            ViewBag.eventToEdit = EventData.GetById(eventId);

            return View();
        }

        [HttpPost("Events/Edit/{eventId?}")]
        public IActionResult SubmitEditEventForm(int eventId, string name, string description)
        {
            //EventData.GetById(eventId);

            var changeInfo = EventData.GetById(eventId);
            changeInfo.Description = description;
            changeInfo.Name = name;

            // controller code will go here
            return Redirect("/Events");
        }

        //public IActionResult Edit(int Id)
        //{
        //    Event thisEvent = EventData.GetById(Id);
        //    ViewBag.thisEvent = thisEvent;
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult EditForm(int Id, string name, string description)
        //{
        //    Event thisEvent = EventData.GetById(Id);
        //    EventData.Update(thisEvent, name, description);
        //    return Redirect("/Events");
        //}

    }
}
