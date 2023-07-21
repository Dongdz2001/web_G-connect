using App.Business.Utils;
using App.Common.Base;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Google.Apis.Calendar.v3.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TemplateEngine.Docx;
using Calendar = Google.Apis.Calendar.v3.Data.Calendar;
using Newtonsoft.Json;
using App.Business.Services;
using System.Dynamic;
namespace App.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public ValuesController()
        {

        }

        [HttpGet]
        [Route("is-online")]
        public IActionResult IsOnline(string auth_code)
        {
            return Ok("online");
        }


        [HttpGet]
        [Route("verify-google-authcode")]
        public IActionResult VerifyGoogleAuthCode(string auth_code)
        {
            var googleApi = new GoogleApiHandler();
            var token = googleApi.GetTokenGoogleByAuthcode(auth_code);
            return Ok(token);
        }
        //1//0eQqc9MNiQDQ2CgYIARAAGA4SNwF-L9IrlzRrZnEM4oTjPdNEI5G_i2TxxNebNAjGUXWxgnynsG_5xeh2QnGLPFZUMZJbFEMfGbY
        [HttpGet]
        [Route("google-calendar-test")]
        public IActionResult Test(string refresh_token = "1//0eZqNbjHcMs8eCgYIARAAGA4SNwF-L9Irel4YlQi__kGM-kOx6SZTZGRTDsnfG6rNzFavbce1L3PSNTShh5T6aTcnKQKrq4WBH0s")
        {
            var googleApi = new GoogleApiHandler();
            var calendarService = googleApi.GetCalendarService(refresh_token);
            var request = calendarService.Events.List("primary");
            Events events = request.Execute();
            return Ok(events.Items);
        }

        [HttpGet]
        [Route("google-calendar-insert")]
        public IActionResult Insert(string refresh_token = "1//0eZqNbjHcMs8eCgYIARAAGA4SNwF-L9Irel4YlQi__kGM-kOx6SZTZGRTDsnfG6rNzFavbce1L3PSNTShh5T6aTcnKQKrq4WBH0s")
        {
            var googleApi = new GoogleApiHandler();
            var calendarService = googleApi.GetCalendarService(refresh_token);
            //var request = calendarService.Events.List("primary");

            Event newEvent = new Event()
            {
                Summary = "Test Google Calendar",
                Location = "48 Tố Hữu, Nam Từ Liêm, Hà Nội",
                Description = "Test Google Calendar Google's developer products.",
                Start = new EventDateTime()
                {
                    DateTime = DateTime.Parse("2021-08-23T17:00:00+07:00"),
                    TimeZone = "Asia/Ho_Chi_Minh",
                },
                End = new EventDateTime()
                {
                    DateTime = DateTime.Parse("2021-08-23T18:00:00+07:00"),
                    TimeZone = "Asia/Ho_Chi_Minh",
                },
                Recurrence = new String[] { "RRULE:FREQ=DAILY;COUNT=1" },
                Attendees = new EventAttendee[] {
                    new EventAttendee() { Email = "nhannv@thienhoang.com.vn" },
                    new EventAttendee() { Email = "thaobt@thienhoang.com.vn" },
                    new EventAttendee() { Email = "haivn@thienhoang.com.vn" },
                },
                Reminders = new Event.RemindersData()
                {
                    UseDefault = false,
                    Overrides = new EventReminder[] {
                                new EventReminder() { Method = "email", Minutes = 24 * 60 },
                                new EventReminder() { Method = "sms", Minutes = 10 },
                }
                }
            };

            String calendarId = "primary";

            var request = calendarService.Events.Insert(newEvent, calendarId);
            Event createdEvent = request.Execute();

            return Ok(createdEvent);
        }

        [HttpGet]
        [Route("google-calendar-update")]
        public IActionResult Update(string eventId, string calendarId = "primary", string refresh_token = "1//0eZqNbjHcMs8eCgYIARAAGA4SNwF-L9Irel4YlQi__kGM-kOx6SZTZGRTDsnfG6rNzFavbce1L3PSNTShh5T6aTcnKQKrq4WBH0s")
        {
            var googleApi = new GoogleApiHandler();

            var calendarService = googleApi.GetCalendarService(refresh_token);

            var eventOld = calendarService.Events.Get(calendarId, eventId).Execute();
            eventOld.Summary = "Modify Testing Google Calendar";
            // map eventOld voi event dto thay doi sau do update lại
            // coding here

            var result = calendarService.Events.Update(eventOld, calendarId, eventId).Execute();

            return Ok(result);
        }
        //delete event
        [HttpGet]
        [Route("google-calendar-delete")]
        public IActionResult Delete(string eventId, string calendarId = "primary", string refresh_token = "1//0eZqNbjHcMs8eCgYIARAAGA4SNwF-L9Irel4YlQi__kGM-kOx6SZTZGRTDsnfG6rNzFavbce1L3PSNTShh5T6aTcnKQKrq4WBH0s")
        {
            var googleApi = new GoogleApiHandler();
            var calendarService = googleApi.GetCalendarService(refresh_token);
            var request = calendarService.Events.Delete(calendarId, eventId);
            var result = request.Execute();

            return Ok(result);
        }



       
    }
}

