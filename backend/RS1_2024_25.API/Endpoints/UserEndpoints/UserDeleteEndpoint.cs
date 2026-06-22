namespace RS1_2024_25.API.Endpoints.UserEndpoints;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Data.Models;
using RS1_2024_25.API.Helper.Api;
using RS1_2024_25.API.Services;
using System.Threading;
using System.Threading.Tasks;

[Route("users")]
public class UserDeleteEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<int>
    .WithoutResult
{
    [HttpDelete("{id}")]
    public override async Task HandleAsync(int id, CancellationToken cancellationToken = default)
    {
        var user = await db.MyAppUsers.SingleOrDefaultAsync(x => x.ID == id, cancellationToken);

        if (user == null)
            throw new KeyNotFoundException("User not found");

        db.MyAppUsers.Remove(user);
        await db.SaveChangesAsync(cancellationToken);
    }
}
