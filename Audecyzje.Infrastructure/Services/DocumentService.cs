﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audecyzje.Core.Repositories;
using Audecyzje.Infrastructure.Dtos;
using Audecyzje.Infrastructure.Services.Interfaces;
using AutoMapper;

namespace Audecyzje.Infrastructure.Services
{
    public class DocumentService : Service, IDocumentService
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly IMapper _mapper;

        public DocumentService(IDocumentRepository documentRepository, IMapper mapper)
        {
            _documentRepository = documentRepository;
            _mapper = mapper;
        }

        public async Task<List<DocumentDto>> GetAll()
        {
            var allDocuments = await _documentRepository.GetAll();
            var allDocumentsDto = _mapper.Map<List<DocumentDto>>(allDocuments);
            return allDocumentsDto;
        }
    }
}
