using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Helper.Api;
using System;
using static RS1_2024_25.API.Endpoints.UserEndpoints.UserGetAllEndpoint;

namespace RS1_2024_25.API.Endpoints.UserEndpoints;
[Route("users")]

public class UserGetAllEndpoint
(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithoutRequest
    .WithResult<UserGetAllResponse[]>
{
    [HttpGet("all")]
    public override async Task<UserGetAllResponse[]> HandleAsync(CancellationToken cancellationToken = default)
    {
        var result = await db.MyAppUsers
                        .Select(u => new UserGetAllResponse
                        {
                            ID = u.ID,
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                            Email = u.Email,
                            Password = u.Password,
                            PhoneNumber = u.PhoneNumber,
                            Address = u.Address,
                            CreatedAt = u.CreatedAt,
                            UpdatedAt = u.UpdatedAt,
                            IsAdmin = u.IsAdmin,
                            IsManager = u.IsManager
                        })
                        .ToArrayAsync(cancellationToken);

        return result;
    }

    public class UserGetAllResponse
    {
        public required int ID { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Address { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required DateTime UpdatedAt { get; set; }
        public required bool IsAdmin { get; set; }
        public required bool IsManager { get; set; }
    }
}

