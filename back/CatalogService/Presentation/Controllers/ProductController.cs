using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Protos;
using CatalogService.Application.DTOs;
using CatalogService.Application.Interfaces;

namespace CatalogService.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController(IProductService productService) : ControllerBase
{
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<ProductResponseDto>>> GetAll()
    {
        var products = await productService.GetAllAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductResponseDto>> GetById(Guid id)
    {
        var product = await productService.GetByIdAsync(id);
        return product != null ? Ok(product) : NotFound();
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<ProductResponseDto>> Create(ProductCreateDto dto)
    {
        var result = await productService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(Guid id, ProductUpdateDto dto)
    {
        var success = await productService.UpdateAsync(id, dto);
        return success ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var success = await productService.DeleteAsync(id);
        return success ? NoContent() : NotFound();
    }
    [HttpGet("test-grpc/{userId}")]
    public async Task<IActionResult> GetUserGrpc(string userId, [FromServices] UserGrpcService.UserGrpcServiceClient client)
    {
        try
        {
            var request = new UserRequest { UserId = userId };
            var response = await client.GetUserInfoAsync(request);
            return Ok(new
            {
                Status = "Success",
                Name = response.Name,
                Role = response.Role
            });
        }
        catch (Exception ex)
        {
            return BadRequest($"gRPC dead: { ex.Message}");
        }
    }
}
