using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class FormaPagoController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public FormaPagoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Pager<FormaPagoDto>>> Get(
            [FromQuery] Params FormaPagoParams
        )
        {
            if (FormaPagoParams == null)
            {
                return BadRequest(new ApiResponse(400, "Params cannot be null"));
            }
            var (totalRegisters, registers) = await _unitOfWork.FormasPagos.GetAllAsync(
                FormaPagoParams.PageIndex,
                FormaPagoParams.PageSize
            );
            var FormaPagoListDto = _mapper.Map<List<FormaPagoDto>>(registers);
            return new Pager<FormaPagoDto>(
                FormaPagoListDto,
                totalRegisters,
                FormaPagoParams.PageIndex,
                FormaPagoParams.PageSize
            );
        }
        
        private ActionResult<Pager<FormaPagoDto>> BadRequest(ApiResponse apiResponse)
        {
        throw new NotImplementedException();
        }
        
        [HttpGet]
        [MapToApiVersion("1.1")]
        public async Task<ActionResult<IEnumerable<FormaPagoDto>>> Get1_1()
        {
            var registers = await _unitOfWork.FormasPagos.GetAllAsync();
            var FormaPagoListDto = _mapper.Map<List<FormaPagoDto>>(registers);
            return FormaPagoListDto;
        }
        
        [HttpPost]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<FormaPago>> Post(FormaPagoDto FormaPagoDto)
        {
            var FormaPago = _mapper.Map<FormaPago>(FormaPagoDto);
            _unitOfWork.FormasPagos.Add(FormaPago);
            await _unitOfWork.SaveAsync();
            FormaPagoDto.Id = FormaPago.Id;
            return CreatedAtAction(nameof(Post), new { id = FormaPagoDto.Id }, FormaPagoDto);
        }
        
        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<FormaPagoDto>> Put(
            int id,
            [FromBody] FormaPagoDto FormaPagoDto
        )
        {
            if (FormaPagoDto == null)
            {
                return NotFound(new ApiResponse(404));
            }
            var FormaPago = _mapper.Map<FormaPago>(FormaPagoDto);
            _unitOfWork.FormasPagos.Update(FormaPago);
            await _unitOfWork.SaveAsync();
            return FormaPagoDto;
        }
        
        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> Delete(int id)
        {
            var FormaPago = await _unitOfWork.FormasPagos.GetByIdAsync(id);
            _unitOfWork.FormasPagos.Remove(FormaPago);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}