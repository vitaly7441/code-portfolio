using Keeper.Data;
using Keeper.Dtos;
using Keeper.Models;
using Microsoft.EntityFrameworkCore;

namespace Keeper.Services
{
    public class GuardianService : IGuardianService
    {
        private readonly AppDbContext _db;

        public GuardianService(AppDbContext db) => _db = db;

        public async Task<VisitorResponse> CreateVisitorAsync()
        {
            var visitor = new Visitor { TrustLevel = 0 };
            _db.Visitors.Add(visitor);
            await _db.SaveChangesAsync();
            return MapToResponse(visitor);
        }

        public async Task<List<VisitorResponse>> GetAllVisitorsAsync()
        {
            var visitors = await _db.Visitors.Include(v => v.ActionHistories).ToListAsync();
            return visitors.Select(MapToResponse).ToList();
        }

        public async Task<VisitorResponse> GetVisitorByIdAsync(int id)
        {
            var visitor = await _db.Visitors.Include(v => v.ActionHistories).FirstOrDefaultAsync(v => v.Id == id);
            if (visitor == null) throw new NotFoundException($"Посетитель с ID {id} не найден.");
            return MapToResponse(visitor);
        }

        public async Task<ActionResponse> PerformActionAsync(int id, PerformActionRequest request)
        {
            var visitor = await _db.Visitors.Include(v => v.ActionHistories).FirstOrDefaultAsync(v => v.Id == id);
            if (visitor == null) throw new NotFoundException($"Посетитель с ID {id} не найден.");

            if (!Enum.TryParse<GuardianAction>(request.Action, true, out var action))
                throw new BadRequestException($"Некорректное действие: '{request.Action}'.");

            if (visitor.ActionHistories.Any(a => a.Action == action))
                throw new BadRequestException($"Посетитель уже выполнял действие '{action}'.");

            int change = action switch
            {
                GuardianAction.Introduce => 20,
                GuardianAction.OfferHelp => 30,
                GuardianAction.Threaten => -20,
                _ => 0
            };

            visitor.TrustLevel = Math.Clamp(visitor.TrustLevel + change, 0, 100);
            visitor.ActionHistories.Add(new ActionHistory { Action = action });
            await _db.SaveChangesAsync();

            return new ActionResponse
            {
                VisitorId = visitor.Id,
                TrustLevel = visitor.TrustLevel,
                PerformedAction = action.ToString(),
                Message = $"Действие {action} выполнено. Текущий уровень доверия: {visitor.TrustLevel}/100."
            };
        }

        public async Task<AccessResponse> CheckAccessAsync(int id)
        {
            var visitor = await _db.Visitors.FirstOrDefaultAsync(v => v.Id == id);
            if (visitor == null) throw new NotFoundException($"Посетитель с ID {id} не найден.");
            bool hasAccess = visitor.TrustLevel >= 50;
            return new AccessResponse
            {
                VisitorId = visitor.Id,
                TrustLevel = visitor.TrustLevel,
                AccessGranted = hasAccess,
                Message = hasAccess ? "Хранитель разрешает проход." : "Уровень доверия слишком низок."
            };
        }

        private static VisitorResponse MapToResponse(Visitor v) => new()
        {
            Id = v.Id,
            TrustLevel = v.TrustLevel,
            ActionsDone = v.ActionHistories.Select(a => a.Action.ToString()).ToList()
        };
    }
}

