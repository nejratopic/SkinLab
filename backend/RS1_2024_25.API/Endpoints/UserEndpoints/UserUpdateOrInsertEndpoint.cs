using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Data.Models;
using RS1_2024_25.API.Data.Models.Auth;
using RS1_2024_25.API.Helper.Api;
using RS1_2024_25.API.Services;
using static RS1_2024_25.API.Endpoints.UserEndpoints.UserUpdateOrInsertEndpoint;

namespace RS1_2024_25.API.Endpoints.UserEndpoints;
[Route("users")]

public class UserUpdateOrInsertEndpoint
(ApplicationDbContext db, MyAuthService myAuthService) : MyEndpointBaseAsync
        .WithRequest<UserUpdateOrInsertRequest>
        .WithActionResult<UserUpdateOrInsertResponse>
{
    [HttpPost]  // Using POST to support both create and update
    public override async Task<ActionResult<UserUpdateOrInsertResponse>> HandleAsync([FromBody] UserUpdateOrInsertRequest request, CancellationToken cancellationToken = default)
    {
        bool isInsert = (request.ID == null || request.ID == 0);
        MyAppUser? user;

        if (isInsert)
        {

            user = new MyAppUser();
            user.CreatedAt = DateTime.Now;
            db.MyAppUsers.Add(user);
        }
        else
        {

            user = await db.MyAppUsers.FindAsync(new object[] { request.ID }, cancellationToken);

            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }
        }

        // Set common properties for both insert and update operations
        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.Email = request.Email;
        user.Password = request.Password;
        user.PhoneNumber = request.PhoneNumber;
        user.Address = request.Address;
        user.IsAdmin = request.IsAdmin;
        user.IsManager = request.IsManager;

        user.UpdatedAt = DateTime.Now;



        // Save changes to the database
        await db.SaveChangesAsync(cancellationToken);

        return new UserUpdateOrInsertResponse
        {
            ID = user.ID,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Password = user.Password,
            PhoneNumber = user.PhoneNumber,
            Address = user.Address,
            IsAdmin = user.IsAdmin,
            IsManager = user.IsManager,
            UpdatedAt = user.UpdatedAt,
            CreatedAt = user.CreatedAt
        };

    }

    public class UserUpdateOrInsertRequest
    {
        public required int? ID { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Address { get; set; }
        public required bool IsAdmin { get; set; }
        public required bool IsManager { get; set; }

    }

    public class UserUpdateOrInsertResponse
    {
        public required int ID { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Address { get; set; }
        public required bool IsAdmin { get; set; }
        public required bool IsManager { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required DateTime UpdatedAt { get; set; }

    }
}


