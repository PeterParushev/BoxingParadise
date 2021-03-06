﻿using BoxingParadiseBackend.DTOs;
using BoxingParadiseBackend.Services.Interfaces;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BoxingParadise.Controllers
{
    public class BoxerController : ApiController
    {
        private readonly IBoxerService m_BoxerService;

        public BoxerController(IBoxerService boxerService)
        {
            m_BoxerService = boxerService;
        }

        [HttpGet]
        public async Task<IList<BoxerDto>> Get()
        {
            return await m_BoxerService.GetBoxers().ConfigureAwait(false);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Create(BoxerDto boxer, string adminKey)
        {
            await m_BoxerService.CreateBoxer(boxer, adminKey).ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(int id, string adminKey)
        {
            await m_BoxerService.DeleteBoxer(id, adminKey).ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}