using System.Reflection.Metadata;
using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    [Authorize(Roles = "Employee,Admin")]
    public class ColorController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public ColorController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Pager<ColorDto>>> Get(
            [FromQuery] Params ColorParams
        )
        {
            if (ColorParams == null)
            {
                return BadRequest(new ApiResponse(400, "Params cannot be null"));
            }
            var (totalRegisters, registers) = await _unitOfWork.Colores.GetAllAsync(
                ColorParams.PageIndex,
                ColorParams.PageSize
            );
            var ColorListDto = _mapper.Map<List<ColorDto>>(registers);
            return new Pager<ColorDto>(
                ColorListDto,
                totalRegisters,
                ColorParams.PageIndex,
                ColorParams.PageSize
            );
        }
        
        private ActionResult<Pager<ColorDto>> BadRequest(ApiResponse apiResponse)
        {
        throw new NotImplementedException();
        }
        
        [HttpGet("1.1")]
        [MapToApiVersion("1.1")]
        public async Task<ActionResult<IEnumerable<ColorDto>>> Get1_1()
        {
            var registers = await _unitOfWork.Colores.GetAllAsync();
            var ColorListDto = _mapper.Map<List<ColorDto>>(registers);
            return ColorListDto;
        }
        
        [HttpPost]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Color>> Post(ColorDto ColorDto)
        {
            var Color = _mapper.Map<Color>(ColorDto);
            _unitOfWork.Colores.Add(Color);
            await _unitOfWork.SaveAsync();
            ColorDto.Id = Color.Id;
            return CreatedAtAction(nameof(Post), new { id = ColorDto.Id }, ColorDto);
        }
        
        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<ColorDto>> Put(
            int id,
            [FromBody] ColorDto ColorDto
        )
        {
            if (ColorDto == null)
            {
                return NotFound(new ApiResponse(404));
            }
            var Color = _mapper.Map<Color>(ColorDto);
            _unitOfWork.Colores.Update(Color);
            await _unitOfWork.SaveAsync();
            return ColorDto;
        }
        
        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> Delete(int id)
        {
            var Color = await _unitOfWork.Colores.GetByIdAsync(id);
            _unitOfWork.Colores.Remove(Color);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}