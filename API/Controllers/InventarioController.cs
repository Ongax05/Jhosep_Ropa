using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class InventarioController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public InventarioController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Pager<InventarioDto>>> Get(
            [FromQuery] Params InventarioParams
        )
        {
            if (InventarioParams == null)
            {
                return BadRequest(new ApiResponse(400, "Params cannot be null"));
            }
            var (totalRegisters, registers) = await _unitOfWork.Inventarios.GetAllAsync(
                InventarioParams.PageIndex,
                InventarioParams.PageSize
            );
            var InventarioListDto = _mapper.Map<List<InventarioDto>>(registers);
            return new Pager<InventarioDto>(
                InventarioListDto,
                totalRegisters,
                InventarioParams.PageIndex,
                InventarioParams.PageSize
            );
        }
        
        private ActionResult<Pager<InventarioDto>> BadRequest(ApiResponse apiResponse)
        {
        throw new NotImplementedException();
        }
        
        [HttpGet]
        [MapToApiVersion("1.1")]
        public async Task<ActionResult<IEnumerable<InventarioDto>>> Get1_1()
        {
            var registers = await _unitOfWork.Inventarios.GetAllAsync();
            var InventarioListDto = _mapper.Map<List<InventarioDto>>(registers);
            return InventarioListDto;
        }
        
        [HttpPost]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Inventario>> Post(InventarioDto InventarioDto)
        {
            var Inventario = _mapper.Map<Inventario>(InventarioDto);
            _unitOfWork.Inventarios.Add(Inventario);
            await _unitOfWork.SaveAsync();
            InventarioDto.Id = Inventario.Id;
            return CreatedAtAction(nameof(Post), new { id = InventarioDto.Id }, InventarioDto);
        }
        
        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<InventarioDto>> Put(
            int id,
            [FromBody] InventarioDto InventarioDto
        )
        {
            if (InventarioDto == null)
            {
                return NotFound(new ApiResponse(404));
            }
            var Inventario = _mapper.Map<Inventario>(InventarioDto);
            _unitOfWork.Inventarios.Update(Inventario);
            await _unitOfWork.SaveAsync();
            return InventarioDto;
        }
        
        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> Delete(int id)
        {
            var Inventario = await _unitOfWork.Inventarios.GetByIdAsync(id);
            _unitOfWork.Inventarios.Remove(Inventario);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }        
    }
}