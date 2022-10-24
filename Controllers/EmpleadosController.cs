using Microsoft.AspNetCore.Mvc;
using System.Linq;
using web_api_empleado.Models;
using System.Threading.Tasks;
namespace web_api_empleado.Controllers{

        [Route("api/[controller]")]
        public class EmpleadosController : Controller{
            private Conexion dbConexion;

            public EmpleadosController(){
                dbConexion=Conectar.Create();
            }
            [HttpGet]
            public ActionResult Get(){
                return Ok(dbConexion.Empleados.ToArray());
            }


            //inicio del CRUD
            [HttpGet("{id}")]
            public async Task<ActionResult> Get(int id){
            var empleados = await dbConexion.Empleados.FindAsync(id);
            if(empleados!=null){
                return Ok(empleados);
            }else{
                return NotFound();
            }
            }
    
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Empleados empleado){
            if(ModelState.IsValid){
                dbConexion.Empleados.Add(empleado);
                await dbConexion.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Empleados empleados){
            var v_empleados= dbConexion.Empleados.SingleOrDefault(a=>a.idEmpleado ==empleados.idEmpleado);
            if(v_empleados!=null && ModelState.IsValid){
                dbConexion.Entry(v_empleados).CurrentValues.SetValues(empleados);
                await dbConexion.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        
        [HttpDelete("{id}")]
            public async Task<ActionResult> Delete(int id){
            var empleados = dbConexion.Empleados.SingleOrDefault(a=>a.idEmpleado == id);
            if(empleados!=null){
                dbConexion.Empleados.Remove(empleados);
                await dbConexion.SaveChangesAsync();
                return Ok();
            }else{
                return BadRequest();
            }
        

        }

    }
}
 
