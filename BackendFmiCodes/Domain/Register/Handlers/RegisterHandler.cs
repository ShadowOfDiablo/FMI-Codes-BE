using Domain.Entities;
using MediatR;

namespace Domain.Handlers;

public class RegisterHandler : IRequestHandler<RegisterRequest,bool>
{
    private readonly FmiDatabaseConfig _context;

    public RegisterHandler(FmiDatabaseConfig context)
    {
        _context = context;
    }
    public async Task<bool> Handle(RegisterRequest request, CancellationToken cancellationToken)
    {
        _context.Users.Add(new User(request.Email, request.PushToken, request.PublicKey));
        var result = await _context.SaveChangesAsync(cancellationToken);
        return result > 0;
    }
}