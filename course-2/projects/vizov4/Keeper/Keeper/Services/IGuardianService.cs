using System;
using Keeper.Dtos;

namespace Keeper.Services
{
    public interface IGuardianService
    {
        Task<VisitorResponse> CreateVisitorAsync();
        Task<List<VisitorResponse>> GetAllVisitorsAsync();
        Task<VisitorResponse> GetVisitorByIdAsync(int id);
        Task<ActionResponse> PerformActionAsync(int id, PerformActionRequest request);
        Task<AccessResponse> CheckAccessAsync(int id);
    }
}

