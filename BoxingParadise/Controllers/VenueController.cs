﻿using BoxingParadiseBackend.DTOs;
using BoxingParadiseBackend.Services.Interfaces;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BoxingParadise.Controllers
{
    public class VenueController : ApiController
    {
        private readonly IVenueService m_VenueService;

        public VenueController(IVenueService venueService)
        {
            m_VenueService = venueService;
        }

        [HttpGet]
        public async Task<IList<VenueDto>> Get()
        {
            return await m_VenueService.GetVenues().ConfigureAwait(false);
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(int venueId)
        {
            await m_VenueService.DeleteVenue(venueId).ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Create(VenueDto venueDto)
        {
            await m_VenueService.CreateVenue(venueDto).ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.Created);
        }
    }
}