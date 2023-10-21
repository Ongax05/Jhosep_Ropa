using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class InsumoController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public InsumoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Pager<InsumoDto>>> Get(
            [FromQuery] Params InsumoParams
        )
        {
            if (InsumoParams == null)
            {
                return BadRequest(new ApiResponse(400, "Params cannot be null"));
            }
            var (totalRegisters, registers) = await _unitOfWork.Insumos.GetAllAsync(
                InsumoParams.PageIndex,
                InsumoParams.PageSize
            );
            var InsumoListDto = _mapper.Map<List<InsumoDto>>(registers);
            return new Pager<InsumoDto>(
                InsumoListDto,
                totalRegisters,
                InsumoParams.PageIndex,
                InsumoParams.PageSize
            );
        }
        
        private ActionResult<Pager<InsumoDto>> BadRequest(ApiResponse apiResponse)
        {
        throw new NotImplementedException();
        }
        
        [HttpGet("1.1")]
        [MapToApiVersion("1.1")]
        public async Task<ActionResult<IEnumerable<InsumoDto>>> Get1_1()
        {
            var registers = await _unitOfWork.Insumos.GetAllAsync();
            var InsumoListDto = _mapper.Map<List<InsumoDto>>(registers);
            return InsumoListDto;
        }
        
        [HttpPost]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Insumo>> Post(InsumoDto InsumoDto)
        {
            var Insumo = _mapper.Map<Insumo>(InsumoDto);
            _unitOfWork.Insumos.Add(Insumo);
            await _unitOfWork.SaveAsync();
            InsumoDto.Id = Insumo.Id;
            return CreatedAtAction(nameof(Post), new { id = InsumoDto.Id }, InsumoDto);
        }
        
        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<InsumoDto>> Put(
            int id,
            [FromBody] InsumoDto InsumoDto
        )
        {
            if (InsumoDto == null)
            {
                return NotFound(new ApiResponse(404));
            }
            var Insumo = _mapper.Map<Insumo>(InsumoDto);
            _unitOfWork.Insumos.Update(Insumo);
            await _unitOfWork.SaveAsync();
            return InsumoDto;
        }
        
        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> Delete(int id)
        {
            var Insumo = await _unitOfWork.Insumos.GetByIdAsync(id);
            _unitOfWork.Insumos.Remove(Insumo);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        [HttpGet("GetInsumoByPrendas")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Pager<InsumoDto>>> GetInsumosByPrendas(
            [FromQuery] Params InsumoParams,
            string cod
        )
        {
            if (InsumoParams == null)
            {
                return BadRequest(new ApiResponse(400, "Params cannot be null"));
            }
            var (totalRegisters, registers) = await _unitOfWork.Insumos.GetInsumosByPrenda(
                InsumoParams.PageIndex,
                InsumoParams.PageSize,
                cod
            );
            var InsumoListDto = _mapper.Map<List<InsumoDto>>(registers);
            return new Pager<InsumoDto>(
                InsumoListDto,
                totalRegisters,
                InsumoParams.PageIndex,
                InsumoParams.PageSize
            );
        }
        [HttpGet("GetInsumosByProveedorJuridico")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Pager<InsumoDto>>> GetInsumosByProveedorJuridico(
            [FromQuery] Params InsumoParams,
            string Nit
        )
        {
            if (InsumoParams == null)
            {
                return BadRequest(new ApiResponse(400, "Params cannot be null"));
            }
            var (totalRegisters, registers) = await _unitOfWork.Insumos.GetInsumosByProveedorJuridico(
                InsumoParams.PageIndex,
                InsumoParams.PageSize,
                Nit
            );
            var InsumoListDto = _mapper.Map<List<InsumoDto>>(registers);
            return new Pager<InsumoDto>(
                InsumoListDto,
                totalRegisters,
                InsumoParams.PageIndex,
                InsumoParams.PageSize
            );
        }
    }
}