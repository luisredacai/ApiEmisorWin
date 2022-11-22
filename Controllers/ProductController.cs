using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ApiProject3.Models;
//using ApiProyecto.Service;
//using Microsoft.Office.Interop.Excel;
namespace ApiProject3.Controllers;


[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    // dbexcel dbop = new dbexcel();  
   // db dbop = new db();
    private readonly da8k2ujd2nc9e6Context _da8K2Ujd2Nc9E6Context;

    

    public ProductController(da8k2ujd2nc9e6Context da8K2Ujd2Nc9E6Context )
    {
        this._da8K2Ujd2Nc9E6Context = da8K2Ujd2Nc9E6Context;
       
    }
    
  
  
    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        var empleado = this._da8K2Ujd2Nc9E6Context.EquifaxRucs.ToList();
        return Ok(empleado);
    }

    
    
    
    [HttpGet("BuscarUsuarioRuc")]
    public IActionResult GetbyCode(int enRUC)
    {
        var empleado = this._da8K2Ujd2Nc9E6Context.EquifaxRucs.FirstOrDefault(o=>o.Ruc==enRUC);
        return Ok(empleado);
    }
    [HttpDelete("Remove/{code}")]
    public IActionResult Remove(int code)
    {
        var empleado = this._da8K2Ujd2Nc9E6Context.Empleados.FirstOrDefault(o => o.Id == code);
        if (empleado != null)
        {
            this._da8K2Ujd2Nc9E6Context.Remove(empleado);
            this._da8K2Ujd2Nc9E6Context.SaveChanges();
            return Ok(true);
        }
        return Ok(false);
    }


    [HttpPost("Create")]
    public IActionResult Create([FromBody] Empleado _empleado)
    {
        var empleado = this._da8K2Ujd2Nc9E6Context.Empleados.FirstOrDefault(o => o.Id == _empleado.Id);
        if (empleado != null)
        {
            empleado.Id = _empleado.Id;
            empleado.Nombre = _empleado.Nombre;
            empleado.Puesto = _empleado.Puesto;
            empleado.Sueldo = _empleado.Sueldo;
        }
        else
        {
            this._da8K2Ujd2Nc9E6Context.Add(_empleado);
            this._da8K2Ujd2Nc9E6Context.SaveChanges();
        }
        return Ok(true);
    }
}
