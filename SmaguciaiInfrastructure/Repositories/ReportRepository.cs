using Microsoft.EntityFrameworkCore;
using SmaguciaiCore.Interfaces.Repositories;
using SmaguciaiDomain.Entities;
using SmaguciaiInfrastructure.Data;

namespace SmaguciaiInfrastructure.Repositories;

public class ReportRepository : IReportRepository
{
    private readonly SmaguciaiDataContext _dbContext;
    
    public ReportRepository(SmaguciaiDataContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public bool AddNewReport(Report report)
    {
        report.Id = Guid.NewGuid();
        report.DateAdded = DateTime.Now;
        _dbContext.Reports.Add(report);
        _dbContext.SaveChanges();
        return true;
    }

    public Report GetById(Guid id)
    {
        var report = _dbContext.Reports.FirstOrDefault(u => u.Id == id);
        return report;  
    }

    public List<Report> GetReportsByReviewId(Guid reviewId)
    {
        return _dbContext.Reports
            .Where(r => r.ReviewId == reviewId)
            .ToList();
    }

    public bool DeleteReport(Guid id)
    {
        try
        {
            var place = _dbContext.Reports.SingleOrDefault(entity => entity.Id == id);

            if (place is null)
            {
                throw new Exception("Place not found");
            }

            _dbContext.Reports.Remove(place);
            _dbContext.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
}