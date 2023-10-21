using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class MunicipioController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public MunicipioController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Pager<MunicipioDto>>> Get(
            [FromQuery] Params MunicipioParams
        )
        {
            if (MunicipioParams == null)
            {
                return BadRequest(new ApiResponse(400, "Params cannot be null"));
            }
            var (totalRegisters, registers) = await _unitOfWork.Municipios.GetAllAsync(
                MunicipioParams.PageIndex,
                MunicipioParams.PageSize
            );
            var MunicipioListDto = _mapper.Map<List<MunicipioDto>>(registers);
            return new Pager<MunicipioDto>(
                MunicipioListDto,
                totalRegisters,
                MunicipioParams.PageIndex,
                MunicipioParams.PageSize
            );
        }
        
        private ActionResult<Pager<MunicipioDto>> BadRequest(ApiResponse apiResponse)
        {
        throw new NotImplementedException();
        }
        
        [HttpGet]
        [MapToApiVersion("1.1")]
        public async Task<ActionResult<IEnumerable<MunicipioDto>>> Get1_1()
        {
            var registers = await _unitOfWork.Municipios.GetAllAsync();
            var MunicipioListDto = _mapper.Map<List<MunicipioDto>>(registers);
            return MunicipioListDto;
        }
        
        [HttpPost]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Municipio>> Post(MunicipioDto MunicipioDto)
        {
            var Municipio = _mapper.Map<Municipio>(MunicipioDto);
            _unitOfWork.Municipios.Add(Municipio);
            await _unitOfWork.SaveAsync();
            MunicipioDto.Id = Municipio.Id;
            return CreatedAtAction(nameof(Post), new { id = MunicipioDto.Id }, MunicipioDto);
        }
        
        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<MunicipioDto>> Put(
            int id,
            [FromBody] MunicipioDto MunicipioDto
        )
        {
            if (MunicipioDto == null)
            {
                return NotFound(new ApiResponse(404));
            }
            var Municipio = _mapper.Map<Municipio>(MunicipioDto);
            _unitOfWork.Municipios.Update(Municipio);
            await _unitOfWork.SaveAsync();
            return MunicipioDto;
        }
        
        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> Delete(int id)
        {
            var Municipio = await _unitOfWork.Municipios.GetByIdAsync(id);
            _unitOfWork.Municipios.Remove(Municipio);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}