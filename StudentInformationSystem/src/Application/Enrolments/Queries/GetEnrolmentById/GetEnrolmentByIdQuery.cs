using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using StudentInformationSystem.Application.Common.Exceptions;
using StudentInformationSystem.Application.Common.Interfaces.Repositories;
using StudentInformationSystem.Application.Common.Interfaces.Services;
using StudentInformationSystem.Application.Common.Models;
using StudentInformationSystem.Application.Enrolments.Dtos;
using StudentInformationSystem.Domain.Entities;

namespace StudentInformationSystem.Application.Enrolments.Queries.GetEnrolmentById;

public class GetEnrolmentByIdQuery : IRequest<EnrolmentDto>
{
    public Guid EnrolmentId { get; set; }
}

public class GetEnrolmentByIdQueryHandler : IRequestHandler<GetEnrolmentByIdQuery, EnrolmentDto>
{
    private readonly IMapper _mapper;
    private readonly IEnrolmentService _enrolmentService;

    public GetEnrolmentByIdQueryHandler(IEnrolmentService enrolmentService, IMapper mapper)
    {
        _enrolmentService = enrolmentService;
        _mapper = mapper;
    }

    public async Task<EnrolmentDto> Handle(GetEnrolmentByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _enrolmentService.GetEnrolmentById(request.EnrolmentId);

        if (result == null)
        {
            throw new NotFoundException(nameof(Enrolment), request.EnrolmentId);
        }

        return result;
    }
}
