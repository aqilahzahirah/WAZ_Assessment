using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.Json;
using WAZ_Assessment.Models;

namespace WAZ_Assessment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlatformWellController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly ApplicationDbContext _context;

        public PlatformWellController(IHttpClientFactory httpClientFactory, ApplicationDbContext context)
        {
            _context = context;
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://test-demo.aemenersol.com/");
        }

        [HttpGet("GetPlatformWellActual")]
        public async Task<IActionResult> GetPlatformWellActual()
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var response = await _httpClient.GetAsync("api/PlatformWell/GetPlatformWellActual");

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();

                    var platforms = JsonConvert.DeserializeObject<List<Platform>>(responseData);

                    foreach (var platform in platforms)
                    {
                        var currPF = await _context.Platform.FindAsync(platform.id);
                        
                        if (currPF == null)
                        {
                            var newPF = new Platform
                            {
                                id = platform.id,
                                uniqueName = platform.uniqueName,
                                latitude = platform.latitude,
                                longitude = platform.longitude,
                                createdAt = platform.createdAt,
                                updatedAt = platform.updatedAt
                            };

                            _context.Platform.Add(newPF);
                        }

                        else
                        {
                            currPF.uniqueName = platform.uniqueName;
                            currPF.latitude = platform.latitude;
                            currPF.longitude = platform.longitude;
                            currPF.createdAt = platform.createdAt;
                            currPF.updatedAt = platform.updatedAt;

                            _context.Platform.Update(currPF);
                        }

                        foreach (var well in platform.well)
                        {
                            var currWell = await _context.Well.FindAsync(well.id);

                            if (currWell == null)
                            {
                                var newWell = new Well
                                {
                                    id = well.id,
                                    platformId = platform.id,
                                    uniqueName = well.uniqueName,
                                    latitude = well.latitude,
                                    longitude = well.longitude,
                                    createdAt = well.createdAt,
                                    updatedAt = well.updatedAt
                                };

                                _context.Well.Add(newWell);
                            }

                            else
                            {
                                currWell.platformId = platform.id;
                                currWell.uniqueName = well.uniqueName;
                                currWell.latitude = well.latitude;
                                currWell.longitude = well.longitude;
                                currWell.createdAt = well.createdAt;
                                currWell.updatedAt = well.updatedAt;

                                _context.Well.Update(currWell);
                            }
                        }
                    }

                    await _context.SaveChangesAsync();

                    return Ok(platforms);
                }
                else
                {
                    return BadRequest("Failed to fetch platform well data");
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.ToString());

                // Check if there's an inner exception
                var message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                return StatusCode(500, $"Internal server error: {message}");
            }
        }
    }
}
