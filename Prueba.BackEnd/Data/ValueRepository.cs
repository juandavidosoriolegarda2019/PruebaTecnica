using Microsoft.Extensions.Configuration;
using Prueba.BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Prueba.BackEnd.Data
{
    public class ValueRepository
    {
        private readonly string _conexion;

        public ValueRepository(IConfiguration config)
        {
            _conexion = config.GetConnectionString("DefaultConnection"); 
        }
     
        public async Task<List<PersonasXPremios>> GetPersonaXPremio()
        {

            using (SqlConnection sql = new SqlConnection(_conexion))
            {
                using (SqlCommand cmd = new SqlCommand("ListarPersonasxPremios", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<PersonasXPremios>();
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToValuePersonasXPremio(reader));
                        }
                    }
                    await sql.CloseAsync();
                    return response;
                }
            }
        }
        public async Task<List<Persona>> GetAll()
        {

            using (SqlConnection sql = new SqlConnection(_conexion))
            {
                using (SqlCommand cmd = new SqlCommand("ListarPersonas", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<Persona>();
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToValue(reader));
                        }
                    }
                    await sql.CloseAsync();
                    return response;
                }
            }
        }

        public async Task<Persona> Getbyid(int pIntId)
        {
            using (SqlConnection sql = new SqlConnection(_conexion))
            {
                using (SqlCommand cmd = new SqlCommand("ListarPersonasById", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IntId", pIntId));

                    var response = new  Persona();
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response=(MapToValue(reader));
                        }
                    }
                    await sql.CloseAsync();
                    return response;
                }
            }
        }

        public async Task<List<Persona>> GetFilter(string pfiltro)
        {
            using (SqlConnection sql = new SqlConnection(_conexion))
            {
                using (SqlCommand cmd = new SqlCommand("ListarPersonasFiltro", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Filtro", pfiltro));

                    var response = new List<Persona>();
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToValue(reader));
                        }
                    }
                    await sql.CloseAsync();
                    return response;
                }
            }
        }

        public async Task<string> Insert(Persona objPersona)
        {
            string ejecuto = "";
            try 
            {
              
                SqlConnection sql = new SqlConnection(_conexion);
                await sql.OpenAsync();
                SqlCommand cmd = new SqlCommand("ActualizarPersona", sql);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@NroDocumento", objPersona.NroDocumento));
                cmd.Parameters.Add(new SqlParameter("@TipoDocumento", objPersona.TipoDocumento));
                cmd.Parameters.Add(new SqlParameter("@Nombres", objPersona.Nombres));
                cmd.Parameters.Add(new SqlParameter("@Apellidos", objPersona.Apellidos));
                cmd.Parameters.Add(new SqlParameter("@FechaNacimiento", objPersona.FechaNacimiento)); 
                cmd.Parameters.Add(new SqlParameter("@Opcion", "1")); 
                 await cmd.ExecuteNonQueryAsync();
                await sql.CloseAsync();
                return ejecuto;
            }
            catch (SqlException ex)
            {
                if (ex.Number== 15600)
                {
                    ejecuto = "¡El nro de documento ya existe en la base de datos!"; 
                }
                return ejecuto;
            }
        }

        public async Task<bool> Update(Persona objPersona)
        {
            bool ejecuto = false;
            try
            {
                ejecuto = true;
                SqlConnection sql = new SqlConnection(_conexion);
                await sql.OpenAsync();
                SqlCommand cmd = new SqlCommand("ActualizarPersona", sql);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@NroDocumento", objPersona.NroDocumento));
                cmd.Parameters.Add(new SqlParameter("@TipoDocumento", objPersona.TipoDocumento));
                cmd.Parameters.Add(new SqlParameter("@Nombres", objPersona.Nombres));
                cmd.Parameters.Add(new SqlParameter("@Apellidos", objPersona.Apellidos));
                cmd.Parameters.Add(new SqlParameter("@FechaNacimiento", objPersona.FechaNacimiento));
                cmd.Parameters.Add(new SqlParameter("@Opcion", "2"));
                await cmd.ExecuteNonQueryAsync();
                await sql.CloseAsync();
                return ejecuto;
            }
            catch (Exception ex)
            {
                return ejecuto;
            }
        }

        public async Task<string> Delete(int pIntId)
        {
            string ejecuto = "";
            try
            { 
                SqlConnection sql = new SqlConnection(_conexion);
                await sql.OpenAsync();
                SqlCommand cmd = new SqlCommand("EliminarPersona", sql);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@pIntId", pIntId)); 
                await cmd.ExecuteNonQueryAsync();
                await sql.CloseAsync();
                return ejecuto;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 15600)
                {
                    ejecuto = "¡No se puede Eliminar Persona con premio Asignado!";
                }
                return ejecuto;
            }
        }
        public string AsignarPremio()
        {
            string ejecuto = "";
            try
            {
                SqlConnection sql = new SqlConnection(_conexion);
                sql.Open();
                SqlCommand cmd = new SqlCommand("AsignarPremio", sql);
                
                SqlParameter outPutParameter = new SqlParameter();
                outPutParameter.ParameterName = "@msj"; 
                outPutParameter.SqlDbType = System.Data.SqlDbType.VarChar;
                outPutParameter.Size = 100;
                outPutParameter.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(outPutParameter);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                ejecuto = outPutParameter.Value.ToString();
                sql.Close();
                return ejecuto;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 15600 || ex.Number == 15601 || ex.Number == 15602 )
                {
                    ejecuto = "¡No se puede Eliminar Persona con premio Asignado!";
                }
                return ejecuto;
            }
        }


        private Persona MapToValue(SqlDataReader reader)
        {
            return new Persona()
            {
                IntId = (int)reader["IntId"], 
                NroDocumento = (int)reader["NroDocumento"],
                TipoDocumento = reader["TipoDocumento"].ToString(),
                Nombres = reader["Nombres"].ToString(),
                Apellidos = reader["Apellidos"].ToString(),
                FechaNacimiento=Convert.ToDateTime(reader["FechaNacimiento"]),

            };
        }

        private PersonasXPremios MapToValuePersonasXPremio(SqlDataReader reader)
        {
            return new PersonasXPremios()
            {
                Id = (int)reader["Id"],
                Codigo = reader["Codigo"].ToString(),
                Premio = reader["Premio"].ToString(),
                Nombres = reader["Nombres"].ToString(),
                NroDocumento = reader["NroDocumento"].ToString(),
                FechaPremio = Convert.ToDateTime(reader["FechaPremio"]),
            };
        }
        
    }
}
