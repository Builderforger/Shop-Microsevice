using Grpc.Core;
using Shared.Protos;
using Microsoft.EntityFrameworkCore;
using ApiNumber10.Infrastructure.Data;

public class UserGrpcServiceImpl(ApplicationDbContext context) : UserGrpcService.UserGrpcServiceBase
{
    public override async Task<UserResponse> GetUserInfo(UserRequest request, ServerCallContext contextCall)
    {
        var user = await context.Users.FindAsync(Guid.Parse(request.UserId));

        if (user == null)
            throw new RpcException(new Status(StatusCode.NotFound, "User not found"));

        return new UserResponse
        {
            UserId = user.Id.ToString(),
            Name = user.Name,
            Email = user.Email,
            Role = user.Role
        };
    }
}