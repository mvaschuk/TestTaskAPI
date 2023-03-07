using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TestTask.Application.Interfaces;

namespace TestTask.Application.MediatR.Queries.GetPackages;

public class GetPackagesQueryHandler : IRequestHandler<GetPackagesQuery, PackageListViewModel>
{
    private readonly ITestTaskDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetPackagesQueryHandler(ITestTaskDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext ?? throw new ArgumentException(nameof(dbContext));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }
    public async Task<PackageListViewModel> Handle(GetPackagesQuery request, CancellationToken cancellationToken)
    {
        var result = new PackageListViewModel
        {
            Packages = new List<PackageViewModel>()
        };

        if (request.RecipientId.HasValue)
        {
            result.Packages = await _dbContext.Packages.Where(i => i.Recipient.Id == request.RecipientId).ProjectTo<PackageViewModel>(_mapper.ConfigurationProvider).ToListAsync();
        }
        else if (request.Status != null)
        {
            result.Packages = await _dbContext.Packages.Where(i => i.Status == request.Status).ProjectTo<PackageViewModel>(_mapper.ConfigurationProvider).ToListAsync();
        } 
        else if (request.Id.HasValue)
        {
            result.Packages = await _dbContext.Packages.Where(i => i.Id == request.Id).ProjectTo<PackageViewModel>(_mapper.ConfigurationProvider).ToListAsync();
        }
        else
        {
            result.Packages = await _dbContext.Packages.ProjectTo<PackageViewModel>(_mapper.ConfigurationProvider).ToListAsync();
        }
        return result;
    }
}