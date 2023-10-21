using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EmpresaController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public EmpresaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Pager<EmpresaDto>>> Get(
            [FromQuery] Params EmpresaParams
        )
        {
            if (EmpresaParams == null)
            {
                return BadRequest(new ApiResponse(400, "Params cannot be null"));
            }
            var (totalRegisters, registers) = await _unitOfWork.Empresas.GetAllAsync(
                EmpresaParams.PageIndex,
                EmpresaParams.PageSize
            );
            var EmpresaListDto = _mapper.Map<List<EmpresaDto>>(registers);
            return new Pager<EmpresaDto>(
                EmpresaListDto,
                totalRegisters,
                EmpresaParams.PageIndex,
                EmpresaParams.PageSize
            );
        }
        
        private ActionResult<Pager<EmpresaDto>> BadRequest(ApiResponse apiResponse)
        {
        throw new NotImplementedException();
        }
        
        [HttpGet("1.1")]
        [MapToApiVersion("1.1")]
        public async Task<ActionResult<IEnumerable<EmpresaDto>>> Get1_1()
        {
            var registers = await _unitOfWork.Empresas.GetAllAsync();
            var EmpresaListDto = _mapper.Map<List<EmpresaDto>>(registers);
            return EmpresaListDto;
        }
        
        [HttpPost]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Empresa>> Post(EmpresaDto EmpresaDto)
        {
            var Empresa = _mapper.Map<Empresa>(EmpresaDto);
            _unitOfWork.Empresas.Add(Empresa);
            await _unitOfWork.SaveAsync();
            EmpresaDto.Id = Empresa.Id;
            return CreatedAtAction(nameof(Post), new { id = EmpresaDto.Id }, EmpresaDto);
        }
        
        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<EmpresaDto>> Put(
            int id,
            [FromBody] EmpresaDto EmpresaDto
        )
        {
            if (EmpresaDto == null)
            {
                return NotFound(new ApiResponse(404));
            }
            var Empresa = _mapper.Map<Empresa>(EmpresaDto);
            _unitOfWork.Empresas.Update(Empresa);
            await _unitOfWork.SaveAsync();
            return EmpresaDto;
        }
        
        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> Delete(int id)
        {
            var Empresa = await _unitOfWork.Empresas.GetByIdAsync(id);
            _unitOfWork.Empresas.Remove(Empresa);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}