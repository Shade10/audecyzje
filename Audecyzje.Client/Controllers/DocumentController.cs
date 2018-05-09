using System.Collections.Generic;
using System.Threading.Tasks;
using Audecyzje.Infrastructure.Dtos;
using Audecyzje.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Audecyzje.Client.Controllers
{
    [Route("api/[controller]")]
    public class DocumentController : Controller
    {
        private readonly IDocumentService _documentService;

        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }
        
        [HttpGet]
        public async Task<IEnumerable<DocumentDto>> Get()
        {
            return await _documentService.GetAll();
        }

        [HttpGet]
        [Route("search")]
        public async Task<IEnumerable<DocumentDto>> Search(string query)
        {
            return await _documentService.Search(query);
        }

        [HttpGet("GetByDecisionNumber/{number}")]
		public async Task<IEnumerable<DocumentDto>> GetByDecisionNumber(string number)
		{
			return await _documentService.GetByDecisionNumber(number);
		}

		[HttpGet("GetByLegalBasis/{legalBasis}")]
        public async Task<IEnumerable<DocumentDto>> GetByLegalBasis(string legalBasis)
        {
            return await _documentService.GetByLegalBasis(legalBasis);
        }

        [HttpGet("GetByAddress/{address}")]
        public async Task<IEnumerable<DocumentDto>> GetByAddress(string address)
        {
            return await _documentService.GetByAddress(address);
        }


    }
}
